﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Access.Dao;

namespace Lib32
{
    public class DaoClass32
    {
        public void RunDao()
        {
            var en = new DBEngine();
            var db = en.OpenDatabase("Db.accdb");
            db.Close();
            MessageBox.Show("DB OK");
        }
    }
}
