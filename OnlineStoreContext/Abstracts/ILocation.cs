namespace OnlineStore.Core.Abstracts
{
    public interface ILocation
    {
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int NumberHouse { get; set; }
    }
}