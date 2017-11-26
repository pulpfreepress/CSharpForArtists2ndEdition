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

public class MainApp {
	
	private LineSelectGUI _gui;
	
	public MainApp(){
		_gui = new LineSelectGUI(this);
	}
	
	public void DoubleClickHandler(Object sender, EventArgs args){
	   _gui.ShowLineNumber();  
   }
   
	public static void Main(){
		MainApp ma = new MainApp();
		Application.Run(ma._gui);
	}
}