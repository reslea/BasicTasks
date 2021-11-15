using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;

var factory = new ConnectionFactory() { HostName = "rabbit" };

const int maxAttempts = 5;
int attempts = 0;
while (attempts < maxAttempts)
{
    try
    {
        using var connection = factory.CreateConnection();

        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "hello",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
        };

        channel.BasicConsume("hello", autoAck: true, consumer);

        await Task.Delay(TimeSpan.FromHours(10));
    }
    catch (BrokerUnreachableException)
    {
        attempts++;
        Console.WriteLine("Cannot connect to rabbit, waiting 3 sec");
        await Task.Delay(TimeSpan.FromSeconds(3));
    }
}