using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Drawing;
using System.IO;
using System.Text;

public class FileInfo
{
    public string FilePath { get; set; }
}

public static class Program
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        var connection = factory.CreateConnection();

        var channel = connection.CreateModel();

        const string queueName = "resizeFile";

        channel.QueueDeclare(queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);

        consumer.Received += (model, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var fileObj = JsonConvert.DeserializeObject<FileInfo>(message);

            Resize(fileObj.FilePath);
            Console.WriteLine($" [x] Resized {fileObj.FilePath}");
        };

        channel.BasicConsume(queueName, autoAck: true, consumer);

        Console.ReadLine();
    }

    static void Resize(string filePath)
    {
        const int midMaxWidth = 360;
        const int midMaxHeigth = 240;

        var image = Image.FromFile(filePath);
        var resized = image.GetThumbnailImage(midMaxWidth, midMaxHeigth, null, IntPtr.Zero);

        var directory = Path.GetDirectoryName(filePath);
        var fileExtention = Path.GetExtension(filePath);
        var fileName = Path.GetFileName(filePath).Replace(fileExtention, "");

        var midFilePath = Path.Combine(directory, $"{fileName}_mid{fileExtention}");
        resized.Save(midFilePath);
    }
}