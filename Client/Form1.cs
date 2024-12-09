using Microsoft.VisualBasic.ApplicationServices;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpLientPratice
{
    public partial class Form1 : Form
    {
        public Action<string> writeResponce;
        public Action<string> fillProducts;
        public Action<string> showInfo;
        public Client client;
        public Form1()
        {
            InitializeComponent(); 
            writeResponce = (string receivedMessage) => { textBox2.Text = receivedMessage; };
            fillProducts = async (string prods) =>
            {
                var products = prods.Replace("/prods", string.Empty).Split(" ");
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(products);
            };
            showInfo = (string msg) => { MessageBox.Show(msg); };
            client = new Client();
        }
        public async void SendMessageButton(object sender, EventArgs e)
        {
            client.SendMessageAsync(textBox1.Text);
        }
        public async void GetProductsAsync(object sender, EventArgs e)
        {
            client.SendMessageAsync("/getProducts");
        }
        public async void StartReceivingButton(object sender, EventArgs e)
        {
            client.OpenConnection(showInfo);
            client.ReceiveMessagesAsync(fillProducts, writeResponce);
        }
        public async void SelectProduct(object sender, EventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }
    }
    public class Client
    {
        public TcpClient client;
        public IPEndPoint endPoint;
        public NetworkStream stream;
        public Client() 
        {
            endPoint = new IPEndPoint(IPAddress.Loopback, 7777);
            client = new TcpClient(); 
        }
        public async void OpenConnection(Action<string>act)
        {
            client.Connect(endPoint);
            act.Invoke("Подключение успешно");
            stream = client.GetStream();
        }
        public async void SendMessageAsync(string message)
        {
            try
            {
                stream.Write(Encoding.UTF8.GetBytes(message + '\n'));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public async Task ReceiveMessagesAsync(Action<string> fillCombobox, Action<string>writeResponce)
        {
            await Task.Run(() =>
            {
                List<byte> buffer = new List<byte>();
                while (true)
                {
                    int readedByte = stream.ReadByte();
                    if (readedByte == -1) continue;
                    if (readedByte == '\n')
                    {
                        var message = Encoding.UTF8.GetString(buffer.ToArray(), 0, buffer.Count).Replace("\n", string.Empty);
                        if (message.Contains("/prods"))
                        {
                            fillCombobox.Invoke(message.Replace("\n", string.Empty));
                        }
                        else
                        {
                            writeResponce.Invoke(message);
                        }
                        buffer.Clear();
                    }
                    buffer.Add((byte)readedByte);
                }
            });
        }
    }
}
