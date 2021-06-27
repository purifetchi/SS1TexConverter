using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Text;

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

        private Texture currentlyShownTexture;

        private bool useFileFolderAsOutputFodler;
        private string userOutputFolder;

        private HashSet<string> listBoxUniqueStrings;

        public mainForm()
        {
            listBoxUniqueStrings = new HashSet<string>();

            InitializeComponent();
            UpdateFileFolderSettings();

            formatComboBox.Items.AddRange(OutputFormats);
            formatComboBox.SelectedItem = DefaultOutputFormat;

            userOutputFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            outputFolderCurrentSelectedLabel.Text = userOutputFolder;
        }

        private void UpdateFileFolderSettings()
        {
            useFileFolderAsOutputFodler = useFileFolderCheckBox.Checked;

            outputFolderLabel.Enabled = !useFileFolderAsOutputFodler;
            outputFolderCurrentSelectedLabel.Enabled = !useFileFolderAsOutputFodler;
            outputFolderChooseButton.Enabled = !useFileFolderAsOutputFodler;
        }
        public string GetOutputFolder(string filepath)
        {
            string folder = useFileFolderAsOutputFodler ?
                Path.GetDirectoryName(filepath) :
                userOutputFolder;

            if (!Directory.Exists(folder))
            {
                throw new Exception("Folder \"" + folder + "\" doesn't exist.");
            }

            return folder;
        }

        private void ShowStatus(string s)
        {
            statusLabel.Text = s;
        }

        private void ShowDone(string baseText, ICollection<string> fails)
        {
            StringBuilder str = new StringBuilder();
            str.Append(baseText);

            int badCount = fails.Count;

            if (badCount > 0)
            {
                str.Append(". ");
                str.Append(badCount);
                str.Append(badCount == 1 ? " fail" : " fails");
                str.Append(" (hover the mouse over to see details)\n");

                foreach (var f in fails)
                {
                    str.Append("    ");
                    str.Append(f);
                    str.Append("\n");
                }
            }

            ShowStatus(str.ToString());
        }

        private void ShowTextureInfo(string s)
        {
            textureInfoLabel.Text = s;
        }

        private void ShowException(Exception ex)
        {
            ShowStatus("Error: " + ex.Message);
            ShowTextureInfo("");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0 || listBox1.SelectedItem == null)
            {
                convertSelectedButton.Enabled = false;
                return;
            }

            string filename = listBox1.SelectedItem.ToString();

            try
            {
                if (currentlyShownTexture != null)
                {
                    currentlyShownTexture.Dispose();
                }

                currentlyShownTexture = new Texture();
                currentlyShownTexture.FromFile(filename);
                pictureBox1.Image = currentlyShownTexture.Image;

                copyToClipboard.Enabled = true;
                convertSelectedButton.Enabled = true;

                ShowStatus("Selected " + Path.GetFileName(filename));
                ShowTextureInfo(currentlyShownTexture.InfoText);
            }
            catch
            {
                currentlyShownTexture = null;
                pictureBox1.Image = null;

                copyToClipboard.Enabled = false;
                convertSelectedButton.Enabled = false;

                ShowException(new Exception("Can't parse \"" + filename + "\" texture"));
            }
        }

        private void SaveFile(Bitmap bmp, string filename, string format)
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

        private void ConvertTexture(string format, string filename)
        {
            using (Texture tex = new Texture())
            { 
                try
                {
                    tex.FromFile(filename);
                }
                catch
                {
                    throw new Exception("Can't parse texture");
                }

                string name = Path.GetFileNameWithoutExtension(filename);
                string newFile = GetOutputFolder(filename) + "/" + name + format;

                // if file already exists, and overwriting is not forced
                if (File.Exists(newFile) && !forceOverwritingCheckBox.Checked)
                {
                    string msg = "File with the path \"" + newFile + "\" already exists. Overwrite it?";
                    DialogResult dialogResult = MessageBox.Show(msg, "Overwrite file", MessageBoxButtons.YesNo);

                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }

                SaveFile(tex.Image, newFile, format);
            }
        }

        private void convertAllButton_Click(object sender, EventArgs e)
        {
            string format = formatComboBox.SelectedItem.ToString();

            List<string> fails = new List<string>();

            foreach (string filename in listBox1.Items)
            {
                try
                {
                    ConvertTexture(format, filename);
                }
                catch (Exception ex)
                {
                    fails.Add(filename + ": " + ex.Message);
                }
            }

            ShowDone("Done converting all", fails);
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
                ShowStatus("Copied to clipboard");
            }
            else
            {
                ShowStatus("Nothing to copy to clipboard");
            }
        }

        private void convertSelectedButton_Click(object sender, EventArgs e)
        {
            string format = formatComboBox.SelectedItem.ToString();

            List<string> fails = new List<string>();

            foreach (string filename in listBox1.SelectedItems)
            {
                try
                {
                    ConvertTexture(format, filename);
                }
                catch (Exception ex)
                {
                    fails.Add(filename + ": " + ex.Message);
                }
            }

            ShowDone("Done converting selected", fails);
        }

        private void mainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private bool TryToAddToListBox(string p)
        {
            // maintain only unique paths
            if (!listBoxUniqueStrings.Contains(p))
            {
                listBox1.Items.Add(p);

                listBoxUniqueStrings.Add(p);
                return true;
            }

            ShowStatus("File \"" + p + "\" was already added");
            return false;
        }

        private void RemoveAllFromListBox()
        {
            listBox1.Items.Clear();
            listBoxUniqueStrings.Clear();
        }
        private void RemoveSelectedFromListBox()
        {
            var toRemove = new List<string>(listBox1.SelectedItems.Count);

            foreach (string s in listBox1.SelectedItems)
            {
                toRemove.Add(s);
            }

            foreach (string s in toRemove)
            {
                listBox1.Items.Remove(s);
                listBoxUniqueStrings.Remove(s);
            }
        }

        private void mainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
           
            foreach (string n in filenames)
            {
                // if it's a directory, then process all files in it
                if (Directory.Exists(n))
                {
                    string[] files = Directory.GetFiles(n, "*.tex", SearchOption.AllDirectories);

                    foreach (var f in files)
                    {
                        TryToAddToListBox(f);
                    }
                }
                else if (Path.GetExtension(n) == ".tex")
                {
                    TryToAddToListBox(n);
                }
            }

            convertAllButton.Enabled = listBox1.Items.Count > 0;
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
                userOutputFolder = outputFolderBrowserDialog.SelectedPath;

                outputFolderCurrentSelectedLabel.Text = userOutputFolder;
            }
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllFromListBox();
        }

        private void closeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveSelectedFromListBox();
        }
    }
}
