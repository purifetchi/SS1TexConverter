﻿namespace SS1TexConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.convertAllButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
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
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(16, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(600, 610);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1262, 26);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(252, 20);
            this.statusLabel.Text = "Drop folders or files to the left panel";
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
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "tex Files (*.tex)|*.tex";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Files";
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
            this.useFileFolderCheckBox.Location = new System.Drawing.Point(622, 460);
            this.useFileFolderCheckBox.Name = "useFileFolderCheckBox";
            this.useFileFolderCheckBox.Size = new System.Drawing.Size(628, 21);
            this.useFileFolderCheckBox.TabIndex = 9;
            this.useFileFolderCheckBox.Text = "Use source file folder as output folder";
            this.useFileFolderCheckBox.UseVisualStyleBackColor = true;
            this.useFileFolderCheckBox.CheckedChanged += new System.EventHandler(this.useFileFolderCheckBox_CheckedChanged);
            // 
            // outputFolderChooseButton
            // 
            this.outputFolderChooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.outputFolderChooseButton.Enabled = false;
            this.outputFolderChooseButton.Location = new System.Drawing.Point(1150, 487);
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
            this.outputFolderLabel.Location = new System.Drawing.Point(624, 487);
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
            this.outputFolderCurrentSelectedLabel.Location = new System.Drawing.Point(775, 487);
            this.outputFolderCurrentSelectedLabel.Name = "outputFolderCurrentSelectedLabel";
            this.outputFolderCurrentSelectedLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.outputFolderCurrentSelectedLabel.Size = new System.Drawing.Size(369, 23);
            this.outputFolderCurrentSelectedLabel.TabIndex = 12;
            this.outputFolderCurrentSelectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // formatLabel
            // 
            this.formatLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.formatLabel.Location = new System.Drawing.Point(624, 516);
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
            this.formatComboBox.Location = new System.Drawing.Point(1150, 516);
            this.formatComboBox.Name = "formatComboBox";
            this.formatComboBox.Size = new System.Drawing.Size(99, 24);
            this.formatComboBox.TabIndex = 14;
            // 
            // textureInfoLabel
            // 
            this.textureInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textureInfoLabel.AutoEllipsis = true;
            this.textureInfoLabel.Location = new System.Drawing.Point(948, 648);
            this.textureInfoLabel.Name = "textureInfoLabel";
            this.textureInfoLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textureInfoLabel.Size = new System.Drawing.Size(314, 25);
            this.textureInfoLabel.TabIndex = 15;
            this.textureInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
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
            this.Controls.Add(this.statusStrip1);
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button convertAllButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
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
    }
}

