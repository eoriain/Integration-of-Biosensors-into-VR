using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Security;

namespace EmpaticaBLEClient
{
    public static class AsynchronousClient
    {

        static StreamWriter fileGSR;
        static StreamWriter fileHR;
        static StreamWriter fileIBI;
        static StreamWriter fileBVP;
        static StreamWriter fileTMP;

        static Socket client;
        static ulong initialTime;
        static ulong prevTime;

        // The port number for the remote device.
        private const string ServerAddress = "127.0.0.1";
        private const int ServerPort = 28000;
            //54000;

        // ManualResetEvent instances signal completion.
        private static readonly ManualResetEvent ConnectDone = new ManualResetEvent(false);
        private static readonly ManualResetEvent SendDone = new ManualResetEvent(false);
        private static readonly ManualResetEvent ReceiveDone = new ManualResetEvent(false);

        // The response from the remote device.
        private static String _response = String.Empty;

        private static String _e4Response = "";

        public static void StartClient(ulong time, string saveFileLocation)
        {
            string pathGSR = saveFileLocation + "GSR.csv";
            string pathHR = saveFileLocation + "HR.csv";
            string pathIBI = saveFileLocation + "IBI.csv";
            string pathTMP = saveFileLocation + "TMP.csv";
            string pathBVP = saveFileLocation + "BVP.csv";

            fileGSR = new StreamWriter(pathGSR, true);
            fileHR = new StreamWriter(pathHR, true);
            fileIBI = new StreamWriter(pathIBI, true);
            fileTMP = new StreamWriter(pathTMP, true);
            fileBVP = new StreamWriter(pathBVP, true);

            fileGSR.WriteLine("Time, GSR");
            fileHR.WriteLine("Time, BPM");
            fileIBI.WriteLine("Time, IBI");
            fileTMP.WriteLine("Time, TMP");
            fileBVP.WriteLine("Time, BVP");

            initialTime = time;
            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                var ipHostInfo = new IPHostEntry { AddressList = new[] { IPAddress.Parse(ServerAddress) } };
                var ipAddress = ipHostInfo.AddressList[0];
                var remoteEp = new IPEndPoint(ipAddress, ServerPort);

                // Create a TCP/IP socket.
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Connect to the remote endpoint.
                client.BeginConnect(remoteEp, (ConnectCallback), client);
                ConnectDone.WaitOne();

                // Send Initial Message
                // Device_List
                Send(client, "device_list" + Environment.NewLine);
                SendDone.WaitOne();
                Receive(client);
                ReceiveDone.WaitOne();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                var client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint);

                // Signal that the connection has been made.
                ConnectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                var state = new StateObject { WorkSocket = client };

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                var state = (StateObject)ar.AsyncState;
                var client = state.WorkSocket;

                // Read data from the remote device.
                var bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));
                    _response = state.Sb.ToString();

                    HandleResponseFromEmpaticaBLEServer(_response);

                    state.Sb.Clear();

                    ReceiveDone.Set();

                    // Get the rest of the data.
                    client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReceiveCallback, state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.Sb.Length > 1)
                    {
                        _response = state.Sb.ToString();
                    }
                    // Signal that all bytes have been received.
                    ReceiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                var client = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.
                client.EndSend(ar);
                // Signal that all bytes have been sent.
                SendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void HandleResponseFromEmpaticaBLEServer(string response)
        {
            Console.Write(response);

            string[] tokens = response.Split(new string[]{" ", "\n", Environment.NewLine}, StringSplitOptions.None);

            // switch against tokens[1]

            if (tokens[1] == "device_list")
            {
                Send(client, "device_connect " + tokens[4] + Environment.NewLine);
                SendDone.WaitOne();
            }

            if(tokens[1] == "device_connect")
            {
                

                Send(client, "device_subscribe gsr ON" + Environment.NewLine);
                SendDone.WaitOne();

                System.Threading.Thread.Sleep(200);

                Send(client, "device_subscribe ibi ON" + Environment.NewLine);
                SendDone.WaitOne();
                
                System.Threading.Thread.Sleep(200);

                Send(client, "device_subscribe tmp ON" + Environment.NewLine);
                SendDone.WaitOne();

                System.Threading.Thread.Sleep(200);
                
                Send(client, "device_subscribe bvp ON" + Environment.NewLine);
                SendDone.WaitOne();



            }

            if (tokens[0] == "E4_Gsr")
            {
                // for each token in tokens
                // if tokens %3 = 0
                for (int i = 0; i < tokens.Length; i++)
                {
                    

                    if (i % 3 == 1)
                    {
                        string time = tokens[i];
                        ulong ltime = Convert.ToUInt64(double.Parse(time) * 1000) * 1000000;
                        ltime -= initialTime;
                        //Console.Write("GSR: " + ltime + ", ");
                        fileGSR.Write(ltime + ", ");
                    }

                    if (i % 3 == 2)
                    {
                        //Console.Write(tokens[i] + Environment.NewLine);
                        fileGSR.Write(tokens[i] + Environment.NewLine);
                    }

                    fileGSR.Flush();

                }
            }

            if (tokens[0] == "E4_Hr")
            {
                if (!tokens[2].Contains("E4_Hr") && tokens[2] != "0")
                {
                    if (GetTimeSinceStart() != prevTime)
                    {
                        string time = tokens[1];
                        ulong ltime = Convert.ToUInt64(double.Parse(time) * 1000) * 1000000;
                        ltime -= initialTime;
                        fileHR.Write(ltime + ", " + tokens[2] + Environment.NewLine);
                        //Console.Write("HR: " + ltime + ", " + tokens[2] + Environment.NewLine);
                        fileHR.Flush();
                    }
                }
            }

            if (tokens[0] == "E4_Ibi")
            {
                // for each token in tokens
                // if tokens %3 = 0
                for (int i = 0; i < tokens.Length; i++)
                {


                    if (i % 3 == 1)
                    {
                        string time = tokens[i];
                        ulong ltime = Convert.ToUInt64(double.Parse(time) * 1000) * 1000000;
                        ltime -= initialTime;
                        fileIBI.Write(ltime + ", ");
                    }

                    if (i % 3 == 2)
                    {
                        fileIBI.Write(tokens[i] + Environment.NewLine);
                    }

                    fileIBI.Flush();

                }
            }

            if (tokens[0] == "E4_Bvp")
            {
                // for each token in tokens
                // if tokens %3 = 0
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (i % 3 == 1)
                    {
                        string time = tokens[i];
                        ulong ltime = Convert.ToUInt64(double.Parse(time) * 1000) * 1000000;
                        ltime -= initialTime;
                        fileBVP.Write(ltime + ", ");
                    }

                    if (i % 3 == 2)
                    {
                        fileBVP.Write(tokens[i] + Environment.NewLine);
                    }

                    fileBVP.Flush();
                }
            }

            if (tokens[0] == "E4_Temperature")
            {
                // for each token in tokens
                // if tokens %3 = 0
                for (int i = 0; i < tokens.Length; i++)
                {
                    if (i % 3 == 1)
                    {
                        string time = tokens[i];
                        ulong ltime = Convert.ToUInt64(double.Parse(time) * 1000) * 1000000;
                        ltime -= initialTime;
                        fileTMP.Write(ltime + ", ");
                    }

                    if (i % 3 == 2)
                    {
                        fileTMP.Write(tokens[i] + Environment.NewLine);
                    }

                    fileTMP.Flush();
                }
            }
        }

        private static ulong GetTimeSinceStart()
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            ulong nanoSecondsSinceEpoch = (ulong) ((DateTime.UtcNow - epochStart).Ticks * 100);
            return nanoSecondsSinceEpoch - initialTime;
        }
    }
}