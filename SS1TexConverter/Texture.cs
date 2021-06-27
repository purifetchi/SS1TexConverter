using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace SS1TexConverter
{
    class Texture : IDisposable
    {
        public Texture()
        {
        }

        public Texture(string filename)
        {
            this.fromFile(filename);
        }

        public short version;
        public Bitmap image;
        
        public int height, width;
        public int mipLevels;

        public PixelFormat imageFormat = PixelFormat.Format32bppArgb;

        public bool hasAlpha = true;

        private int frameOffset;

        private int getFirstMipLevel(byte[] data)
        {
            if (this.version == 4)
            {
                return BitConverter.ToInt32(new byte[] { data[0x1C], data[0x1D], data[0x1E], data[0x1F] }, 0);
            }
            else
            {
                return BitConverter.ToInt32(new byte[] { data[0x20], data[0x21], data[0x22], data[0x23] }, 0);
            }
        }

        public void fromFile(string filename)
        {
            byte[] data = File.ReadAllBytes(filename);

            this.version = Convert.ToInt16(data[0x4]);
            if (this.version != 4 && this.version != 3)
            {
                throw new NotSupportedException("The texture version must be either 3 or 4.");
            }

            this.frameOffset = this.version == 4 ? 0x28 : 0x30;

            int realWidth  = BitConverter.ToInt32(new byte[] { data[0x10], data[0x11], data[0x12], data[0x13] }, 0);
            int realHeight = BitConverter.ToInt32(new byte[] { data[0x14], data[0x15], data[0x16], data[0x17] }, 0);
            this.mipLevels = BitConverter.ToInt32(new byte[] { data[0x18], data[0x19], data[0x1A], data[0x1B] }, 0);
            short depthflag = Convert.ToInt16(data[0xC]);

            short bitdepth = 4;

            if ((depthflag == 0) || (depthflag == 2))
            {
                bitdepth = 3;
                this.imageFormat = PixelFormat.Format24bppRgb;
                this.hasAlpha = false;
            }

            if (this.version == 3) // Version 3 always uses 16-bit RGBA
            {
                bitdepth = 2;
            }

            int firstMipLevel = getFirstMipLevel(data);

            short firstMipTexOffset = (short)Math.Pow(2, firstMipLevel);

            this.width = realWidth / firstMipTexOffset;
            this.height = realHeight / firstMipTexOffset;

            this.image = new Bitmap(this.width, this.height, this.imageFormat);

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
            for (int y = 0; y < this.height; y++)
                for (int x = 0; x < this.width; x++)
                {
                    int[] colordata = { 0, 0, 0, 0 };

                    if (bitdepth == 3) // RGB888 | 24bit RGB without alpha
                    {
                        for (int z = upper; z >= lower; z += step)
                            colordata[z] = Convert.ToInt32(data[this.frameOffset + pos + z]);

                        this.image.SetPixel(x, y, Color.FromArgb(colordata[0], colordata[1], colordata[2]));
                    }
                    else if (bitdepth == 4) // RGBA8888 | 32bit RGB with 8-bit alpha
                    {
                        for (int z = upper; z <= lower; z += step)
                            colordata[z] = Convert.ToInt32(data[this.frameOffset + pos + z]);

                        this.image.SetPixel(x, y, Color.FromArgb(colordata[3], colordata[0], colordata[1], colordata[2]));
                    }
                    else // Version 3 handles colors differently. Rather than splitting every channel into 8 bits / 1 byte, it uses either RGBA4444 or RGBA5551 which need to be decoded separately.
                    {
                        int pixel = data[this.frameOffset + pos + 0] | (data[this.frameOffset + pos + 1] << 8);

                        int r, g, b, a;

                        if (this.hasAlpha)
                        {
                            r = (pixel & 0xF000) >> 8;
                            g = (pixel & 0x0F00) >> 4;
                            b = (pixel & 0x00F0) >> 0;
                            a = (pixel & 0x000F) << 4;

                            r |= r >> 4; g |= g >> 4; b |= b >> 4; a |= a >> 4;
                            this.image.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                        }
                        else
                        {
                            r = (pixel & 0xF800) >> 8;
                            g = (pixel & 0x07C0) >> 3;
                            b = (pixel & 0x003E) << 2;

                            r |= r >> 5; g |= g >> 5; b |= b >> 5;
                            this.image.SetPixel(x, y, Color.FromArgb(r, g, b));
                        }
                    }
                    pos += bitdepth;
                }
        }

        public void Dispose()
        {
            this.image.Dispose();
            GC.Collect();
        }
    }
}
