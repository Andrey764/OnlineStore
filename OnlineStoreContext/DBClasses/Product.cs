using OnlineStore.Core.Abstracts;
using System.Collections.Generic;

namespace OnlineStore.Core.DBClasses
{
    public class Product : IProduct
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int IdType { get; set; }
        public string Characteristics { get; set; }
        public string PathImage { get; set; }

        public string AddreviatedDescription()
        {
            return Description.Length > 30 ? Description.Substring(0, 27) + "..." : Description;
        }

		public Dictionary<string, string> GenerateCharacteristics()
		{
            var map = new Dictionary<string, string>();
            foreach (var characteristic in Characteristics.Split(','))
			{
                var pair = characteristic.Split(':');
                map.Add(pair[0], pair[1]);
			}
            return map;
		}
	}
}