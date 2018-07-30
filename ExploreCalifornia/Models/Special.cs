namespace ExploreCalifornia.Models
{
    public class Special
    {
        public long Id { get; set; }
        public string Key { get; internal set; }
        public string Name { get; internal set; }
        public string Type { get; internal set; }
        public int Price { get; internal set; }
    }
}
