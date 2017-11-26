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

public class EchoClient {
	public static void Main(String[] args){
		IPAddress ip_address = IPAddress.Parse("127.0.0.1"); //default
		int port = 8080;
		try{
			if(args.Length >= 1){
				ip_address = IPAddress.Parse(args[0]);
			}
		} catch(FormatException){
				Console.WriteLine("Invalid IP address entered. Using default IP of: " 
													+ ip_address.ToString());
		}
		try {
			Console.WriteLine("Attempting to connect to server at IP address: {0} port: {1}", 
												ip_address.ToString(), port); 
			TcpClient client = new TcpClient(ip_address.ToString(), port);
			Console.WriteLine("Connection successful!");
			StreamReader reader = new StreamReader(client.GetStream());
			StreamWriter writer = new StreamWriter(client.GetStream());
			string s = String.Empty;
			while(!s.Equals("Exit")){
				Console.Write("Enter a string to send to the server: ");
				s = Console.ReadLine();
				Console.WriteLine(); 
				writer.WriteLine(s);
				writer.Flush();
				if(!s.Equals("Exit")){
					String server_string = reader.ReadLine();
					Console.WriteLine(server_string);
				}
			}
			reader.Close();
			writer.Close();
			client.Close();
		} catch(Exception e){
				Console.WriteLine(e);
		}
	} // end Main()
} // end class definition