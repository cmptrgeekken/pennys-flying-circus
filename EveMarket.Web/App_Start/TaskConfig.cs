using System;
using System.Threading;
using System.Web;
using System.Web.Caching;
using EveMarket.Core.Services.Interfaces;

namespace EveMarket.Web
{
    public class TaskConfig
    {
        private readonly CacheItemRemovedCallback _onCacheRemove;
        private readonly IItemService _itemService;
        

        public TaskConfig(IItemService itemService)
        {
            _itemService = itemService;
            _onCacheRemove = CachItemRemoved;
        }

        public void RegisterTasks()
        {
            AddTask("RefreshItemDatabase", 300);

            RefreshItemDatabase();
        }

        private void AddTask(string name, int seconds)
        {
            HttpRuntime.Cache.Insert(name, seconds, null, DateTime.Now.AddSeconds(seconds), Cache.NoSlidingExpiration,
                CacheItemPriority.NotRemovable, _onCacheRemove);
        }

        private void CachItemRemoved(string key, object value, CacheItemRemovedReason reason)
        {
            switch (key)
            {
                case "RefreshItemDatabase":
                    RefreshItemDatabase();
                    break;
            }

            AddTask(key, Convert.ToInt32(value));
        }

        private void RefreshItemDatabase()
        {
            var thread = new Thread(() => _itemService.RefreshMarketOrders(10000002));

            thread.Start();
        }
    }
}