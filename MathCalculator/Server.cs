using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace MathCalculator
{
    class Server
    {
        public void Start()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            TcpListener serverSocket = new TcpListener(ip, port: 3001);
            serverSocket.Start();
            Console.WriteLine("Server started");

            TcpClient connectionSocket = serverSocket.AcceptTcpClient();

            DoClient(connectionSocket);

            serverSocket.Stop();
        }

        public void DoClient(TcpClient connectionSocket)
        {
            Console.WriteLine("Server activated");

            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string line = sr.ReadLine();
            string[] besked = line.Split(" ");
            int tal1 = Int32.Parse(besked[0]);
            int tal2 = Int32.Parse(besked[1]);
            Console.WriteLine(tal1 + tal2);

            //string message = sr.ReadLine();
            //string answer = "";

            //Console.WriteLine("Client: " + message);
            //answer = message.ToUpper();
            //sw.WriteLine(answer);
            //message = sr.ReadLine();

            ns.Close();
            connectionSocket.Close();
        }
    }
}