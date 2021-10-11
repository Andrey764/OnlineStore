using OnlineStore.Core.Abstract;

namespace OnlineStore.Core.DBClases
{
    public class TypeProduct : ITypeProduct
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
