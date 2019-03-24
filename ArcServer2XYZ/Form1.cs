using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MapCacheArcServer2XYZ;
using System.IO;

namespace MapCacheArcServer2XYZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataSet ds = MapCacheArcServer2XYZ.TilesBLL.GetList(" tiles.zoom_level=4 and tiles.tile_row=6 and tiles.tile_column=12 ");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                byte[] pstream = (byte[])(ds.Tables[0].Rows[0][3]);
                //pictureBox1.Image = System.Drawing.Image.FromStream(new MemoryStream(pstream));
                //this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                // 如果保存成文件：
                File.WriteAllBytes(@"d:\4612.png", pstream);
            }
        }
    }
}
