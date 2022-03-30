namespace ConvertToUTF8BOM
{
	partial class MainForm
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.SubFolderCheckBox = new System.Windows.Forms.CheckBox();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.CopyFileCheckBox = new System.Windows.Forms.CheckBox();
			this.FileExtTextBox = new System.Windows.Forms.TextBox();
			this.label = new System.Windows.Forms.Label();
			this.LogTextBox = new System.Windows.Forms.TextBox();
			this.EncodingCheckedListBox = new System.Windows.Forms.CheckedListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.EmptyFileCheckBox = new System.Windows.Forms.CheckBox();
			this.AddEncodingTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// SubFolderCheckBox
			// 
			this.SubFolderCheckBox.AutoSize = true;
			this.SubFolderCheckBox.Checked = true;
			this.SubFolderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.SubFolderCheckBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.SubFolderCheckBox.Location = new System.Drawing.Point(15, 14);
			this.SubFolderCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.SubFolderCheckBox.Name = "SubFolderCheckBox";
			this.SubFolderCheckBox.Size = new System.Drawing.Size(110, 18);
			this.SubFolderCheckBox.TabIndex = 0;
			this.SubFolderCheckBox.Text = "处理子文件夹";
			this.SubFolderCheckBox.UseVisualStyleBackColor = true;
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkDealFiles);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// CopyFileCheckBox
			// 
			this.CopyFileCheckBox.AutoSize = true;
			this.CopyFileCheckBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.CopyFileCheckBox.Location = new System.Drawing.Point(15, 61);
			this.CopyFileCheckBox.Name = "CopyFileCheckBox";
			this.CopyFileCheckBox.Size = new System.Drawing.Size(152, 18);
			this.CopyFileCheckBox.TabIndex = 2;
			this.CopyFileCheckBox.Text = "复制无需处理的文件";
			this.CopyFileCheckBox.UseVisualStyleBackColor = true;
			// 
			// FileExtTextBox
			// 
			this.FileExtTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.FileExtTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FileExtTextBox.Location = new System.Drawing.Point(268, 12);
			this.FileExtTextBox.Name = "FileExtTextBox";
			this.FileExtTextBox.Size = new System.Drawing.Size(434, 23);
			this.FileExtTextBox.TabIndex = 10;
			this.FileExtTextBox.TextChanged += new System.EventHandler(this.FileExt_TextChanged);
			// 
			// label
			// 
			this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label.AutoSize = true;
			this.label.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label.Location = new System.Drawing.Point(199, 15);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(63, 14);
			this.label.TabIndex = 12;
			this.label.Text = "文件格式";
			// 
			// LogTextBox
			// 
			this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.LogTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.LogTextBox.Location = new System.Drawing.Point(202, 49);
			this.LogTextBox.Multiline = true;
			this.LogTextBox.Name = "LogTextBox";
			this.LogTextBox.ReadOnly = true;
			this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.LogTextBox.Size = new System.Drawing.Size(500, 300);
			this.LogTextBox.TabIndex = 20;
			this.LogTextBox.Text = "项目地址 https://github.com/Fegelein21/ConvertToUTF8BOM\r\n\r\n本工具用于将指定编码和格式的文件统统转换为UTF-8" +
    "-BOM编码\r\n把需要处理的文件或文件夹拖入此窗口即可\r\n文件的输出名称为“原文件名称 (n)”\r\n文件夹的输出名称为“原文件夹名称 (Converted)”\r" +
    "\n\r\n";
			// 
			// EncodingCheckedListBox
			// 
			this.EncodingCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.EncodingCheckedListBox.CheckOnClick = true;
			this.EncodingCheckedListBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.EncodingCheckedListBox.FormattingEnabled = true;
			this.EncodingCheckedListBox.HorizontalScrollbar = true;
			this.EncodingCheckedListBox.Location = new System.Drawing.Point(15, 201);
			this.EncodingCheckedListBox.Name = "EncodingCheckedListBox";
			this.EncodingCheckedListBox.Size = new System.Drawing.Size(169, 148);
			this.EncodingCheckedListBox.Sorted = true;
			this.EncodingCheckedListBox.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(12, 155);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 14);
			this.label1.TabIndex = 16;
			this.label1.Text = "文件编码";
			// 
			// EmptyFileCheckBox
			// 
			this.EmptyFileCheckBox.AutoSize = true;
			this.EmptyFileCheckBox.Checked = true;
			this.EmptyFileCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.EmptyFileCheckBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.EmptyFileCheckBox.Location = new System.Drawing.Point(15, 37);
			this.EmptyFileCheckBox.Name = "EmptyFileCheckBox";
			this.EmptyFileCheckBox.Size = new System.Drawing.Size(96, 18);
			this.EmptyFileCheckBox.TabIndex = 1;
			this.EmptyFileCheckBox.Text = "处理空文件";
			this.EmptyFileCheckBox.UseVisualStyleBackColor = true;
			// 
			// AddEncodingTextBox
			// 
			this.AddEncodingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddEncodingTextBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.AddEncodingTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
			this.AddEncodingTextBox.Location = new System.Drawing.Point(15, 172);
			this.AddEncodingTextBox.Name = "AddEncodingTextBox";
			this.AddEncodingTextBox.Size = new System.Drawing.Size(169, 23);
			this.AddEncodingTextBox.TabIndex = 12;
			this.AddEncodingTextBox.Enter += new System.EventHandler(this.AddEncodingTextBox_Enter);
			this.AddEncodingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddEncodingTextBox_KeyPress);
			this.AddEncodingTextBox.Leave += new System.EventHandler(this.AddEncodingTextBox_Leave);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(714, 361);
			this.Controls.Add(this.AddEncodingTextBox);
			this.Controls.Add(this.EmptyFileCheckBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EncodingCheckedListBox);
			this.Controls.Add(this.LogTextBox);
			this.Controls.Add(this.label);
			this.Controls.Add(this.FileExtTextBox);
			this.Controls.Add(this.CopyFileCheckBox);
			this.Controls.Add(this.SubFolderCheckBox);
			this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "Convert To UTF-8-BOM";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox SubFolderCheckBox;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.CheckBox CopyFileCheckBox;
		private System.Windows.Forms.TextBox FileExtTextBox;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.TextBox LogTextBox;
		private System.Windows.Forms.CheckedListBox EncodingCheckedListBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox EmptyFileCheckBox;
		private System.Windows.Forms.TextBox AddEncodingTextBox;
	}
}

