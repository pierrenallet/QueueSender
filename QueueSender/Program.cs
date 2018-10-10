using Microsoft.Azure.ServiceBus;
using System;
using System.Threading.Tasks;

namespace QueueSender
{
	class Program
	{
		const string connectionString = @"Endpoint=sb://mybuspierre.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=sQ53l4BXM8Xwxp3bcphLJTAGdcFOtE+LPB1RuKE8UQA=";
		static void Main(string[] args)
		{
			RunAsync().Wait();
		}

		static async Task RunAsync()
		{
			QueueClient client = new QueueClient(connectionString, "myqueue");
			while (true)
			{
				string s = Console.ReadLine();
				if (string.IsNullOrEmpty(s))
					return;

				var m = new Message(System.Text.Encoding.UTF8.GetBytes(s));
				await client.SendAsync(m);
			}
		}
	}
}


