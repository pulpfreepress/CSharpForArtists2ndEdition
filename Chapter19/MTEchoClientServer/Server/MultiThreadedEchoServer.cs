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
using System.Threading;

public class MultiThreadedEchoServer {
  
	private static void ProcessClientRequests(object argument){
		TcpClient client = (TcpClient)argument;
		try {
			StreamReader reader = new StreamReader(client.GetStream());
			StreamWriter writer = new StreamWriter(client.GetStream());
			string s = String.Empty;
			while(!(s = reader.ReadLine()).Equals("Exit") || (s == null)){
				Console.WriteLine("From client -> " + s);
				writer.WriteLine("From server -> " + s);
				writer.Flush();
			}
			reader.Close();
			writer.Close();
			client.Close();
			Console.WriteLine("Closing client connection!");
		} catch(IOException){
				Console.WriteLine("Problem with client communication. Exiting thread.");
		} finally{
				if(client != null){
					client.Close();
				}
		}    
	}

	public static void Main(){
		TcpListener listener = null;
		try {
			listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
			listener.Start();
			Console.WriteLine("MultiThreadedEchoServer started...");
			while(true){
				Console.WriteLine("Waiting for incoming client connections...");
				TcpClient client = listener.AcceptTcpClient();
				Console.WriteLine("Accepted new client connection...");
				Thread t = new Thread(ProcessClientRequests);
				t.Start(client);
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