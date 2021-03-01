﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace EchoClient
{
    class Client
    {
        public void Start()
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            TcpClient socket = new TcpClient("localhost", 3001);

            Stream ns = socket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            string message = Console.ReadLine();
            sw.WriteLine(message);
            string serverAnswer = sr.ReadLine();
            Console.WriteLine("Server: " + serverAnswer);

            ns.Close();

            socket.Close();
        }
    }
}
