using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using EveMarket.Core.Repositories;
using EveMarket.Core.Repositories.Db;
using EveMarket.Core.Services;

namespace EveMarket.Web
{
    public class TaskConfig
    {
        private static CacheItemRemovedCallback OnCacheRemove;

        public static void RegisterTasks()
        {
            AddTask("UpdateItems", 300);

            UpdateItems();
        }

        private static void AddTask(string name, int seconds)
        {
            OnCacheRemove = CachItemRemoved;
            HttpRuntime.Cache.Insert(name, seconds, null, DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, OnCacheRemove);
        }

        private static void CachItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            switch (key)
            {
                case "UpdateItems":
                    UpdateItems();
                    break;
            }

            AddTask(key, Convert.ToInt32(value));
        }

        private static void UpdateItems()
        {
            var itemService = new ItemService(new EveDb(), new FlyingCircusEntities());

            itemService.UpdateMarketOrders();
        }
    }
}