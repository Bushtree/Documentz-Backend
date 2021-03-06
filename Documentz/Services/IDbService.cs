﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Documentz.Models;

namespace Documentz.Services
{
    public interface IDbService
    {
        Task<IStoredItem> CreateStoredItemAsync(IStoredItem item);
        Task DeleteStoredItemAsync(string id);
        Task<IStoredItem> GetStoredItemAsync(string id);
        Task<IEnumerable<IStoredItem>> GetStoredItemsAsync();
        Task<IStoredItem> UpdateStoredItemAsync(string id, IStoredItem item);
        Task<IEnumerable<dynamic>> GetAttachmentsAsync(string id);
        Task CreateAttachmentAsync(string id, Stream content);
    }
}