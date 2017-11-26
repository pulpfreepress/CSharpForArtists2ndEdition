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
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using EmployeeTraining.VO;

public class EmployeeTrainingClient {
	public static void Main(){
		try {
			RemotingConfiguration.Configure("EmployeeTrainingClient.exe.config", false);
			WellKnownClientTypeEntry[] client_types = 
					RemotingConfiguration.GetRegisteredWellKnownClientTypes(); 
			IEmployeeTraining employee_training = 
					(IEmployeeTraining)Activator.GetObject(typeof(IEmployeeTraining), 
																								client_types[0].ObjectUrl );
			Console.WriteLine("Remote EmployeeTraining object successfully created!");
			List<EmployeeVO> employee_list = employee_training.GetAllEmployees();
			foreach(EmployeeVO emp in employee_list){
				Console.WriteLine(emp.FirstName + " " + emp.MiddleName + " " + emp.LastName);
			}
		}catch(Exception e){
			Console.WriteLine(e);
		}
	}
}