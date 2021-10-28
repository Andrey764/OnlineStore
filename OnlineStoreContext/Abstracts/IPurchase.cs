namespace OnlineStore.Core.Abstracts
{
    public interface IPurchase
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
    }
}