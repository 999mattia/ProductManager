namespace ProductManager.Models
{
    public class Product
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        public bool InProduction { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Type { get; set; }

        public Product(string name, int stock, int price, bool inProduction, DateTime releaseDate, string type)
        {
            Name = name;
            Stock = stock;
            Price = price;
            InProduction = inProduction;
            ReleaseDate = releaseDate;
            Type = type;
        }
    }
}