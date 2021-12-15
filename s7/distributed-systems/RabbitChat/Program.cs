using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

const string QueueName = "chat";

Console.Write("Welcome to RabbitChat! What is your name? ");
var userName = Console.ReadLine();
var userId = Guid.NewGuid();

if (userName is null)
    return 1;

Console.WriteLine($"Hello {userName}, write your messages below:");
Console.WriteLine("Send an empty string to exit.");

var factory = new ConnectionFactory() { HostName = "localhost"};
using var connection = factory.CreateConnection("RabbitChat");
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: true);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) => {
    var jsonReader = new Utf8JsonReader(args.Body.Span);
    var message = JsonSerializer.Deserialize<Message>(ref jsonReader);

    if (message is not null && message.SenderId != userId)
        Console.WriteLine($"[{message.SentAt}] {message.Sender}: {message.Content}");
};

channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);

while (true)
{
    var content = Console.ReadLine();
    if (string.IsNullOrEmpty(content)) break;
    var message = new Message(userId, userName, content, DateTimeOffset.Now);

    var jsonString = JsonSerializer.Serialize(message);
    var jsonUtf8 = Encoding.UTF8.GetBytes(jsonString);
    channel.BasicPublish(exchange: "", routingKey: QueueName, body: jsonUtf8);
}

return 0;

public sealed record class Message(Guid SenderId, string Sender, string Content, DateTimeOffset SentAt);
