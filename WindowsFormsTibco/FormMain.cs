using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TIBCO.Rendezvous;

namespace WindowsFormsTibco
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            DataGridViewRow dgvr = new DataGridViewRow();//实例化对象
            dgvr.CreateCells(dataGridViewMessage);//设置模板，映射作用
            dgvr.Cells[0].Value = "Field1";
            dgvr.Cells[1].Value = "Value1";
            dataGridViewMessage.Rows.Add(dgvr);
            DataGridViewRow dgvr2 = new DataGridViewRow();//实例化对象
            dgvr2.CreateCells(dataGridViewMessage);//设置模板，映射作用
            dgvr2.Cells[0].Value = "Field2";
            dgvr2.Cells[1].Value = "Value2";
            dataGridViewMessage.Rows.Add(dgvr2);
            StartTib();
        }

        private void StartTib()
        {
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
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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
        #region Listener
        private void buttonListen_Click(object sender, EventArgs e)
        {
            string service = textBoxService.Text;
            string network = textBoxnetwork.Text;
            string daemon = textBoxdaemon.Text;
            string subject = textBoxListenerSubject.Text;

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


            Task ListenTask = new Task(() =>
            {
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
                        MessageBox.Show(exception.Message + exception.StackTrace);
                        break;
                    }
                }
            });
            ListenTask.Start();
            // Force optimizer to keep alive listeners up to this point.
            GC.KeepAlive(listener);
        }

        void OnMessageReceived(object listener, MessageReceivedEventArgs messageReceivedEventArgs)
        {
            TIBCO.Rendezvous.Message message = messageReceivedEventArgs.Message;
            Invoke(new Action(() =>
            {
                richTextBoxListen.Text += string.Format("{0}: subject={1}, reply={2}, message={3}\r\n",
                DateTime.Now.ToString(),
                message.SendSubject,
                message.ReplySubject,
                message.ToString());
            }));
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Sender
        private void buttonSend_Click(object sender, EventArgs e)
        {
            string service = textBoxService.Text;
            string network = textBoxnetwork.Text;
            string daemon = textBoxdaemon.Text;
            string subject = textBoxSendSubject.Text;

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
            TIBCO.Rendezvous.Message message = new TIBCO.Rendezvous.Message();

            // Set send subject into the message
            try
            {
                message.SendSubject = subject;
            }
            catch (RendezvousException exception)
            {
                Console.Error.WriteLine("Failed to set send subject:");
                Console.Error.WriteLine(exception.StackTrace);
                System.Environment.Exit(1);
            }

            try
            {
                string guid = Guid.NewGuid().ToString("N");
                TIBCO.Rendezvous.Message Header = new TIBCO.Rendezvous.Message();
                Header.AddField("HOST", System.Environment.MachineName);
                Header.AddField("DOMAIN", System.Environment.UserDomainName);
                Header.AddField("USER", System.Environment.UserName);
                Header.AddField("LIB_VERSION", "4.6.1 (8.4)");
                Header.AddField("PID", System.Diagnostics.Process.GetCurrentProcess().Id);
                Header.AddField("APP_NAME", System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                Header.AddField("APP_VERSION", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                Header.AddField("REQ_MODE", false);
                Header.AddField("TIMESTAMP", DateTime.Now);

                Header.AddField("MSG_ID", guid);
                Header.AddField("REQ_ID", "");
                Header.AddField("QoS", "R");
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                Opaque opaque = new Opaque() { Value = md5.ComputeHash(Encoding.Unicode.GetBytes(guid)) };
                Header.AddField("HASH", opaque);

                TIBCO.Rendezvous.Message Data = new TIBCO.Rendezvous.Message();
                // Send one message for each parameter
                foreach (DataGridViewRow row in dataGridViewMessage.Rows)
                {
                    if(row.Index != dataGridViewMessage.Rows.Count -1)
                    {
                        string name = row.Cells[0].Value.ToString();
                        string value = row.Cells[1].Value.ToString();
                        Data.AddField(name, value, 0);
                    }

                }

                message.AddField("HEADER", Header);
                message.AddField("DATA", Data);

                transport.Send(message);
            }
            catch (RendezvousException exception)
            {
                Console.Error.WriteLine("Error sending a message:");
                Console.Error.WriteLine(exception.StackTrace);
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void buttonIFXAPI_Click(object sender, EventArgs e)
        {
            string service = textBoxService.Text;
            string network = textBoxnetwork.Text;
            string daemon = textBoxdaemon.Text;
            string subject = "SIAPM_L.YODA.IFXAPI";

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
            TIBCO.Rendezvous.Message message = new TIBCO.Rendezvous.Message();

            // Set send subject into the message
            try
            {
                message.SendSubject = subject;
            }
            catch (RendezvousException exception)
            {
                Console.Error.WriteLine("Failed to set send subject:");
                Console.Error.WriteLine(exception.StackTrace);
                System.Environment.Exit(1);
            }

            try
            {
                string guid = Guid.NewGuid().ToString("N");
                TIBCO.Rendezvous.Message Header = new TIBCO.Rendezvous.Message();
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
                Header.AddField("QoS", "R");
                byte[] keyArray = UTF8Encoding.UTF8.GetBytes("ae125efkk4_54eeff444ferfkny6oxi8");
                byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(guid);
                RijndaelManaged rDel = new RijndaelManaged();
                rDel.Key = keyArray;
                rDel.Mode = CipherMode.ECB;
                rDel.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = rDel.CreateEncryptor();
                Opaque opaque = new Opaque() { Value = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length) };
                Header.AddField("HASH", opaque);

                TIBCO.Rendezvous.Message Data = new TIBCO.Rendezvous.Message();
                Data.AddField("IFX_SERVICE", "GetLotDetails");
                Data.AddField("IsCamstarLot", true);
                Data.AddField("LotName", "QCTEST01");

                message.AddField("HEADER", Header);
                message.AddField("DATA", Data);



                TIBCO.Rendezvous.Message reply = transport.SendRequest(message, 60);

                richTextBoxListen.Text += string.Format("{0}: subject={1}, reply={2}, message={3}\r\n",
               DateTime.Now.ToString(),
               reply.SendSubject,
               reply.ReplySubject,
               reply.ToString());
            }
            catch (RendezvousException exception)
            {
                Console.Error.WriteLine("Error sending a message:");
                Console.Error.WriteLine(exception.StackTrace);
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        #endregion
    }
}
