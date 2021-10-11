using OnlineStore.Core.Abstracts;

namespace OnlineStore.Core.DBClasses
{
    public class TypeProduct : ITypeProduct
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}