namespace forms_page.Models

{
    public class Repository
    {
        public static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category {CategoryId = 1, Name = "Book"});
            _categories.Add(new Category {CategoryId = 2, Name = "E-Book"});

            _products.Add(new Product {ProductId = 1, Name = "The Elephant Vanishes", Price = 25.00M, IsInStock = true, Image = "1.jpg", CategoryId=1});
            _products.Add(new Product {ProductId = 1, Name = "Intibah", Price = 17.00M, IsInStock = true, Image = "2.jpg", CategoryId=1});

            _products.Add(new Product {ProductId = 1, Name = "Gun Olur Asra Bedel", Price = 8.00M, IsInStock = true, Image = "3.jpg", CategoryId=2});
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }


    }
}