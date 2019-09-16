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
        public string outputFolder;
        private Texture currentPrev = null;
        public mainForm()
        {
            InitializeComponent();
        }

        private void setOutputDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = this.folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                outputFolder = this.folderBrowserDialog1.SelectedPath;
                this.convertAllButton.Enabled = true;
                this.convertSelectedButton.Enabled = true;
            }
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
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.listBox1.SelectedItem == null) // Don't handle nothing.
                    return;

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

                this.textureInfoBox.Text = "Version: " + this.currentPrev.version.ToString() + " / " + this.currentPrev.width.ToString() + "x" + this.currentPrev.height.ToString() + " / " + alpha;

                GC.Collect();
            }
            catch (Exception ex)
            {
                this.statusLabel.Text = "Error";
                this.textureInfoBox.Text = ex.ToString();
            }
        }

        private void saveFile(Bitmap bmp, string filename, string format)
        {
            switch (format)
            {
                case ".jpg":
                    bmp.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    bmp.Save(filename, ImageFormat.Png);
                    break;
                case ".tga":
                    TGA targa = new TGA(bmp);
                    targa.SaveAsTarga(filename, bmp.PixelFormat);
                    targa.Dispose();
                    break;
                case ".tif":
                    bmp.Save(filename, ImageFormat.Tiff);
                    break;
                case ".bmp":
                    bmp.Save(filename, ImageFormat.Bmp);
                    break;
                default:
                    this.statusLabel.Text = "Error converting, unknown format!";
                    break;
            }
        }

        private void convertAllButton_Click(object sender, EventArgs e)
        {
            string format = this.outputFormat.SelectedItem.ToString();

            foreach (string filename in this.listBox1.Items)
            {
                Texture tex = new Texture(filename);
                string newfilename = outputFolder + "/" + Path.GetFileNameWithoutExtension(filename) + format;

                saveFile(tex.image, newfilename, format);

                tex.Dispose();
            }
            
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(this.pictureBox1.Image);
            this.statusLabel.Text = "Copied.";
        }

        private void convertSelectedButton_Click(object sender, EventArgs e)
        {
            string format   = this.outputFormat.SelectedItem.ToString();
            string filename = this.listBox1.SelectedItem.ToString();
            string newfilename = outputFolder + "/" + Path.GetFileNameWithoutExtension(filename) + format;

            saveFile(this.currentPrev.image, newfilename, format);
        }

        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
                e.Effect = DragDropEffects.Copy;
        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < filenames.Length; i++)
                if (Path.GetExtension(filenames[i]) == ".tex")
                    this.listBox1.Items.Add(filenames[i]);
        }
    }
}
