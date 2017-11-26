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

public class MessagePumpDemo : Form, IMessageFilter {
	
	private Button _button1;
	
	public MessagePumpDemo(){
	  _button1 = new Button();
		_button1.Text = "Click Me!";
		_button1.Click += ClickHandler;
		this.Controls.Add(_button1);
	}
	
	public void ClickHandler(object sender, EventArgs e){
	  Console.WriteLine("Button clicked!");
	}
	
	public bool PreFilterMessage(ref Message m){
		Console.WriteLine(m);
		return false;
	}
	
	public static void Main(){
		MessagePumpDemo mpd = new MessagePumpDemo();
		Application.AddMessageFilter(mpd);
		Application.Run(mpd);
	}
}