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
using System.Drawing;

public class FormPropertiesDemo : Form {
	public static void Main(String[] args){
		FormPropertiesDemo fpd = new FormPropertiesDemo();
		if(args.Length > 0){
			try{
		    Image image = new Bitmap(args[0]);
		    fpd.BackgroundImage = image;
		    fpd.Size = image.Size;
		  }catch(Exception){
			  //ignore for now
		  }
		}else{
			fpd.BackColor = Color.Black;
		}
		
		fpd.Text = "Form Properties Demo";
		Application.Run(fpd);
		
	} // end Main()
} // end class