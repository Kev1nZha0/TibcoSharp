using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIBCO.Rendezvous;

namespace Sender
{
	internal class Program
	{
		class SenderApplication
		{
			static string service = null;
			static string network = null;
			static string daemon = null;
			//static int iterations = 1;

			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			[MTAThread]
			static void Main()
			{
				service = "7603";
				network = ";239.255.159.223";
				daemon = "siaxv005t.siapm.com.cn:7500";
				string subject = "SIAPM_L.LEARN.QCTEST";

				try
				{
						TIBCO.Rendezvous.Environment.Open();
				}
				catch (RendezvousException exception)
				{
					Console.Error.WriteLine("Failed to open Rendezvous Environment: {0}", exception.Message);
					Console.Error.WriteLine(exception.StackTrace);
					System.Environment.Exit(1);
				}

				// Create Network transport
				Transport transport = null;
				try
				{
					transport = new NetTransport(service, network, daemon);
				}
				catch (RendezvousException exception)
				{
					Console.Error.WriteLine("Failed to create NetTransport:");
					Console.Error.WriteLine(exception.StackTrace);
					System.Environment.Exit(1);
				}

				// Create the message
				Message message = new Message();

				string guid = Guid.NewGuid().ToString("N");

				// Set send subject into the message
				try
				{
					message.SendSubject = subject;
					message.ReplySubject = "_INBOX.QCTEST." + guid;
				}
				catch (RendezvousException exception)
				{
					Console.Error.WriteLine("Failed to set send subject:");
					Console.Error.WriteLine(exception.StackTrace);
					System.Environment.Exit(1);
				}

				try
				{
					// Send one message for each parameter
					Message Header = new Message();
					Header.AddField("HOST", System.Environment.MachineName);
					Header.AddField("DOMAIN", System.Environment.UserDomainName);
					Header.AddField("USER", System.Environment.UserName);
					Header.AddField("LIB_VERSION", "4.6.1 (8.4)");
					Header.AddField("PID", System.Diagnostics.Process.GetCurrentProcess().Id);
					Header.AddField("APP_NAME", System.Diagnostics.Process.GetCurrentProcess().ProcessName);
					Header.AddField("APP_VERSION", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
					Header.AddField("REQ_MODE", true);
					Header.AddField("TIMESTAMP", DateTime.Now);

					Header.AddField("MSG_ID", guid);
					Header.AddField("REQ_ID", "");
					Header.AddField("QoS","R");
					System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
					Opaque opaque = new Opaque() { Value = md5.ComputeHash(Encoding.Unicode.GetBytes(guid)) };
					Header.AddField("HASH", opaque);

					Message Data = new Message();
					Data.AddField("Field", "Data");

					message.AddField("HEADER", Header);
					message.AddField("DATA", Data);

					Message reply = new Message();
					transport.SendReply(reply, message);
				}
				catch (RendezvousException exception)
				{
					Console.Error.WriteLine("Error sending a message:");
					Console.Error.WriteLine(exception.StackTrace);
					System.Environment.Exit(1);
				}

				// Close Environment, it will cleanup all underlying memory, destroy
				// transport and guarantee delivery.
				try
				{
					TIBCO.Rendezvous.Environment.Close();
				}
				catch (RendezvousException exception)
				{
					Console.Error.WriteLine("Exception dispatching default queue:");
					Console.Error.WriteLine(exception.StackTrace);
					System.Environment.Exit(1);
				}
			}
		}
	}
}
