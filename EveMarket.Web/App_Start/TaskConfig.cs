using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using EveMarket.Core.Repositories;
using EveMarket.Core.Services;
using EveMarket.Core.Services.Interfaces;

namespace EveMarket.Web
{
    public class TaskConfig
    {
        private CacheItemRemovedCallback OnCacheRemove;
        private readonly IItemService _itemService;
        

        public TaskConfig(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void RegisterTasks()
        {
            AddTask("UpdateItems", 300);

            UpdateItems();
        }

        private void AddTask(string name, int seconds)
        {
            OnCacheRemove = CachItemRemoved;
            HttpRuntime.Cache.Insert(name, seconds, null, DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, OnCacheRemove);
        }

        private void CachItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            switch (key)
            {
                case "UpdateItems":
                    UpdateItems();
                    break;
            }

            AddTask(key, Convert.ToInt32(value));
        }

        private void UpdateItems()
        {
            _itemService.RefreshMarketOrders(10000002);
        }
    }
}