namespace OnlineStore.Core.Abstract
{
    public interface IClothing
    {
        public string Dimensions { get; set; }
        public string FunctionalFeatures { get; set; }
        public string Gender { get; set; }
        public string ClimaticCharacteristics { get; set; }
    }
}
