using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapCacheArcServer2XYZ
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArcGISServer切片转换成符合谷歌地图（高德地图）地图切片标准（Z/Y/X）
            Arc2XYZ();
            //测试图片流
            //Form1 f = new Form1();
            //f.Show();
            Console.WriteLine("转换完成,输入任意键结束！");
            Console.ReadLine();
        }

        /// <summary>
        /// 输入缓存路径
        /// </summary>
        /// <param name="mapCachePath"></param>
        public static void Arc2XYZ()
        {
            string path = "E:\\allyers";

            //创建新地图缓存文件夹
            DirectoryInfo dir = new DirectoryInfo(path.Substring(0, path.LastIndexOf("\\")));
            dir.CreateSubdirectory("NewMapCache");

            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();
            foreach (DirectoryInfo f in dics)
            {
                #region Z值转换
                //Console.WriteLine(f.Name.ToString());
                int z = Convert.ToInt32(f.Name.Replace("L", ""));
                DirectoryInfo zDir = new DirectoryInfo(path.Substring(0, path.LastIndexOf("\\")) + "\\NewMapCache");
                zDir.CreateSubdirectory(z.ToString());
                #endregion

                DirectoryInfo rroot = new DirectoryInfo(f.FullName.ToString());
                DirectoryInfo[] rdics = rroot.GetDirectories();
                foreach (DirectoryInfo rf in rdics)
                {
                    #region Y值转换
                    //Console.WriteLine(rf.FullName.ToString());
                    int y = Convert.ToInt32(rf.Name.Replace("R", "0x"), 16);
                    DirectoryInfo yDir = new DirectoryInfo(path.Substring(0, path.LastIndexOf("\\")) + "\\NewMapCache\\" + z.ToString());
                    yDir.CreateSubdirectory(y.ToString());
                    #endregion
                    DirectoryInfo croot = new DirectoryInfo(rf.FullName.ToString());
                    FileInfo[] files = croot.GetFiles();
                    foreach (FileInfo cf in files)
                    {
                        #region X值转换
                        byte[] bytes = File.ReadAllBytes(cf.FullName.ToString());
                        int x = Convert.ToInt32(Path.GetFileNameWithoutExtension(cf.FullName).Replace("C", "0x"), 16);
                        File.Copy(cf.FullName, (path.Substring(0, path.LastIndexOf("\\")) + "\\NewMapCache\\" + z.ToString() + "\\" + y.ToString() + "\\" + x.ToString() + ".png"));
                        //把png图片保存到Mbtiles文件
                        //Import2MbTiles(z, y, x, bytes);
                        Console.WriteLine(cf.FullName.ToString());
                        #endregion
                    }
                }

            }
        }

        //把png图片保存到Mbtiles文件
        private static void Import2MbTiles(int z, int y, int x, byte[] bytes)
        {
            MapCacheArcServer2XYZ.TilesModel tmodel = new TilesModel();
            tmodel.Zoom_level = z.ToString();
            tmodel.Tile_row = y.ToString();
            tmodel.Tile_column = x.ToString();
            tmodel.Tile_data = bytes;
            bool b = MapCacheArcServer2XYZ.TilesDAL.Add(tmodel);
        }
    }
}
