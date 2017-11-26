/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SurrealistEchoServer {

	private static void ProcessClientRequests(object argument){
		TcpClient client = (TcpClient)argument;
		try {
			StreamReader reader = new StreamReader(client.GetStream());
			StreamWriter writer = new StreamWriter(client.GetStream());
			string s = String.Empty;
			while(!((s = reader.ReadLine()).Equals("Exit") || (s == null))){
				switch(s){
					case "GetSurrealists" : {
						Console.WriteLine("From client -> " + s);
						SerializeSurrealists(client.GetStream());
						client.GetStream().Flush();
						break;
					}
					default: {
						Console.WriteLine("From client -> " + s);
						writer.WriteLine("From server -> " + s);
						writer.Flush();
						break;
					}
				} // end switch
			} // end while
			reader.Close();
			writer.Close();
			client.Close();
			Console.WriteLine("Client connection closed!");
		} catch(IOException){
				Console.WriteLine("Problem with client communication. Exiting thread.");
		} catch(NullReferenceException){
				Console.WriteLine("Incoming string was null! Client may have terminated prematurly.");
		} catch(Exception e){
				Console.WriteLine("Unknown exception occured.");
				Console.WriteLine(e);
		} finally{
				if(client != null){
					client.Close();
				}
		}    
	} // end ProcessClientRequests()

	private static void SerializeSurrealists(NetworkStream stream){
		SurrealistDB db = new SurrealistDB();
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(stream, db.GetSurrealists());
	} // end SerializeSurrealists()

	private static void ShowServerNetworkConfig(){  
		Console.ForegroundColor = ConsoleColor.Yellow;
		NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
		foreach(NetworkInterface adapter in adapters){
			Console.WriteLine(adapter.Description);
			Console.WriteLine("\tAdapter Name: " + adapter.Name);
			Console.WriteLine("\tMAC Address: " + adapter.GetPhysicalAddress());
			IPInterfaceProperties ip_properties = adapter.GetIPProperties();
			UnicastIPAddressInformationCollection addresses = ip_properties.UnicastAddresses;
			foreach(UnicastIPAddressInformation address in addresses){
				Console.WriteLine("\tIP Address: " + address.Address);
			}
		}
		Console.ForegroundColor = ConsoleColor.White;
	} // end ShowServerNetworkConfig()

	public static void Main(){
		TcpListener listener = null;
		try {
			ShowServerNetworkConfig();
			listener = new TcpListener(IPAddress.Any, 8080);
			listener.Start();
			Console.WriteLine("SurrealistEchoServer started...");
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