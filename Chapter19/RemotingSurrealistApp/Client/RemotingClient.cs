/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

public class RemotingClient {
	public static void Main(){
		try {
			RemotingConfiguration.Configure("client.config", false);
			WellKnownClientTypeEntry[] client_types = 
						RemotingConfiguration.GetRegisteredWellKnownClientTypes(); 
			ISurrealistServer surrealist_server = 
						(ISurrealistServer)Activator.GetObject(typeof(ISurrealistServer), 
						client_types[0].ObjectUrl );

			List<Person> surrealists = surrealist_server.GetSurrealists();
			foreach(Person p in surrealists){
				Console.WriteLine(p);
			}
		} catch(Exception e){
				Console.WriteLine(e);
		}
	}
}