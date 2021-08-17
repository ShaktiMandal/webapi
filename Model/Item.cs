using System;
using MongoDB.Bson.Serialization.Attributes;

namespace bankingManagementApi.Model
{
    [BsonIgnoreExtraElements]
    public record Item : CreateItem {        
        public Guid Guid{get; init;}
    }
}
