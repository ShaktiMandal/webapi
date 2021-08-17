using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using bankingManagementApi.Model;
using BankManagementApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bankingManagementApi.Controller
{
    [ApiController]
    [Route("controller")]
    public class ItemController : ControllerBase
    {
        private IItemRepositories repositories;
        public ItemController(IItemRepositories repository)
        {
            repositories = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await repositories.GetItemsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemAsync(Guid id)
        {
            var item = await repositories.GetItemAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<Item>> AddItemAsync(CreateItem item)
        {
            Item newItem = new()
            {
                Guid = Guid.NewGuid(),
                Name = item.Name,
                Address = item.Address,
                PhoneNumber = item.PhoneNumber
            };

            await repositories.AddItemAsync(newItem);

            return CreatedAtAction(nameof(GetItemAsync), new {Guid = newItem.Guid}, newItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, Item item)
        {
            var findItem = await repositories.GetItemAsync(id);
            if(findItem != null)
            {
                var updateItem = findItem with {
                    Name = item.Name,
                    Address = item.Address,
                    PhoneNumber = item.PhoneNumber
                };

                
                if(await repositories.UpdateItemAsync(updateItem))
                {
                    return NoContent();
                }
            }

            return NotFound();         
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            if(await repositories.RemoveItemAsync(id))
            {
                return Ok();
            }
            return NotFound();            
        }
    }
}