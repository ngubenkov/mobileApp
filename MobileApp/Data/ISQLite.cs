using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
