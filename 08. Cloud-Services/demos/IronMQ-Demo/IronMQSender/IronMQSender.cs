using System;
using io.iron.ironmq;

class IronMQSender
{
	static void Main(string[] args)
	{
		Client client = new Client("564191224aa03100070000c9",
            "SI9mlvuSEQqy6o7W5vip4SFNfx0");
		Queue queue = client.queue("Today's demo");
		Console.WriteLine("Enter messages to be sent to the IronMQ server:");
		while (true)
		{
			string msg = Console.ReadLine();
			queue.push(msg);
			Console.WriteLine("Message sent to the IronMQ server.");
		}
	}
}
