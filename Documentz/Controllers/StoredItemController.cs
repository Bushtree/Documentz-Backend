﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Documentz.Repositories;
using Documentz.Models;
using Documentz.Services;
using Documentz.Utils;
using Microsoft.Extensions.Options;

namespace Documentz.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class StoredItemController : Controller
    {
        private IStoredItemService StoredItemService { get; }

        public StoredItemController(IStoredItemService storedItemService) => StoredItemService = storedItemService;

        // GET: api/StoredItem
        [HttpGet]
        [ActionName("Get")]
        public async Task<IEnumerable<IStoredItem>> GetAsync()
        {
            return await StoredItemService.GetAllItemsAsync();
        }

        // GET: api/StoredItem/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(string id)
        {
            IStoredItem storedItem = await StoredItemService.GetItemAsync(id);

            if (storedItem == null)
            {
                return NotFound();
            }
            return Ok(storedItem);
        }

        // POST: api/StoredItem
        [HttpPost(Name = "Post")]
        public async Task<IActionResult> PostAsync([FromBody]StoredItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createdItem = await StoredItemService.AddItemAsync(item);
            return Created($"/api/storeditem/{createdItem.Id}", createdItem);
        }

        // PUT: api/StoredItem/5
        [HttpPut("{id}", Name = "Put")]
        public async Task<IActionResult> PutAsync(string id, [FromBody]IStoredItem value)
        {
            await StoredItemService.UpdateItemAsync(id, value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}", Name = "Delete")]
        public async void DeleteAsync(string id)
        {
            await StoredItemService.DeleteItemAsync(id);
        }
    }
}
