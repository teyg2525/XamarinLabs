using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace labs.Database
{
    public interface ITaskModelRepository
    {
        Task<int> DeleteItemAsync(TaskModel item);

        Task<List<TaskModel>> GetItemsAsync();

        Task<TaskModel> GetAsync(int id);
        
        Task<int> SaveItemAsync(TaskModel item);
    }
}
