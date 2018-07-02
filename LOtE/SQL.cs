using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOtE
{
    class SQL
    {
        static public SQLiteCommand СreateLineItme(int persid, int itemid, int slotid, int stuck, int strength, string damage, string typeofdamage, SQLiteConnection dbConnection)
        {
            string сommand = "INSERT INTO persitems (persid, itemid, slotid, stuck, strength, damage, typeofdamage) VALUES (" + persid + ", " + itemid + ", " + slotid + ", " + stuck + ", " + strength + ", '" + damage + "', '" + typeofdamage + "')";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand UpdateLineItme(int serialnumber, int persid, int itemid, int slotid, int stuck, int strength, string damage, string typeofdamage, SQLiteConnection dbConnection)
        {
            string сommand = "UPDATE persitems SET persid = " + persid + " WHERE serialnumber = " + serialnumber + "; UPDATE persitems SET itemid = " + itemid + " WHERE serialnumber = " + serialnumber + "; UPDATE persitems SET slotid = " + slotid + " WHERE serialnumber = " + serialnumber + "; UPDATE persitems SET stuck = " + stuck + " WHERE serialnumber = " + serialnumber + "; UPDATE persitems SET strength = " + strength + " WHERE serialnumber = " + serialnumber + "; UPDATE persitems SET damage = '" + damage + "' WHERE serialnumber = " + serialnumber + "; UPDATE persitems SET typeofdamage = '" + typeofdamage + "' WHERE serialnumber = " + serialnumber + ";";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand СreateLinePers(int id, string coordinates, string name, SQLiteConnection dbConnection)
        {
            string сommand = "INSERT INTO persinfo VALUES (" + id + ", '" + coordinates + "', '" + name + "')";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand UpdateLinePers(int id, string coordinates, string name, SQLiteConnection dbConnection)
        {
            string сommand = "UPDATE persinfo SET id = " + id + "; UPDATE persinfo SET coordinates = '" + coordinates + "'; UPDATE persinfo SET name = '" + name + "'";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand СreateLineItme(int serialnumber, int persid, int itemid, int slotid, int stuck, int strength, string damage, string typeofdamage, SQLiteConnection dbConnection)
        {
            string сommand = "INSERT INTO persitems VALUES (" + serialnumber + ", " + persid + ", " + itemid + ", " + slotid + ", " + stuck + ", " + strength + ", '" + damage + "', '" + typeofdamage + "')";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand SelectLineItme(string tabl, string colon, SQLiteConnection dbConnection)
        {
            string сommand = "SELECT * FROM '" + tabl + "'";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand SelectLineItme(string tabl, string row, string colon, int num, SQLiteConnection dbConnection)
        {
            string сommand = "SELECT " + row + " FROM '" + tabl + "' WHERE " + colon + " = " + num + "";

            return new SQLiteCommand(сommand, dbConnection);
        }
        static public SQLiteCommand DeleteLine(string tabl, string colon, int num, SQLiteConnection dbConnection)
        {
            string сommand = "DELETE FROM " + tabl + " WHERE " + colon + " = " + num + "";

            return new SQLiteCommand(сommand, dbConnection);
        }
    }
}
