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
	
	private MenuGUI _gui;
	private DateTime _appStart;
	
	public MainApp(){
		_gui = new MenuGUI(this);
		_appStart = DateTime.Now;
	}
	
	public void AddButtonItemHandler(object sender, EventArgs e){
		_gui.AddButton(this);
	}
		
	public void AddTextBoxItemHandler(object sender, EventArgs e){
		_gui.AddTextBox(this);
	}
		
	public void AddExitItemHandler(object sender, EventArgs e){
		Application.Exit();
	}
	
	public void ButtonClickHandler(Object sender, EventArgs e){
		((Button)sender).Text = (DateTime.Now - _appStart).ToString();
	}
	
	public void TextBoxClickHandler(Object sender, EventArgs e){
		((TextBox)sender).Text = (DateTime.Now - _appStart).ToString();
	}
	
	public static void Main(){
		MainApp ma = new MainApp();
		Application.Run(ma._gui);
	}
}