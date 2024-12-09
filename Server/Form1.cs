using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Security.Cryptography;

namespace Pratice3Server
{
    public partial class Form1 : Form
    {
        public Action<Product> addProductEvent;
        public Action<Product> logEvent;
        public Server server;
        public Form1()
        {
            InitializeComponent();
            server = new Server();
            server.show = (string message) =>
            {
                textBox3.Text += message+Environment.NewLine;
            };
            addProductEvent = (Product product) =>
            {
                server.assortment.AddProduct(product);
            };
        }
        public async void StartListening(object sender, EventArgs e)
        {
            server.ListenAsync();
        }
        public async void AddProductButton(object sender, EventArgs e)
        {
            try
            {
                decimal price = Convert.ToDecimal(textBox2.Text);
                string name = textBox1.Text;
                addProductEvent.Invoke(new Product(name,price));
                UpdateProducts();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void UpdateProducts()
        {
            listBox1.Items.Clear();
            foreach (var prod in server.assortment.products)
            {
                listBox1.Items.Add(prod.ToString());
            }
        }
    }

    
    
}
