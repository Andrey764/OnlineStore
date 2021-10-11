using System.Collections.Generic;

namespace OnlineStore.Core.Abstracts
{
    public interface IProduct
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int IdType { get; set; }
        public string Characteristics { get; set; }
        public string PathImage { get; set; }
    }
}