using System;

namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            Product other = obj as Product;
            if (other is null) return false;
            return this.Name == other.Name && this.Price == other.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
    }
}
