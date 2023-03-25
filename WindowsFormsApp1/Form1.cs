using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static Thread buyingProductsThread;
        static Thread sellingProductsThread;

        Random myrandom = new Random();

        Store store = new Store();
        Dictionary<string, double> availableProducts = new Dictionary<string, double>()
        {
            {"iPhone 13", 950.50 }, {"iPhone 13 Pro Max", 1050.50 }, {"Pixel 6 Pro", 850.50}, 
            {"Galaxy S21 FE 5G", 920.50 }, {"Galaxy S21 Ultra", 950.50 }, {"Galaxy Z Flip 3 5G", 1150.50 }, 
            {"Galaxy Z Fold3 5G", 1120.50 }, {"Xiaomi 11T Pro", 750.50 }, {"Xiaomi Mi 11 Ultra", 720.50},
            {"ASUS ROG Phone 5s Pro", 700.50 }
        };

        List<string> productNames = new List<string>()
        {
            "iPhone 13", "iPhone 13 Pro Max", "Pixel 6 Pro", "Galaxy S21 FE 5G",
            "Galaxy S21 Ultra", "Galaxy Z Flip 3 5G", "Galaxy Z Fold3 5G",
            "Xiaomi 11T Pro", "Xiaomi Mi 11 Ultra", "ASUS ROG Phone 5s Pro"            
        };

        public Form1()
        {
            InitializeComponent();
            btBuy.Click += BtInventory_Click;
            btSell.Click += BtSell_Click;
        }

        private void BtSell_Click(object sender, EventArgs e)
        {
            sellingProductsThread = new Thread(RandomSellingProducts);
            sellingProductsThread.Start();
        }

        private void BtInventory_Click(object sender, EventArgs e)
        {
            buyingProductsThread = new Thread(RandomBuyingProducts);
            buyingProductsThread.Start();
        }

        public void RandomSellingProducts()
        {
            int clientsNum = myrandom.Next(1, 5);

            for (int i = 0; i < clientsNum; i++)
            {
                string name = productNames[myrandom.Next(0, productNames.Count)];
                int productCount = myrandom.Next(1, 10);

                store.SellProduct(name, productCount);

                lbProducts.Items.Clear();
                foreach (var product in store.storage)
                    lbProducts.Items.Add(product);

                Thread.Sleep(1000);
            }
        }

        public void RandomBuyingProducts()
        {
            decimal productsNum = NumUpDownSeconds.Value;

            for (int i = 0; i < productsNum; i++)
            {
                string name = productNames[myrandom.Next(0, productNames.Count)];
                int productCount = myrandom.Next(1, 10);
                double purchasePrice = availableProducts[name];
                double sellPrice = Math.Round(purchasePrice * 1.15, 2);

                store.BuyProduct(new Product(name, productCount, purchasePrice, sellPrice));

                lbProducts.Items.Clear();
                foreach (var product in store.storage)
                    lbProducts.Items.Add(product);

                Thread.Sleep(1000);
            }
        }
    }
    
    public class Product
    {
        private string name;
        private int productCount;
        private double purchasePrice;
        private double sellPrice;

        public string Name { get => name; set => name = value; }
        public int ProductCount
        {
            get => productCount;
            set
            {
                if (value >= 0)
                    productCount = value;
            }
        }

        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public double SellPrice { get => sellPrice; set => sellPrice = value; }

        public Product(string name, int productCount, double purchasePrice, double sellPrice)
        {
            Name = name;
            ProductCount = productCount;
            PurchasePrice = purchasePrice;
            SellPrice = sellPrice;
        }

        public override string ToString()
        {
            return $"{Name} з ціною покупки {PurchasePrice} та ціною продажу {SellPrice} у кількості {ProductCount}";
        }

        public Product() { }
    }

    public class Store
    {
        private double amountOfMoney = 100000;

        public double AmountOfMoney 
        { 
            get => amountOfMoney; 
            set
            {
                if (value >= 0)
                    amountOfMoney = value;
            }
        }


        public List<Product> storage = new List<Product>();

        public void SellProduct(string productName, int productCount)
        {
            foreach (Product storage_product in storage)
            {
                if (storage_product.Name == productName && storage_product.ProductCount - productCount > 0)
                {
                    AmountOfMoney += storage_product.SellPrice;
                    storage_product.ProductCount -= productCount;

                    string[] output = { DateTime.Now.ToString(), $"{storage_product.ToString()} через те що їх щойно продали {productCount}"};

                    var serializer = new XmlSerializer(typeof(string[]));
                    using (var file = new FileStream("log.xml", FileMode.Append))
                        serializer.Serialize(file, output);
                }
            }
        }

        public void BuyProduct(Product product)
        {
            bool isAdded = false;
            foreach (Product storage_product in storage)
            {
                if (storage_product.Name == product.Name && AmountOfMoney - product.PurchasePrice >= 0)
                {
                    AmountOfMoney -= product.SellPrice;
                    storage_product.ProductCount += product.ProductCount;

                    string[] output = { DateTime.Now.ToString(), "Магазин купив: " + product.ToString() + $" у кількості {product.ProductCount}"};
                    
                    //File.AppendAllLines("logging.log", output);
                    var serializer = new XmlSerializer(typeof(string[]));
                    using (var file = new FileStream("log.xml", FileMode.Append))
                        serializer.Serialize(file, output);
                    
                    isAdded = true;
                }
            }
            if (!isAdded && AmountOfMoney - product.PurchasePrice >= 0)
            {
                AmountOfMoney -= product.PurchasePrice;
                storage.Add(product);

                string[] output = { DateTime.Now.ToString(), "Магазин купив: " + product.ToString() + $" у кількості {product.ProductCount}"};

                var serializer = new XmlSerializer(typeof(string[]));
                using (var file = new FileStream("log.xml", FileMode.Append))
                    serializer.Serialize(file, output);
            }
        }

        public Store() { }
    }

}
