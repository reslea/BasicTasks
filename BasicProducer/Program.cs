using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();

using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var obj = new { Message = "Hello world!" };

var objJson = JsonConvert.SerializeObject(obj);
var messageBody = Encoding.UTF8.GetBytes(objJson);

while(true)
{
    channel.BasicPublish(exchange: "",
        routingKey: "hello",
        basicProperties: null,
        body: messageBody);

    Console.WriteLine($" [x] Sent '{obj.Message}'");

    await Task.Delay(TimeSpan.FromSeconds(2));

};