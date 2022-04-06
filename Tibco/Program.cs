using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIBCO.Rendezvous;

namespace Tibco
{
    internal class Program
    {
		static string service = null;
		static string network = null;
		static string daemon = null;

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
				Console.Error.WriteLine("Failed to create NetTransport");
				Console.Error.WriteLine(exception.StackTrace);
				System.Environment.Exit(1);
			}
			Listener listener = new Listener(Queue.Default, transport, subject, null);

			// create listener using default queue
			try
            {
                listener.MessageReceived += new MessageReceivedEventHandler(OnMessageReceived);
                Console.Error.WriteLine("Listening on: " + subject);
            }
            catch (RendezvousException exception)
            {
                Console.Error.WriteLine("Failed to create listener:");
                Console.Error.WriteLine(exception.StackTrace);
                System.Environment.Exit(1);
            }


            // dispatch Rendezvous events
            while (true)
            {
                try
                {
                    Queue.Default.Dispatch();
                }
                catch (RendezvousException exception)
                {
                    Console.Error.WriteLine("Exception dispatching default queue:");
                    Console.Error.WriteLine(exception.StackTrace);
                    break;
                }
            }

            // Force optimizer to keep alive listeners up to this point.
            GC.KeepAlive(listener);

			TIBCO.Rendezvous.Environment.Close();
		}

		static void OnMessageReceived(object listener, MessageReceivedEventArgs messageReceivedEventArgs)
		{
			Message message = messageReceivedEventArgs.Message;

			Console.Out.WriteLine("{0}: subject={1}, reply={2}, message={3}",
				DateTime.Now.ToString(),
				message.SendSubject,
				message.ReplySubject,
				message.ToString());
			Console.Out.Flush();
		}
	}
}
