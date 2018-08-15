using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class GlobalIdCreator
    {
        public static int TmpID;
        public static string line = String.Empty;

        public static int CreateID()
        {
            if (TmpID == 0)
            {
                TmpID = 1;
            }

            TmpID++;

            return TmpID;
        }
        public static void GetIDFromSql(SQLiteCommand selectLustLine)
        {
            SQLiteDataReader reader = selectLustLine.ExecuteReader();
            while (reader.Read())
            {
                TmpID = Convert.ToInt32(reader["itemid"].ToString());
            }
        }
}
}
