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

public class ShowBounds : Form, IMessageFilter {
	
	public bool PreFilterMessage(ref Message m){
		Console.WriteLine(this.Bounds);
		return false;
	}
	
	public static void Main(){
		ShowBounds sb = new ShowBounds();
		Application.AddMessageFilter(sb);
		Application.Run(sb);
	}
}