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
using System.Text;
using System.IO;

public class MainApp {
	private OpenFileDialog _fileDialog;
	private GUI _gui;

	public MainApp(){
		_gui = new GUI(this);
		_fileDialog = new OpenFileDialog();
		_fileDialog.Multiselect = true;
	}

	public void Button1ClickHandler(Object o, EventArgs e){
		_fileDialog.ShowDialog();
		String[] filenames = _fileDialog.FileNames;
		StringBuilder sb = new StringBuilder();
		foreach(String s in filenames){
			FileInfo file = new FileInfo(s);
			sb.Append("FileName:" +  file.Name + "\r\n");
			sb.Append("Directory:" + file.DirectoryName + "\r\n");
			sb.Append("Size:" + file.Length + " Bytes\r\n");
			sb.Append("\r\n");
		}
		_gui.TextBoxText = sb.ToString();
  }

	[STAThread]
	public static void Main(){
		MainApp ma = new MainApp();
		Application.Run(ma._gui);
	} // end Main()
} // end class