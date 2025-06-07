using StackExchange.Redis;

ConnectionMultiplexer connection =  await ConnectionMultiplexer.ConnectAsync("localhost:1453");

ISubscriber subscriber =  connection.GetSubscriber(); //subscriber oluşturduk

while (true)
{
	Console.Write("Mesaj : ");
	string message = Console.ReadLine();
	await subscriber.PublishAsync("mychannel", message);
}



