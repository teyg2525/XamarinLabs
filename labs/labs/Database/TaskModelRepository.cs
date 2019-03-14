using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace labs.Database
{
    public class TaskModelRepository : ITaskModelRepository
    {
        public readonly SQLiteAsyncConnection _database;

        public TaskModelRepository()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                App.DATABASE_NAME);

            _database = new SQLiteAsyncConnection(path);

            _database.CreateTableAsync<TaskModel>().Wait();
        }

        public Task<int> DeleteItemAsync(TaskModel item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<List<TaskModel>> GetItemsAsync()
        {
            return _database.Table<TaskModel>().ToListAsync();
        }

        public Task<TaskModel> GetAsync(int id)
        {
            return _database.GetAsync<TaskModel>(id);
        }

        public async Task<int> SaveItemAsync(TaskModel item)
        {
            if(item.Id != 0)
            {
                await _database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await _database.InsertAsync(item);
            }
        }
    }
}
