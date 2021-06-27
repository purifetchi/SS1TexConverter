using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace SS1TexConverter
{
    public partial class mainForm : Form
    {
        private const string FormatPNG = ".png";
        private const string FormatTGA = ".tga";
        private const string FormatJPG = ".jpg";
        private const string FormatTIF = ".tif";
        private const string FormatBMP = ".bmp";

        private const string DefaultOutputFormat = FormatPNG;

        private static readonly string[] OutputFormats =
        {
            FormatPNG,
            FormatTGA,
            FormatJPG,
            FormatTIF,
            FormatBMP
        };

        public bool UseFileFolderAsOutputFodler;
        public string UserOutputFolder;

        private Texture currentPrev = null;

        public mainForm()
        {
            InitializeComponent();
            UpdateFileFolderSettings();

            this.formatComboBox.Items.AddRange(OutputFormats);
            this.formatComboBox.SelectedItem = DefaultOutputFormat;
        }

        private void UpdateFileFolderSettings()
        {
            UseFileFolderAsOutputFodler = useFileFolderCheckBox.Checked;

            outputFolderLabel.Enabled = !UseFileFolderAsOutputFodler;
            outputFolderCurrentSelectedLabel.Enabled = !UseFileFolderAsOutputFodler;
            outputFolderChooseButton.Enabled = !UseFileFolderAsOutputFodler;
        }
        public string GetOutputFolder(string filepath)
        {
            string folder = UseFileFolderAsOutputFodler ?
                Path.GetDirectoryName(filepath) :
                UserOutputFolder;

            if (!Directory.Exists(folder))
            {
                throw new Exception("Folder \"" + folder + "\" doesn't exist.");
            }

            return folder;
        }

        private void ShowException(Exception ex)
        {
            this.statusLabel.Text = "Error: " + ex.ToString();
            this.textureInfoLabel.Text = "";
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                foreach (string file in openFileDialog1.FileNames)
                {
                    this.listBox1.Items.Add(file);
                }
            }

            convertAllButton.Enabled = this.listBox1.Items.Count > 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.listBox1.SelectedItem == null) // Don't handle nothing.
                {
                    convertSelectedButton.Enabled = false;
                    return;
                }

                string filename = this.listBox1.SelectedItem.ToString();

                this.copyToClipboard.Enabled = true;
                if (this.currentPrev != null)
                {
                    this.currentPrev.Dispose();
                    this.currentPrev = null;
                }
                this.currentPrev = new Texture(filename);
                this.pictureBox1.Image = this.currentPrev.image;

                string alpha = this.currentPrev.hasAlpha ? "RGBA" : "RGB";

                this.textureInfoLabel.Text = "Version: " + this.currentPrev.version.ToString() + " / " + this.currentPrev.width.ToString() + "x" + this.currentPrev.height.ToString() + " / " + alpha;


                this.convertSelectedButton.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowException(ex);

                this.convertSelectedButton.Enabled = false;
            }
        }

        private void saveFile(Bitmap bmp, string filename, string format)
        {
            switch (format)
            {
                case FormatJPG:
                    bmp.Save(filename, ImageFormat.Jpeg);
                    break;
                case FormatPNG:
                    bmp.Save(filename, ImageFormat.Png);
                    break;
                case FormatTGA:
                    TGA targa = new TGA(bmp);
                    targa.SaveAsTarga(filename, bmp.PixelFormat);
                    targa.Dispose();
                    break;
                case FormatTIF:
                    bmp.Save(filename, ImageFormat.Tiff);
                    break;
                case FormatBMP:
                    bmp.Save(filename, ImageFormat.Bmp);
                    break;
                default:
                    throw new Exception("Unknown output format");
            }
        }

        private void convertAllButton_Click(object sender, EventArgs e)
        {
            string format = this.formatComboBox.SelectedItem.ToString();

            foreach (string filename in this.listBox1.Items)
            {
                using (Texture tex = new Texture(filename))
                {
                    try
                    {
                        string name = Path.GetFileNameWithoutExtension(filename);
                        string newFile = GetOutputFolder(filename) + "/" + name + format;

                        saveFile(tex.image, newFile, format);

                        this.statusLabel.Text = "Converted " + name;
                    }
                    catch (Exception ex)
                    {
                        ShowException(ex);
                    }
                }
            }
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(this.pictureBox1.Image);
            this.statusLabel.Text = "Copied";
        }

        private void convertSelectedButton_Click(object sender, EventArgs e)
        {
            try
            {
                string format   = this.formatComboBox.SelectedItem.ToString();
                string filename = this.listBox1.SelectedItem.ToString();
                string name = Path.GetFileNameWithoutExtension(filename);
                string newFile = GetOutputFolder(filename) + "/" + name + format;

                saveFile(this.currentPrev.image, newFile, format);

                this.statusLabel.Text = "Converted " + name;
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
           
            for (int i = 0; i < filenames.Length; i++)
            {
                if (Path.GetExtension(filenames[i]) == ".tex")
                {
                    this.listBox1.Items.Add(filenames[i]);
                }
            }

            convertAllButton.Enabled = this.listBox1.Items.Count > 0;
        }

        private void useFileFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFileFolderSettings();
        }

        private void outputFolderChooseButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = outputFolderBrowserDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                UserOutputFolder = outputFolderBrowserDialog.SelectedPath;

                outputFolderCurrentSelectedLabel.Text = UserOutputFolder;
            }
        }
    }
}
