using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace QwirkleAI
{
	class Program
	{
		static void Main(string[] args)
		{
			//string hostIp = "http://172.24.53.76:52367/hub";
			string hostIp = "http://localhost:21891/hub";

		

			var clientHub = new ClientHub(hostIp);

			foreach (var item in clientHub.messagesList)
			{
				Console.WriteLine(item);
			};
			


			



		}


		



	}
}
