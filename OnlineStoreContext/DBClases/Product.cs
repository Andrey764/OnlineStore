using OnlineStore.Core.Abstract;

namespace OnlineStore.Core.DBClases
{
    public class Product : IProduct
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int IdType { get; set; }
        public TypeProduct Type { get; set; }
        public string Path { get; set; }
    }
}
