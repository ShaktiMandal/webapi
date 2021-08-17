using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bankingManagementApi.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BankManagementApi.Repositories
{
    public class MongodbItemRepository : IItemRepositories
    {
        private const string databaseName = "BMS";
        private const string collectionName = "Items";
        private readonly IMongoCollection<Item> itemCollection;
        private readonly FilterDefinitionBuilder<Item> filterDefinition = Builders<Item>.Filter;
        public MongodbItemRepository(IMongoClient mongoClient)
        {            
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemCollection = database.GetCollection<Item>(collectionName);
        }
        public async Task AddItemAsync(Item item)
        {
            await itemCollection.InsertOneAsync(item);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filteredItem = filterDefinition.Eq(item => item.Guid, id);
            return await itemCollection.Find(filteredItem).SingleOrDefaultAsync();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await itemCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> RemoveItemAsync(Guid id)
        {
            var filteredItem = filterDefinition.Eq(item => item.Guid, id);
            await itemCollection.DeleteOneAsync(filteredItem);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var filteredDefinination = filterDefinition.Eq(item => item.Guid, item.Guid);
            await itemCollection.ReplaceOneAsync(filteredDefinination, item);
            return await Task.FromResult(true);
        }
    }
}