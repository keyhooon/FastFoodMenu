using System.Collections.ObjectModel;

namespace XFDelivery.Models
{
    public class Item
    {
        public int id { get; set; }
        public string description { get; set; }
        public string complement { get; set; }
        public int calories { get; set; }
        public decimal price { get; set; }
        public bool favorite { get; set; }
        public string image { get; set; }
        public double rating { get; set; }
        public string Tags { get; set; }
    }
}
