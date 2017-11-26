/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class RemotingServer {
	public static void Main(){
		try{
			TcpChannel channel = new TcpChannel(8080);
			ChannelServices.RegisterChannel(channel, false);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(TestClass), 
											"TestClass", WellKnownObjectMode.SingleCall);
			Console.WriteLine("Listening for remote requests. Press enter or return to exit...");
			Console.ReadLine();
		} catch(ArgumentNullException ane){
				Console.WriteLine("Channel argument was null!");
				Console.WriteLine(ane);
		} catch(RemotingException re){
				Console.WriteLine("Channel has already been registered!");
				Console.WriteLine(re);
		} catch(Exception e){
				Console.WriteLine(e);
		}
	}
}