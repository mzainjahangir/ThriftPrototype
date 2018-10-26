using System;
using System.Threading;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;

namespace ThriftPrototype
{
    internal class GamePlatformServer
    {
        private static void Main()
        {
            GamePlatform.Client client = null;
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "Start":
                        var thread = new Thread(StartServer);
                        thread.Start();
                        break;
                    case "Connect":
                        Console.WriteLine("Connecting to Unity...");
                        var transport = new TSocket("localhost", 9091);
                        var protocol = new TBinaryProtocol(transport);
                        client = new GamePlatform.Client(protocol);
                        transport.Open();
                        break;
                    case "Send":
                        Console.WriteLine("Message Sent From Server");
                        if (client != null)
                        {
                            client.SendMessageFromPlatform();
                        }
                        break;
                    case "q":
                    {

                        Environment.Exit(0);
                    }
                        break;
                }
            }
        }

        private static void StartServer()
        {
            var handler = new GameUiHandler();
            var processor = new GameUi.Processor(handler);
            var serverTransport = new TServerSocket(9090);
            var server = new TSimpleServer(processor, serverTransport);
            Console.WriteLine("Starting Platform Server");
            server.Serve();
        }
    }
}