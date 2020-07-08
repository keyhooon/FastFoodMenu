using Shiny.Caching;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFDelivery.Models;

namespace XFDelivery.Service
{
    public class DataService
    {
        private readonly SqliteConnection sqliteConnection;
        private readonly ICache cache;

        public DataService(SqliteConnection sqliteConnection, Shiny.Caching.ICache cache)
        {
            this.sqliteConnection = sqliteConnection;
            this.cache = cache;
            //if (sqliteConnection.Items.CountAsync().Result == 0)
                FakeInsertData();
        }

        public async Task<List<Item>> GetItemsAsync()
        {
            return await cache.Get<List<Item>>("Items");
            //return await sqliteConnection.Items.ToListAsync();
        }

        public async Task<List<Tag>> GetTagsAsync()
        {
            return await cache.Get<List<Tag>>("Tags");
            //return await sqliteConnection.Tags.ToListAsync();
        }


        private void FakeInsertData()
        {

            var tags = new List<Tag>()
            {
                new Tag()
                {
                    id = 1,
                    description = "Pizza",
                    image = "pizza",
                },
                new Tag()
                {
                    id = 2,
                    description = "Burgers",
                    image = "burger",
                },
                new Tag()
                {
                    id = 3,
                    description = "Asian",
                    image = "junk_food",
                }
            };
            var items = new List<Item>()
            {
                new Item()
                {
                     id = 1,
                     description = "Margherita",
                     complement = "Tomato sauce, fresh mozzarella, olive oil, fresh basi",
                     image = "item1",
                     calories = 76,
                     price = 45,
                     rating = 4.2,
                     favorite = true,
                     Tags = "1"
                },
                new Item()
                {
                    id = 2,
                     description = "Rughetta",
                     complement = "Arugula, Cherry Tomatoes, Artichokes, Shaved Parmigiano, Lemon/E.V.O.O. Dressing",
                     calories = 70,
                     image = "item2",
                     price = 59,
                     rating = 3.8,
                     favorite = false,
                     Tags = "2"
                },
                new Item()
                {
                    id = 3,
                     description = "Banoffie Pie",
                     complement = "Breaded chicken, ham and bacon, drizzled with homemade rach",
                     image = "item3",
                     calories = 85,
                     rating = 4.9,
                     price = 106,
                     favorite = true,
                     Tags = "3"
                },
            };
            cache.Set("Items", items);
            cache.Set("Tags", tags);

            //sqliteConnection.GetConnection().InsertAll(items);
            //sqliteConnection.GetConnection().InsertAll(tags);

        }
    }
}
