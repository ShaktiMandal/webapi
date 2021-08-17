using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bankingManagementApi.Model;

namespace BankManagementApi.Repositories
{
    public interface IItemRepositories
    {
        Task<List<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(Guid id);
        Task AddItemAsync(Item item);
        Task<bool> UpdateItemAsync(Item item);
        Task<bool> RemoveItemAsync(Guid id);
    }
}