using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MapCacheArcServer2XYZ
{
    public class TilesBLL
    {
        public TilesBLL()
        { }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(MapCacheArcServer2XYZ.TilesModel model)
        {
            return MapCacheArcServer2XYZ.TilesDAL.Add(model);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            return MapCacheArcServer2XYZ.TilesDAL.GetList(strWhere);
        }

    }
}
