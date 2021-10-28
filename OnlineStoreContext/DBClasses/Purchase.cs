using OnlineStore.Core.Abstracts;

namespace OnlineStore.Core.DBClasses
{
    public class Purchase : IPurchase
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}