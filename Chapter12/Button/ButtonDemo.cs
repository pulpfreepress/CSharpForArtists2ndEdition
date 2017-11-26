/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

/**********************************************************************************
  This example supports figure 12-7 in chapter 12.
**********************************************************************************/


using System;
using System.Windows.Forms;
using System.Drawing;

public class ButtonDemo : Form {

   private Button _button1;
	 
	 public ButtonDemo(){
	   _button1 = new Button();
		 _button1.Text = "Click Me!";
		 _button1.Location = new Point(125, 125);
		 _button1.Size = new Size(300, 100);
		 this.Location = new Point(100, 275);
		 this.Size = new Size(600, 350);
		 this.Controls.Add(_button1);
		 
	 }

    public static void Main(){
		  Application.Run(new ButtonDemo());
			
		} // end Main
} // end class definition