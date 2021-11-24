using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeberS7PugarinSqllite.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
[assembly:Xamarin.Forms.Dependency(typeof(SqlClient))]

namespace DeberS7PugarinSqllite.Droid
{
    class SqlClient : DataBase
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPatch = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPatch, "uisrael.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}