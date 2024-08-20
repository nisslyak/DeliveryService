
namespace DeliveryService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Инициализация классов
            Customer customer1 = new("Petr", "CustomerAddres1");
            Customer customer2 = new("Bob", "CustomerAddres2");
            Shop shop1 = new("Shop1", "ShopAddress1");
            HomeDelivery homeDelivery1 = new(customer2._name, customer2._address);
            ShopDelivery shopDelivery1 = new(shop1._name, customer1._name, shop1._address);
            PickPointDelivery pickPointDelivery1 = new(customer2._name, "PickPointDeliveryAddress1");
            Product product1 = new("Watch", 5); 
            Product product2 = new("Phone", 12);
            Courier courier1 = new("Mark", "1234567");
            Courier courier2 = new("Jhon", "7654321");

            Order<HomeDelivery> order1 = new(1, homeDelivery1, product1, 2, courier1);
            Order<ShopDelivery> order2 = new(2, shopDelivery1, product2, 20, courier2);
            Order<PickPointDelivery> order3 = new(3, pickPointDelivery1, product1, 1);

            // Вывод информации о заказах
            order1.DisplayOrderInfo();
            Console.WriteLine();
            order2.DisplayOrderInfo();
            Console.WriteLine();
            order3.DisplayOrderInfo();
        }
    }

    abstract class Delivery
    {
        public string Address;

        public Delivery(string address)
        {
            Address = address;
        }
    }

    class HomeDelivery : Delivery
    {
        public string _clientName;

        public HomeDelivery(string clientName, string address) : base(address) 
        {
            _clientName = clientName;   
        }
    }

    class PickPointDelivery : Delivery
    {
        public string _clientName;
        public PickPointDelivery(string clientName, string address) : base(address)
        {
            _clientName = clientName;
        }
    }

    class ShopDelivery : Delivery
    {
        public string _shopName;
        public string _clientName;

        public ShopDelivery(string shopName, string clientName, string address) : base(address)
        {
            _shopName = shopName;
            _clientName = clientName;
        }
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public int _id;

        public TDelivery _delivery;

        public Product _product;

        public int _number;

        public Courier _courier;

        public void DisplayOrderInfo()
        {
            if (_delivery is HomeDelivery)
            {
                Console.WriteLine("Доствка на дом");
            }
            else if (_delivery is ShopDelivery)
            {
                Console.WriteLine("Доствка в магазин");
            }
            else if (_delivery is PickPointDelivery)
            {
                Console.WriteLine("Пункт выдачи товара");
            }
            Console.WriteLine($"Адрес: {_delivery.Address}");
            Console.WriteLine($"Товар: {_product._name}");
            Console.WriteLine($"Стоймость товара: {_product._price}р.");
            Console.WriteLine($"Количество: {_number}");
            if (_courier != null)
            {
                Console.WriteLine($"Курьер: {_courier._name}");
            }
        }

        public Order(int id, TDelivery delivery, Product product, int number, Courier courier = null)
        {
            _id = id;
            _delivery = delivery;
            _product = product;
            _number = number;
            _courier = courier;
        }
    }

    class Product
    {
        public string _name;
        public int _price;

        public Product(string name, int price)
        {
            _name = name;
            _price = price;
        }
    }

    class Courier
    {
        public string _name;
        public string _phone;

        public Courier(string name, string phone)
        {
            _name = name;
            _phone = phone;
        }
    }

    class Customer
    {
        public string _name;
        public string _address;
        public Customer(string name, string address)
        {
            _name = name;
            _address = address;
        }
    }

    class Shop
    {
        public string _name;
        public string _address;
        public Shop(string name, string address)
        {
            _name = name;
            _address = address;
        }
    }
}
