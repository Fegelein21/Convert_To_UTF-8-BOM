using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using UtfUnknown;

namespace ConvertToUTF8BOM
{
	public partial class MainForm : Form
	{
		const string ConfigFile = "config.ini";
		const string DefaultFileExt = ".csv .erb .erh .txt";
		const string DefaultEncoding = "20127.1 65001.1 932.1 936.1 950.1";
		static readonly Encoding UTF8BOM = new UTF8Encoding(true);

		private string ConfigStr = "";

		private string[] File_Ext;

		private int TotalFileCount;
		private int ConvertFileCount;
		private int CopyFileCount;
		private int ErrorFileCount;

		public MainForm()
		{
			InitializeComponent();
			ReadConfig();
			AddEncodingTextBox_Leave1();
		}

		private void ReadConfig()
		{
			if (File.Exists(ConfigFile))
			{
				ConfigStr = File.ReadAllText(ConfigFile, Encoding.UTF8);
			}

			SubFolderCheckBox.Checked = GetConfig("HandleSubFolder", true);
			EmptyFileCheckBox.Checked = GetConfig("HandleEmptyFile", true);
			CopyFileCheckBox.Checked = GetConfig("CopyOtherFile", false);

			FileExtTextBox.Text = GetConfig("FileExtension", DefaultFileExt).Trim();
			Refresh_File_Ext();

			string[] list = GetConfig("FileEncoding", DefaultEncoding).Trim().Split(' ');
			for (int i = 0; i < list.Length; i++)
			{
				string[] data = list[i].Split('.');
				data[0] = AddEncodingToList(data[0]);
				EncodingCheckedListBox.SetItemChecked(EncodingCheckedListBox.Items.IndexOf(data[0]), data[1] == "1");
			}
		}

		private void WriteConfig()
		{
			SetConfig("HandleSubFolder", SubFolderCheckBox.Checked.ToString());
			SetConfig("HandleEmptyFile", EmptyFileCheckBox.Checked.ToString());
			SetConfig("CopyOtherFile", CopyFileCheckBox.Checked.ToString());
			SetConfig("FileExtension", FileExtTextBox.Text);

			string[] data = new string[EncodingCheckedListBox.Items.Count];
			EncodingCheckedListBox.Items.CopyTo(data, 0);
			for (int i = 0; i < EncodingCheckedListBox.Items.Count; i++)
			{
				data[i] += "." + (EncodingCheckedListBox.GetItemChecked(i) ? "1" : "0");
			}
			SetConfig("FileEncoding", string.Join(" ", data));

			File.WriteAllText(ConfigFile, ConfigStr, Encoding.UTF8);
		}

		private string GetConfig(string key, string defaultVar = "")
		{
			if (ConfigStr == "")
			{
				return defaultVar;
			}
			Match match = Regex.Match(ConfigStr, string.Format("{0}=(.*)", key));
			return match.Groups.Count > 1 ? match.Groups[1].ToString() : defaultVar;
		}

		private bool GetConfig(string key, bool defaultVar)
		{
			return bool.TryParse(GetConfig(key), out bool result) ? result : defaultVar;
		}

		private void SetConfig(string key, string value)
		{
			string format = string.Format("{0}=.*", key);
			if (Regex.Matches(ConfigStr, format).Count > 0)
			{
				ConfigStr = Regex.Replace(ConfigStr, format, key + "=" + value);
			}
			else
			{
				ConfigStr += key + "=" + value + "\r\n";
			}
		}

		private string GetEnableFilename(string path)
		{
			if (!File.Exists(path) && !Directory.Exists(path))
			{
				return path;
			}

			int rename = 1;
			string dict = Path.GetDirectoryName(path);
			string name = Path.GetFileNameWithoutExtension(path);
			string ext = Path.GetExtension(path);

			while (File.Exists(path) || Directory.Exists(path))
			{
				path = string.Format("{0}\\{1} ({2}){3}", dict, name, rename++, ext);
			}

			return path;
		}

		private Encoding DetectEncoding(string path)
		{

			DetectionResult result = CharsetDetector.DetectFromFile(path);
			if (result.Detected == null)
			{
				if (File.ReadAllText(path, Encoding.UTF8) == "")
				{
					return EmptyFileCheckBox.Checked ? UTF8BOM : null;
				}
				DebugLog("无法识别编码", path);
				return null;
			}

			Encoding encoding = result.Detected.Encoding;
			int index = EncodingCheckedListBox.Items.IndexOf(encoding.WebName);

			if (index >= 0)
			{
				bool encodingCheck = EncodingCheckedListBox.GetItemChecked(index);
				if (encodingCheck && encoding.CodePage == UTF8BOM.CodePage && result.Detected.HasBOM)
				{
					encodingCheck = false;
				}

				return encodingCheck ? encoding : null;
			}

			DebugLog("预期外的编码", string.Format("[{0}] {1}", result.Detected.Encoding.WebName, path));
			return null;
		}

		private void DealOneFile(string path, string topDict)
		{
			TotalFileCount++;
			string fileName = Path.GetFileName(path);
			string out_path = GetEnableFilename(topDict + "\\" + fileName);
			//DebugLog("dealOneFile", out_path);

			try
			{
				if (File_Ext.Contains(Path.GetExtension(path).ToLower()))
				{
					Encoding encoding = DetectEncoding(path);
					if (encoding != null)
					{
						File.WriteAllText(out_path, File.ReadAllText(path, encoding), UTF8BOM);
						ConvertFileCount++;
						return;
					}
				}

				if (CopyFileCheckBox.Checked)
				{
					File.Copy(path, out_path);
					CopyFileCount++;
				}
			}
			catch (Exception e)
			{
				DebugLog("未知错误", e.Message + " : " + path);
				ErrorFileCount++;
			}
		}

		private void DealFiles(string filePath, string topDict)
		{
			if (!Directory.Exists(topDict))
			{
				Directory.CreateDirectory(topDict);
			}

			foreach (var path in Directory.GetFiles(filePath))
			{
				DealOneFile(path, topDict);
			}

			backgroundWorker.ReportProgress(0);

			if (SubFolderCheckBox.Checked)
			{
				foreach (var path in Directory.GetDirectories(filePath))
				{
					DealFiles(path, topDict + "\\" + Path.GetFileName(path));
				}
			}
		}

		private void WorkDealFiles(object sender, DoWorkEventArgs e)
		{
			string[] data = (string[])e.Argument;

			foreach (var path in data)
			{
				if (Directory.Exists(path))
				{
					string topDict = path + " (Converted)";
					if (!Directory.Exists(topDict))
					{
						Directory.CreateDirectory(topDict);
					}
					DealFiles(path, topDict);
				}
				else
				{
					DealOneFile(path, Path.GetDirectoryName(path));
				}
			}
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				string[] data = (string[])e.Data.GetData(DataFormats.FileDrop, false);

				if (data.Length > 0 && EncodingCheckedListBox.CheckedItems.Count > 0 && File_Ext.Length > 0)
				{
					AllowDrop = false;
					TotalFileCount = 0;
					ConvertFileCount = 0;
					CopyFileCount = 0;
					ErrorFileCount = 0;

					AddTextLog("开始处理，请稍等。。。");
					backgroundWorker.RunWorkerAsync(data);
				}
			}
			catch (Exception ex)
			{
				AllowDrop = true;
				AddTextLog(ex.ToString());
			}
		}

		private void MainForm_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.UserState != null)
			{
				string text = e.UserState.ToString();
				if (text != "")
				{
					AddTextLog(text);
				}
			}
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			AllowDrop = true;
			AddTextLog(string.Format("转码完成: 共计{0}个文件，{1}个文件转换成功，{2}个文件仅复制，{3}个错误。", TotalFileCount, ConvertFileCount, CopyFileCount, ErrorFileCount));
		}

		private void DebugLog(string tag, string text)
		{
			backgroundWorker.ReportProgress(0, tag + ": " + text);
		}

		private void AddTextLog(string text)
		{
			LogTextBox.Text += text + "\r\n";
			LogTextBox.Select(LogTextBox.Text.Length, 0);
			LogTextBox.ScrollToCaret();
		}

		private void FileExt_TextChanged(object sender, EventArgs e)
		{
			Refresh_File_Ext();
		}

		private void Refresh_File_Ext()
		{
			if (FileExtTextBox.Text.Trim() == "")
			{
				File_Ext = new string[0];
			}
			else
			{
				File_Ext = FileExtTextBox.Text.Trim().ToLower().Split(' ');
			}
		}

		private void AddEncodingTextBox_Enter(object sender, EventArgs e)
		{
			AddEncodingTextBox.Text = "";
			AddEncodingTextBox.ForeColor = System.Drawing.Color.Black;
		}

		private void AddEncodingTextBox_Leave(object sender, EventArgs e)
		{
			AddEncodingTextBox_Leave1();
		}

		private void AddEncodingTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ((char)Keys.Enter))
			{
				AddEncodingToList(AddEncodingTextBox.Text);
				EncodingCheckedListBox.Select();
			}
		}

		private void AddEncodingTextBox_Leave1()
		{
			AddEncodingTextBox.Text = "添加编码(名称或代码页)";
			AddEncodingTextBox.ForeColor = System.Drawing.Color.Gray;
		}

		private string AddEncodingToList(string text)
		{
			Encoding encoding = GetEncodingByStrCodePage(text);
			if (encoding != null)
			{
				if (!EncodingCheckedListBox.Items.Contains(encoding.WebName))
					EncodingCheckedListBox.Items.Add(encoding.WebName);
				return encoding.WebName;
			}
			return "";
		}

		private Encoding GetEncodingByStrCodePage(string text)
		{
			try
			{
				if (int.TryParse(text, out int codePage))
					return Encoding.GetEncoding(codePage);
				else
					return Encoding.GetEncoding(text);
			}
			catch
			{
			}
			return null;
		}

		private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			WriteConfig();
		}
	}
}
