using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace SS1TexConverter
{
    public partial class mainForm : Form
    {
        public string outputFolder;
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
                this.copyToClipboard.Enabled = true;
                this.pictureBox1.Image = convertTexToImage(this.listBox1.SelectedItem.ToString());
            }
            catch
            {
                this.statusLabel.Text = "Error";
            }
        }

        private Bitmap convertTexToImage(string filename)
        {
            this.statusLabel.Text = "Working...";
            byte[] data = File.ReadAllBytes(filename);

            int width = Convert.ToInt32(data[0x13]) * 0x400 + Convert.ToInt32(data[0x12]) * 0x200 + Convert.ToInt32(data[0x11]) * 0x100 + Convert.ToInt32(data[0x10]);
            int height = Convert.ToInt32(data[0x17]) * 0x400 + Convert.ToInt32(data[0x16]) * 0x200 + Convert.ToInt32(data[0x15]) * 0x100 + Convert.ToInt32(data[0x14]);
            int mystery = Convert.ToInt32(data[0x1F]) * 0x400 + Convert.ToInt32(data[0x1E]) * 0x200 + Convert.ToInt32(data[0x1D]) * 0x100 + Convert.ToInt32(data[0x1C]);
            short depthflag = Convert.ToInt16(data[0xC]);

            short bitdepth = 4;

            if ((depthflag == 0) || (depthflag == 2))
            {
                bitdepth = 3;
            }

            short mystery_counter = 1;

            for (int i = 1; i < mystery+1; i++)
            {
                mystery_counter = (short)(mystery_counter * 2);
            }

            width = Convert.ToInt32(Convert.ToDouble(width) / Convert.ToDouble(mystery_counter));
            height = Convert.ToInt32(Convert.ToDouble(height) / Convert.ToDouble(mystery_counter));

            PixelFormat format = PixelFormat.Format32bppArgb;

            if (bitdepth == 3)
            {
                format = PixelFormat.Format24bppRgb;
            }

            Bitmap bmp = new Bitmap(width, height, format);

            int upper = 0;
            int lower = 3;
            int step = 1;

            if (bitdepth == 3)
            {
                upper = 3;
                lower = 0;
                step = -1;
            }

            int pos = 0;
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int[] colordata = { 0, 0, 0, 0 };

                    if (bitdepth == 3)
                    {
                        for (int z = upper; z >= lower; z += step)
                            colordata[z] = Convert.ToInt32(data[0x28 + pos + z]);

                        bmp.SetPixel(x, y, Color.FromArgb(colordata[0], colordata[1], colordata[2]));
                    }
                    else
                    {
                        for (int z = upper; z <= lower; z += step)
                            colordata[z] = Convert.ToInt32(data[0x28 + pos + z]);

                        bmp.SetPixel(x, y, Color.FromArgb(colordata[3], colordata[0], colordata[1], colordata[2]));
                    }

                    pos += bitdepth;
                }
            this.statusLabel.Text = "Done.";

            return bmp;
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
                Bitmap bmp = convertTexToImage(filename);
                string newfilename = outputFolder + "/" + Path.GetFileNameWithoutExtension(filename) + format;

                saveFile(bmp, newfilename, format);

                bmp.Dispose();
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

            Bitmap bmp = convertTexToImage(filename);
            saveFile(bmp, newfilename, format);
            
            bmp.Dispose();
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
