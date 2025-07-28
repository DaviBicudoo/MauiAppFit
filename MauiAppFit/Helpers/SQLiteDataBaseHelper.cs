using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MauiAppFit.Models;

namespace MauiAppFit.Helpers
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _dbConnection;

        public SQLiteDataBaseHelper(string dbPath)
        {
            _dbConnection = new SQLiteAsyncConnection(dbPath);
            _dbConnection.CreateTableAsync<Activity>().Wait();
        }
    }
}
