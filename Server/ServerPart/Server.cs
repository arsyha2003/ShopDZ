using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pratice3Server
{
    public class Server
    {
        public Assortment assortment;
        public Action<string> show;
        public List<User> connectedUsers;
        public TcpListener listener;
        public List<User> deletedUsers;
        public Server()
        {
            listener = new TcpListener(new IPEndPoint(IPAddress.Any, 7777));
            connectedUsers = new List<User>();
            deletedUsers = new List<User>();
            assortment = new Assortment();
        }
        public async Task ListenAsync()
        {
            listener.Start();
            try
            {
                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    _ = Task.Run(() => ClientHandler(client));
                }
            }
            catch (Exception ex)
            {
                show.Invoke(ex.Message);
            }
            finally
            {
                listener?.Stop();
            }
        }
        public bool CheckUserUnique(User user)
        {
            var ipParts = user.point.ToString().Split(new char[] { '.', ':' });
            string userIp = $"{ipParts[0]}.{ipParts[1]}.{ipParts[2]}.{ipParts[3]}";
            foreach (User us in connectedUsers)
            {
                ipParts = us.point.ToString().Split(new char[] { '.', ':' });
                string tmpIp = $"{ipParts[0]}.{ipParts[1]}.{ipParts[2]}.{ipParts[3]}";
                if (tmpIp == userIp)
                {
                    show.Invoke($"Пользователь {user} не прошел проверку {DateTime.Now}");
                    return false;
                }
            }
            show.Invoke($"Пользователь {user} прошел проверку {DateTime.Now}");
            return true;
        }
        public async Task CheckUseractivity(User user, TcpClient client, NetworkStream stream)
        {
            await Task.Run(() =>
            {
                while (user.unactiveTime <= 10)
                {
                    user.unactiveTime++;
                    show.Invoke($"Секунды неактивности: {user.unactiveTime}\n");
                    if (user.isConnected == false) return;
                    Thread.Sleep(1000);//Почему-то через Task.Delay не получается сделать
                }
                user.isConnected = false;
                stream.Write(Encoding.UTF8.GetBytes("Вы слишком долго были не активны" + '\n'));
                show.Invoke($"Отключен {user} по причине неактивности");
                client.Close();
            });
        }
        public bool CheckUser(User user)
        {
            bool retVal = false;
            if (user.connectionTime > DateTime.Now)
            {
                show.Invoke($"Отключен {user}, время новой попытки еще не пришло");
                show.Invoke($"Возможность повторного подключения будет через {(user.connectionTime - DateTime.Now).TotalHours}");
  
                retVal = false;
            }
            foreach (var us in connectedUsers)
            {
                if(us == user)
                {
                    if (user.isConnected == false)
                    {
                        retVal = true;
                        show.Invoke($"{user} успешно подключен");
                        user.isConnected = true;
                        break;
                    }
                    else if(user.isConnected == true)
                    {
                        retVal = false;
                        show.Invoke($"{user} уже был подключен");
                        break;
                    }
                }
            }
            return retVal;
        }
        public void SetUserActive(User user)
        {
            foreach(var us in connectedUsers)
            {
                if (us == user)
                {
                    user.isConnected = true;
                    break;
                }
            }
        }
        public int CountConnectedUsers()
        {
            int counter = 0;
            foreach(var u  in connectedUsers)
            {
                if (u.isConnected == true)
                {
                    counter++;
                }
            }
            return counter;
        }
        public async void ClientHandler(TcpClient client)
        {
            User user = new User(client.Client.RemoteEndPoint); 
            if (CheckUserUnique(user) != false)
                connectedUsers.Add(user);
            try
            {
                user.connectionTime = DateTime.Now;
                var stream = client.GetStream();
                if (CountConnectedUsers() <= 10)
                {
                    List<byte> buffer = new List<byte>();
                    if (!CheckUser(user))
                    {
                        show.Invoke($"{user}");
                        client.Close();
                        return;
                    }
                    CheckUseractivity(user, client, stream);
                    while (true)
                    {
                        show.Invoke($"Пользователь будет отключен через {10-user.unactiveTime}");
                        if(user.messagesPerHour<=0)
                        {
                            user.isConnected = false;
                            user.connectionTime = DateTime.Now.AddHours(1);
                            show.Invoke($"{user} отключился, возможность подключиться будет в {user.connectionTime}");
                            client.Close();
                        }
                        int readedByte = stream.ReadByte();
                        if (readedByte == -1) continue;
                        if (readedByte == '\n')
                        {
                            var message = Encoding.UTF8.GetString(buffer.ToArray(), 0, buffer.Count).Replace("\n", string.Empty);
                            user.unactiveTime = 0;
                            user.MessageSended();
                            show.Invoke($"{user} потратил одно сообщение, осталось сообщений {user.messagesPerHour}");
                            if (message.Contains("/getProducts"))
                            {
                                string products = "/prods";
                                foreach (var prod in assortment.products)
                                {
                                    products += prod.name + " ";
                                }
                                show.Invoke($"Отправлены все продукты в наличии");
                                stream.Write(Encoding.UTF8.GetBytes(products + '\n'));
                            }
                            else
                            {
                                string request = string.Empty;
                                foreach (var prod in assortment.products)
                                {
                                    if (prod.name.ToLower() == message.ToLower())
                                    {
                                        request = prod.ToString();
                                        break;
                                    }
                                }
                                if (request == string.Empty)
                                {
                                    stream.Write(Encoding.UTF8.GetBytes($"Такого товара нет в наличии" + '\n'));
                                    show.Invoke($"Пользователь ввел неверное название товара");
                                }
                                else
                                {
                                    stream.Write(Encoding.UTF8.GetBytes($"Товар: {request}" + '\n'));
                                    show.Invoke($"Отправлена информация о {request}");
                                }
                            }
                            show.Invoke(message);
                            buffer.Clear();
                        }
                        buffer.Add((byte)readedByte);
                    }
                }
                else
                {
                    stream.Write(Encoding.UTF8.GetBytes("Сервер перегружен, попробуйте позже..." + '\n'));
                    user.isConnected = false;
                    client.Close();
                }
            }
            catch (Exception)
            {
                show.Invoke("Пользователь отключился");
                user.isConnected = false;
            }
            finally
            {
                client.Close();
            }
        }
    }
}
