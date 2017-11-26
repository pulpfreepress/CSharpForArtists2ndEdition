/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class EchoServer {
	public static void Main(){
		TcpListener listener = null;
			try {
				listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
				listener.Start();
				Console.WriteLine("EchoServer started...");
				while(true){
					Console.WriteLine("Waiting for incoming client connections...");
					TcpClient client = listener.AcceptTcpClient();
					Console.WriteLine("Accepted new client connection...");
					StreamReader reader = new StreamReader(client.GetStream());
					StreamWriter writer = new StreamWriter(client.GetStream());
					string s = string.Empty;
					while(!(s = reader.ReadLine()).Equals("Exit") || (s == null)){
						Console.WriteLine("From client -> " + s);
						writer.WriteLine("From server -> " + s);
						writer.Flush();
					}
					reader.Close();
					writer.Close();
					client.Close();
				}
			} catch(Exception e){
					Console.WriteLine(e);
			} finally{
					if(listener != null){
						listener.Stop();
					}
			}
  } // end Main()
} // end class definition