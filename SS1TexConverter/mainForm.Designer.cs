namespace SS1TexConverter
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.inputListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertAllButton = new System.Windows.Forms.Button();
            this.copyToClipboard = new System.Windows.Forms.Button();
            this.convertSelectedButton = new System.Windows.Forms.Button();
            this.useFileFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.outputFolderChooseButton = new System.Windows.Forms.Button();
            this.outputFolderLabel = new System.Windows.Forms.Label();
            this.outputFolderCurrentSelectedLabel = new System.Windows.Forms.Label();
            this.outputFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.formatLabel = new System.Windows.Forms.Label();
            this.formatComboBox = new System.Windows.Forms.ComboBox();
            this.textureInfoLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.forceOverwritingCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.inputListContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(622, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(627, 420);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ContextMenuStrip = this.inputListContextMenuStrip;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(600, 610);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // inputListContextMenuStrip
            // 
            this.inputListContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.inputListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeSelectedToolStripMenuItem,
            this.closeAllToolStripMenuItem});
            this.inputListContextMenuStrip.Name = "inputListContextMenuStrip";
            this.inputListContextMenuStrip.Size = new System.Drawing.Size(174, 52);
            // 
            // closeSelectedToolStripMenuItem
            // 
            this.closeSelectedToolStripMenuItem.Name = "closeSelectedToolStripMenuItem";
            this.closeSelectedToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.closeSelectedToolStripMenuItem.Text = "Close selected";
            this.closeSelectedToolStripMenuItem.Click += new System.EventHandler(this.closeSelectedToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.closeAllToolStripMenuItem.Text = "Close all";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.closeAllToolStripMenuItem_Click);
            // 
            // convertAllButton
            // 
            this.convertAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertAllButton.Enabled = false;
            this.convertAllButton.Location = new System.Drawing.Point(627, 564);
            this.convertAllButton.Margin = new System.Windows.Forms.Padding(4);
            this.convertAllButton.Name = "convertAllButton";
            this.convertAllButton.Size = new System.Drawing.Size(622, 28);
            this.convertAllButton.TabIndex = 5;
            this.convertAllButton.Text = "Convert All";
            this.convertAllButton.UseVisualStyleBackColor = true;
            this.convertAllButton.Click += new System.EventHandler(this.convertAllButton_Click);
            // 
            // copyToClipboard
            // 
            this.copyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyToClipboard.Enabled = false;
            this.copyToClipboard.Location = new System.Drawing.Point(973, 600);
            this.copyToClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.copyToClipboard.Name = "copyToClipboard";
            this.copyToClipboard.Size = new System.Drawing.Size(276, 28);
            this.copyToClipboard.TabIndex = 6;
            this.copyToClipboard.Text = "Selected to Clipboard";
            this.copyToClipboard.UseVisualStyleBackColor = true;
            this.copyToClipboard.Click += new System.EventHandler(this.copyToClipboard_Click);
            // 
            // convertSelectedButton
            // 
            this.convertSelectedButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertSelectedButton.Enabled = false;
            this.convertSelectedButton.Location = new System.Drawing.Point(627, 600);
            this.convertSelectedButton.Margin = new System.Windows.Forms.Padding(4);
            this.convertSelectedButton.Name = "convertSelectedButton";
            this.convertSelectedButton.Size = new System.Drawing.Size(338, 28);
            this.convertSelectedButton.TabIndex = 7;
            this.convertSelectedButton.Text = "Convert Selected";
            this.convertSelectedButton.UseVisualStyleBackColor = true;
            this.convertSelectedButton.Click += new System.EventHandler(this.convertSelectedButton_Click);
            // 
            // useFileFolderCheckBox
            // 
            this.useFileFolderCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.useFileFolderCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.useFileFolderCheckBox.Checked = true;
            this.useFileFolderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useFileFolderCheckBox.Location = new System.Drawing.Point(623, 441);
            this.useFileFolderCheckBox.Name = "useFileFolderCheckBox";
            this.useFileFolderCheckBox.Size = new System.Drawing.Size(627, 21);
            this.useFileFolderCheckBox.TabIndex = 9;
            this.useFileFolderCheckBox.Text = "Use source file folder as output folder";
            this.useFileFolderCheckBox.UseVisualStyleBackColor = true;
            this.useFileFolderCheckBox.CheckedChanged += new System.EventHandler(this.useFileFolderCheckBox_CheckedChanged);
            // 
            // outputFolderChooseButton
            // 
            this.outputFolderChooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFolderChooseButton.Enabled = false;
            this.outputFolderChooseButton.Location = new System.Drawing.Point(1150, 468);
            this.outputFolderChooseButton.Name = "outputFolderChooseButton";
            this.outputFolderChooseButton.Size = new System.Drawing.Size(100, 23);
            this.outputFolderChooseButton.TabIndex = 10;
            this.outputFolderChooseButton.Text = "Browse";
            this.outputFolderChooseButton.UseVisualStyleBackColor = true;
            this.outputFolderChooseButton.Click += new System.EventHandler(this.outputFolderChooseButton_Click);
            // 
            // outputFolderLabel
            // 
            this.outputFolderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.outputFolderLabel.Enabled = false;
            this.outputFolderLabel.Location = new System.Drawing.Point(624, 468);
            this.outputFolderLabel.Name = "outputFolderLabel";
            this.outputFolderLabel.Size = new System.Drawing.Size(151, 23);
            this.outputFolderLabel.TabIndex = 9;
            this.outputFolderLabel.Text = "Custom output folder";
            this.outputFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outputFolderCurrentSelectedLabel
            // 
            this.outputFolderCurrentSelectedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFolderCurrentSelectedLabel.AutoEllipsis = true;
            this.outputFolderCurrentSelectedLabel.BackColor = System.Drawing.SystemColors.Control;
            this.outputFolderCurrentSelectedLabel.Enabled = false;
            this.outputFolderCurrentSelectedLabel.Location = new System.Drawing.Point(827, 468);
            this.outputFolderCurrentSelectedLabel.Name = "outputFolderCurrentSelectedLabel";
            this.outputFolderCurrentSelectedLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.outputFolderCurrentSelectedLabel.Size = new System.Drawing.Size(317, 23);
            this.outputFolderCurrentSelectedLabel.TabIndex = 12;
            this.outputFolderCurrentSelectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // formatLabel
            // 
            this.formatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formatLabel.Location = new System.Drawing.Point(624, 497);
            this.formatLabel.Name = "formatLabel";
            this.formatLabel.Size = new System.Drawing.Size(274, 23);
            this.formatLabel.TabIndex = 13;
            this.formatLabel.Text = "Output format";
            this.formatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // formatComboBox
            // 
            this.formatComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatComboBox.FormattingEnabled = true;
            this.formatComboBox.Location = new System.Drawing.Point(1150, 497);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(99, 24);
            this.formatComboBox.TabIndex = 14;
            // 
            // textureInfoLabel
            // 
            this.textureInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textureInfoLabel.AutoEllipsis = true;
            this.textureInfoLabel.Location = new System.Drawing.Point(973, 644);
            this.textureInfoLabel.Name = "textureInfoLabel";
            this.textureInfoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textureInfoLabel.Size = new System.Drawing.Size(277, 19);
            this.textureInfoLabel.TabIndex = 15;
            this.textureInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoEllipsis = true;
            this.statusLabel.Location = new System.Drawing.Point(13, 644);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(952, 19);
            this.statusLabel.TabIndex = 17;
            this.statusLabel.Text = "Drop folders or files to convert ";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // forceOverwritingCheckBox
            // 
            this.forceOverwritingCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.forceOverwritingCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.forceOverwritingCheckBox.Location = new System.Drawing.Point(623, 526);
            this.forceOverwritingCheckBox.Name = "forceOverwritingCheckBox";
            this.forceOverwritingCheckBox.Size = new System.Drawing.Size(627, 21);
            this.forceOverwritingCheckBox.TabIndex = 18;
            this.forceOverwritingCheckBox.Text = "Force overwriting existing files";
            this.forceOverwritingCheckBox.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.forceOverwritingCheckBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.textureInfoLabel);
            this.Controls.Add(this.formatComboBox);
            this.Controls.Add(this.formatLabel);
            this.Controls.Add(this.outputFolderCurrentSelectedLabel);
            this.Controls.Add(this.outputFolderLabel);
            this.Controls.Add(this.outputFolderChooseButton);
            this.Controls.Add(this.useFileFolderCheckBox);
            this.Controls.Add(this.convertSelectedButton);
            this.Controls.Add(this.copyToClipboard);
            this.Controls.Add(this.convertAllButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 560);
            this.Name = "mainForm";
            this.Text = "Serious Engine 1 .tex Converter";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainForm_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.inputListContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button convertAllButton;
        private System.Windows.Forms.Button copyToClipboard;
        private System.Windows.Forms.Button convertSelectedButton;
        private System.Windows.Forms.CheckBox useFileFolderCheckBox;
        private System.Windows.Forms.Button outputFolderChooseButton;
        private System.Windows.Forms.Label outputFolderLabel;
        private System.Windows.Forms.Label outputFolderCurrentSelectedLabel;
        private System.Windows.Forms.FolderBrowserDialog outputFolderBrowserDialog;
        private System.Windows.Forms.Label formatLabel;
        private System.Windows.Forms.ComboBox formatComboBox;
        private System.Windows.Forms.Label textureInfoLabel;
        private System.Windows.Forms.ContextMenuStrip inputListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeSelectedToolStripMenuItem;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.CheckBox forceOverwritingCheckBox;
    }
}

