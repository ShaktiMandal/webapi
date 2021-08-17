
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bankingManagementApi.Model;

namespace BankManagementApi.Repositories
{
    public class ItemRepositories : IItemRepositories
    {
        private readonly List<Item> items = new()
        {
            new Item()
            {
                Name = "Test",
                PhoneNumber = "7584854845",
                Address = "high street",
                Guid = Guid.NewGuid()

            },
            new Item()
            {
                Name = "Test1",
                PhoneNumber = "758484845",
                Address = "high street1",
                Guid = Guid.NewGuid()

            },
            new Item()
            {
                Name = "Test2",
                PhoneNumber = "75854845",
                Address = "high street2",
                Guid = Guid.NewGuid()

            }
        };

        public async Task<List<Item>> GetItemsAsync()
        {
            return await Task.FromResult(this.items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var result = this.items.FirstOrDefault(x => x != null && x.Guid.Equals(id));
            return await Task.FromResult(result);
        }

        public async Task AddItemAsync(Item item)
        {
            await Task.Factory.StartNew(() => this.items.Add(item));
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var index = this.items.FindIndex(x => x.Guid == item.Guid);
             if(index != -1) 
             {
                 this.items[index] = item;
                 return await Task.FromResult(true);
             }
              return await Task.FromResult(false);
        }

        public async Task<bool> RemoveItemAsync(Guid id)
        {
            var index = this.items.FindIndex(x => x.Guid == id);
            if(index != -1)
            {
                this.items.RemoveAt(index);
                 return await Task.FromResult(true);
            }
             return await Task.FromResult(false);;
        }
    }
}