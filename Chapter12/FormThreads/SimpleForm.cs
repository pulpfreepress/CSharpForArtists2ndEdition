/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;




public class ThreadApp : Form {

	public void Run(){
		 Application.Run(this);
	}
	
	public static void Main(){
	 
	  ThreadApp app = new ThreadApp();
		Thread t = new Thread(app.Run);
		ThreadApp app2 = new ThreadApp();
		Thread t2 = new Thread(app2.Run);
		t.Name = "First Thread";
		app.Text = t.Name;
	  t.Start();
	
	  t2.Name = "Second Thread";
	  app2.Text = t2.Name;
	  t2.Start();
	  
		Process proc = Process.GetCurrentProcess();
		ProcessThreadCollection threads = proc.Threads;
		
	
		//app.Text  = "Thread ID " +  threads[threads.Count-2].Id;
		//app2.Text = "Thread ID " + threads[threads.Count-1].Id;
		
		
		
		foreach(ProcessThread pt in threads){
			Console.WriteLine("Process Name: " + proc.ProcessName +  " Thread ID: " + pt.Id + " Thread Container: " + pt.Container);
		}
		
	}
}