using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

namespace TestWebApi.Controllers
{
    public class FileTestController : Controller
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private const string QueueName = "resizeFile";

        public FileTestController(IConnection connection)
        {
            this.connection = connection;

            this.channel = connection.CreateModel();
            channel.QueueDeclare(QueueName,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            const string pictureStorage = @"C:\ITStep\РПО ПС\pictureStorage";

            foreach (var file in files)
            {
                var fileName = $"picture_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var filePath = Path.Combine(pictureStorage, fileName);
                using var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);

                PostMessage(filePath);
            }

            return Ok();
        }

        private void PostMessage(string filePath)
        {
            var fileInfo = new { FilePath = filePath };
            var fileInfoJson = JsonConvert.SerializeObject(fileInfo);
            var fileInfoBytes = Encoding.UTF8.GetBytes(fileInfoJson);

            channel.BasicPublish(exchange: "",
                                 routingKey: QueueName,
                                 basicProperties: null,
                                 body: fileInfoBytes);
        }
    }
}
