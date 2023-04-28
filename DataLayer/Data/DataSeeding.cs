using Bogus;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    public class DataSeeding
    {
        public List<Product> Products { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
        public List<Country> Countries { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Image> Images { get; set; }
        public List<PaymentProvider> PaymentProviders { get; set; }


        public DataSeeding()
        {
            int seed = 1;

            this.PaymentProviders = new List<PaymentProvider>
            {
                new PaymentProvider
                {
                    Id = 1,
                    Name = "PayPal",
                    ModifiedDate = DateTime.Now,
                    CreateDate = DateTime.Now
                },
                new PaymentProvider
                {
                    Id = 2,
                    Name = "Bank Transfer",
                    ModifiedDate = DateTime.Now,
                    CreateDate = DateTime.Now
                }
            };

            this.Countries = new Faker<Country>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Address.Country())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);

            //this.Contacts = new Faker<Contact>()
            //    .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            //    .RuleFor(p => p.CountryId, f => f.PickRandom(this.Countries).Id)
            //    .RuleFor(p => p.Name, f => f.Name.FullName())
            //    .RuleFor(p => p.City, f => f.Address.City())
            //    .RuleFor(p => p.StreetName, f => f.Address.StreetAddress())
            //    .RuleFor(p => p.ZipCode, f => f.Address.ZipCode())
            //    .RuleFor(p => p.CreateDate, f => f.Date.Past())
            //    .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber())
            //    .RuleFor(p => p.Mobile, f => f.Phone.PhoneNumber())
            //    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
            //    .UseSeed(seed).Generate(10);
            
            this.Brands = new Faker<Brand>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Vehicle.Manufacturer())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);
            
            this.Categories = new Faker<Category>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.Categories(1).First())
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(10);

            this.Products = new Faker<Product>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => f.Commerce.Price(1).First())
                .RuleFor(p => p.SKU, f => f.Commerce.Ean8())
                .RuleFor(p => p.BrandId, f => f.PickRandom(this.Brands).Id)
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(100);

            foreach (var product in this.Products.Where(p => p.Name.Contains("Refined")))
            {
                product.Featured = true;
            }

            Random rnd = new Random();
            this.ProductCategories = new List<ProductCategory>();
            foreach (var item in this.Products)
            {
                this.ProductCategories.Add(
                    new ProductCategory
                    {
                        ProductId = item.Id,
                        CategoryId = rnd.Next(1, this.Categories.Count())
                    }
                    );
            }


            this.Baskets = new Faker<Basket>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(150);
            
            this.BasketItems = new Faker<BasketItem>()
                .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                .RuleFor(p => p.ProductId, f => f.PickRandom(this.Products).Id)
                .RuleFor(p => p.BasketId, f => f.PickRandom(this.Baskets).Id)
                .RuleFor(p => p.QTY, f => RandomNumberBetween(1, 30))
                .RuleFor(p => p.CreateDate, f => f.Date.Past())
                .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                .UseSeed(seed).Generate(500);

            this.Images = new List<Image>
            {
                new Faker<Image>()
                    .RuleFor(p => p.Id, f => 1)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 1)
                    .RuleFor(p => p.Name, f => "Gorgeous_Wooden_Shoes")
                    .RuleFor(p => p.Filename, f => "Gorgeous_Wooden_Shoes.jpg")
                    .UseSeed(seed).Generate(),
                new Faker<Image>()
                    .RuleFor(p => p.Id, f => 2)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 1)
                    .RuleFor(p => p.Name, f => "Gorgeous_Wooden_Shoes2")
                    .RuleFor(p => p.Filename, f => "Gorgeous_Wooden_Shoes2.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 3)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 1)
                    .RuleFor(p => p.Name, f => "Gorgeous_Wooden_Shoes3")
                    .RuleFor(p => p.Filename, f => "Gorgeous_Wooden_Shoes3.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 4)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 2)
                    .RuleFor(p => p.Name, f => "Handcrafted_Plastic_Soap")
                    .RuleFor(p => p.Filename, f => "Handcrafted_Plastic_Soap.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 5)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 2)
                    .RuleFor(p => p.Name, f => "Handcrafted_Plastic_Soap2")
                    .RuleFor(p => p.Filename, f => "Handcrafted_Plastic_Soap2.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 6)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 3)
                    .RuleFor(p => p.Name, f => "Metal_Chicken")
                    .RuleFor(p => p.Filename, f => "Metal_Chicken.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 7)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 4)
                    .RuleFor(p => p.Name, f => "Metal_Shoes")
                    .RuleFor(p => p.Filename, f => "Metal_Shoes.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 8)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 4)
                    .RuleFor(p => p.Name, f => "Metal_Shoes2")
                    .RuleFor(p => p.Filename, f => "Metal_Shoes2.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 9)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 5)
                    .RuleFor(p => p.Name, f => "Steel_Computer")
                    .RuleFor(p => p.Filename, f => "Steel_Computer.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 10)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 6)
                    .RuleFor(p => p.Name, f => "Cotton_Cheese")
                    .RuleFor(p => p.Filename, f => "Cotton_Cheese.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 11)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 7)
                    .RuleFor(p => p.Name, f => "Refined_Soft_Computer")
                    .RuleFor(p => p.Filename, f => "Refined_Soft_Computer.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 12)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 8)
                    .RuleFor(p => p.Name, f => "Incredible_Steel_Mouse")
                    .RuleFor(p => p.Filename, f => "Incredible_Steel_Mouse.jpg")
                    .UseSeed(seed).Generate(),
                new Faker < Image >()
                    .RuleFor(p => p.Id, f => 13)
                    .RuleFor(p => p.CreateDate, f => f.Date.Past())
                    .RuleFor(p => p.ModifiedDate, f => f.Date.Past())
                    .RuleFor(p => p.ProductId, f => 9)
                    .RuleFor(p => p.Name, f => "Tasty_Granite_Chicken")
                    .RuleFor(p => p.Filename, f => "Tasty_Granite_Chicken.jpg")
                    .UseSeed(seed).Generate()

                
            };
            foreach (var category in this.Categories.Take(9))
            {
                category.ImageId = category.Id;
            }
        }

        private static readonly Random random = new Random();

        private static int RandomNumberBetween(int minValue, int maxValue)
        {
            var next = random.NextInt64();

            return (int)((int)minValue + (next * (maxValue - minValue)));
        }
    }
}
