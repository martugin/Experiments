using Microsoft.Office.Interop.Access.Dao;

namespace XmlProba
{
    public class DaoDb
    {
        private static DBEngine _en = new DBEngine();

        public static void RunDao(string file)
        {
            var en = new DBEngine();
            var db = en.OpenDatabase(file);
            var rec = db.OpenRecordset("CalcParams");
            rec.MoveFirst();
            while (!rec.EOF)
                rec.MoveNext();
            rec.Close();
        }
    }
}