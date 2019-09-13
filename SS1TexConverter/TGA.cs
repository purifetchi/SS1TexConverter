using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace SS1TexConverter
{
    class TGA
    {
        private Bitmap image;

        public TGA(Image input)
        {
            this.image = new Bitmap(input);
        }

        public void SaveAsTarga(string filename, PixelFormat format)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                // TGA HEADER
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x2); // UNCOMPRESSED TGA
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)0x0);
                writer.Write((char)(image.Width & 0x00FF));          // LOWER WIDTH  BYTES
                writer.Write((char)((image.Width & 0xFF00) / 256));  // UPPER WIDTH  BYTES
                writer.Write((char)(image.Height & 0x00FF));         // LOWER HEIGHT BYTES
                writer.Write((char)((image.Height & 0xFF00) / 256)); // UPPER HEIGHT BYTES

                if (format == PixelFormat.Format24bppRgb) // 24BPP RGB
                {
                    writer.Write((char)0x18);
                }
                else //32BPP ARGB
                {
                    writer.Write((char)0x20);
                }

                writer.Write((char)0x0);

                for (int y = image.Height-1; y > -1; y--)
                    for (int x = 0; x < image.Width; x++)
                    {
                        Color col = this.image.GetPixel(x, y);
                        if (format == PixelFormat.Format24bppRgb)
                        {
                            writer.Write(col.B);
                            writer.Write(col.G);
                            writer.Write(col.R);
                        }
                        else
                        {
                            writer.Write(col.B);
                            writer.Write(col.G);
                            writer.Write(col.R);
                            writer.Write(col.A);
                        }
                    }
            }
        }

        public void Dispose()
        {
            this.image.Dispose();
        }
    }
}
