namespace _4FunBike
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;

    public class DataHolder
    {
        private static DataHolder instance;
        public static String DataFilePath = "C:\\Users\\Linus\\OneDrive\\Dokumente\\GitHub\\Team6IT26A\\4FunBike\\data\\data.json";
        public String ImageFolderPath { get; set; }
        public List<Category> CatProducts { get; set; }
        public List<Product> Products { get; set; }

        public void ReadFile()
        {
            if (File.Exists(DataFilePath))
            {
                var jsonData = File.ReadAllText(DataFilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var parsedData = JsonSerializer.Deserialize<JsonDataStructure>(jsonData, options);

                ImageFolderPath = parsedData.images;

                CatProducts = new List<Category>();
                Products = new List<Product>();
                foreach (var productCategory in parsedData.products)
                {
                    var categoryProducts = new List<Product>();
                    foreach (var productData in productCategory.Value)
                    {
                        Product temp = new Product
                        {
                            Name = productData.name,
                            Price = productData.preis
                        };
                        categoryProducts.Add(temp);
                        Products.Add(temp);
                    }
                    var category = new Category
                    {
                        Name = productCategory.Key,
                        Products = categoryProducts
                    };
                    CatProducts.Add(category);
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        private static void Initialize()
        {
            instance = new DataHolder();
            instance.ReadFile();
            Console.WriteLine("DataHolder initialized.");
        }

        public static DataHolder GetInstance()
        {
            if (instance == null)
            {
                Initialize();
            }
            return instance;
        }
    }
    internal class JsonDataStructure
    {
        public string images { get; set; }
        public Dictionary<string, List<JsonProductStructure>> products { get; set; }
    }

    internal class JsonProductStructure
    {
        public string name { get; set; }
        public double preis { get; set; }
    }

    public struct Product
    {
        //has name and price
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public struct Category
    {
        //has Name and list of products
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}