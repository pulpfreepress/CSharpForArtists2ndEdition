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

public class RemotingServer {
	public static void Main(){
		try {
			RemotingConfiguration.Configure("server.config", false);
			Console.WriteLine("Listening for remote requests. Press enter or return to exit...");
			Console.ReadLine();
		} catch(Exception e){
				Console.WriteLine(e);
		}
	}
}