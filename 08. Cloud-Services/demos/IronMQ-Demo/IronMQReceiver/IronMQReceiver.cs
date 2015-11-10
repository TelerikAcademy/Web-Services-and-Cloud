using System;
using io.iron.ironmq;
using io.iron.ironmq.Data;
using System.Threading;

class IronMQReceiver
{
	static void Main()
	{
		Client client = new Client(
            "564191224aa03100070000c9",
            "SI9mlvuSEQqy6o7W5vip4SFNfx0");
		Queue queue = client.queue("Today's demo");
		Console.WriteLine("Listening for new messages from IronMQ server:");
		while (true)
		{
			Message msg = queue..get();
			if (msg != null)
			{
				Console.WriteLine(msg.Body);
                queue.deleteMessage(msg);
			}
			Thread.Sleep(100);
		}
	}
}
