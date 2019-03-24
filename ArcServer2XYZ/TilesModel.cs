using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapCacheArcServer2XYZ
{
    [Serializable]
    public class TilesModel
    {
        public TilesModel()
		{ }
        #region Model
        private string _zoom_level;

        public string Zoom_level
        {
            get { return _zoom_level; }
            set { _zoom_level = value; }
        }
        private string _tile_row;

        public string Tile_row
        {
            get { return _tile_row; }
            set { _tile_row = value; }
        }
        private string _tile_column;

        public string Tile_column
        {
            get { return _tile_column; }
            set { _tile_column = value; }
        }
        private Byte[] _tile_data;

        public Byte[] Tile_data
        {
            get { return _tile_data; }
            set { _tile_data = value; }
        }

        
        #endregion
    }
}
