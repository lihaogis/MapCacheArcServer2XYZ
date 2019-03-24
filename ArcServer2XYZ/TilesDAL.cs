using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace MapCacheArcServer2XYZ
{
    public class TilesDAL
    {
        public TilesDAL()
        { }

        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Add(MapCacheArcServer2XYZ.TilesModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into tiles(");
            strSql.Append("zoom_level,tile_row,tile_column,tile_data)");
            strSql.Append(" values (");
            strSql.Append("@zoom_level,@tile_row,@tile_column,@tile_data)");
            SQLiteParameter[] parameters = {
					new SQLiteParameter("@zoom_level", DbType.Int32),
					new SQLiteParameter("@tile_row", DbType.Int32),
					new SQLiteParameter("@tile_column", DbType.Int32),
					new SQLiteParameter("@tile_data", DbType.Binary)};
            parameters[0].Value = model.Zoom_level;
            parameters[1].Value = model.Tile_row;
            parameters[2].Value = model.Tile_column;
            parameters[3].Value = model.Tile_data;

            int rows = DbHelperSQLite.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select zoom_level,tile_row,tile_column,tile_data ");
            strSql.Append(" FROM tiles ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQLite.Query(strSql.ToString());
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
