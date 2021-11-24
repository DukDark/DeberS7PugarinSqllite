using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DeberS7PugarinSqllite
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();

    }
}
