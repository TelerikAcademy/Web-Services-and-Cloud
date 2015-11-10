using System;
using System.Collections.Generic;
using System.Diagnostics;

public class PubnubDemo
{
	static void Main()
	{
		// Start the HTML5 Pubnub client
		Process.Start("..\\..\\PubNub-HTML5-Client.html");

        System.Threading.Thread.Sleep(2000);

		PubnubAPI pubnub = new PubnubAPI(
            "pub-c-02dee9ae-9627-4fb7-a486-a5cdf9df9749",               // PUBLISH_KEY
            "sub-c-04a5c868-0374-11e3-bde1-02ee2ddab7fe",               // SUBSCRIBE_KEY
            "sec-c-NTUzNGMyMjgtNDhkZS00ZTMwLWEyYTEtNGY5ZjYyOGU5ODY2",   // SECRET_KEY
			true                                                        // SSL_ON?
		);
		string channel = "nakov-channel";

		// Publish a sample message to Pubnub
		List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
		Console.WriteLine(
			"Publish Success: " + publishResult[0].ToString() + "\n" +
			"Publish Info: " + publishResult[1]
		);

		// Show PubNub server time
		object serverTime = pubnub.Time();
		Console.WriteLine("Server Time: " + serverTime.ToString());

		// Subscribe for receiving messages (in a background task to avoid blocking)
		System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
			() =>
			pubnub.Subscribe(
				channel,
				delegate(object message)
				{
					Console.WriteLine("Received Message -> '" + message + "'");
					return true;
				}
			)
		);
		t.Start();

		// Read messages from the console and publish them to Pubnub
		while (true)
		{
			Console.Write("Enter a message to be sent to Pubnub: ");
			string msg = Console.ReadLine();
			pubnub.Publish(channel, msg);
			Console.WriteLine("Message {0} sent.", msg);
		}
	}
}