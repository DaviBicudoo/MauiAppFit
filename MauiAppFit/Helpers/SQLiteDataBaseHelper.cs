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

        public Task<List<Activity>> GetAllRows()
        {
            return _dbConnection.Table<Activity>().OrderByDescending(i => i.ID).ToListAsync();
        }

        public Task<Activity> GetById(int id)
        {
            return _dbConnection.Table<Activity>().FirstAsync(i => i.ID == id);
        }

        public Task<int> Insert(Activity model)
        {
            return _dbConnection.InsertAsync(model); 
        }

        public Task<List<Activity>> Update(Activity model)
        {
            string SQL = "UPDATE Activity SET Description=?, Date=?, Weight=?, Observations=? WHERE ID=?";

            return _dbConnection.QueryAsync<Activity>(
                SQL,
                model.Description,
                model.Date,
                model.Weight,
                model.Observations,
                model.ID);
        }

        public Task<int> Delete(int ID)
        {
            return _dbConnection.Table<Activity>().DeleteAsync(i => i.ID == ID);
        }

         public Task<List<Activity>> Search(string query)
         {
            string SQL = $"SELECT * FROM Activity WHERE Description LIKE '%{query}'";

            return _dbConnection.QueryAsync<Activity>(query);
         }
    }
}
