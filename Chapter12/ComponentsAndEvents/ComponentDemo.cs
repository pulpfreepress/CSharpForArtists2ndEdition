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


public class ComponentDemo : Form {
	private Button _button1;
	private TextBox _textbox1;
	private Label _label1;
	
	public ComponentDemo(int x, int y, int width, int height){
		this.Bounds = new Rectangle(x, y, width, height);
		this.Text = "Component Demo";
		InitializeComponents();
	}
	
	public ComponentDemo():this(100, 200, 400, 200){ }
	
	private void InitializeComponents(){
		_label1 = new Label();
		_label1.Text = "This is a Label!";
		_label1.Location = new Point(25, 25);
		
		_button1 = new Button();
		_button1.Text = "Click Me!";
		_button1.Location = new Point(125, 25);
		_button1.Click += ButtonClickHandler;
		
		_textbox1 = new TextBox();
		_textbox1.Text = "some default text";
		_textbox1.Location = new Point(225, 25);
		
		this.Controls.Add(_label1);
		this.Controls.Add(_button1);
		this.Controls.Add(_textbox1);
	}
	
	
	public void ButtonClickHandler(Object sender, EventArgs e){
		_label1.Text = _textbox1.Text;
	}
	
	
	public static void Main(){
		Application.Run(new ComponentDemo());
	} // end Main()
} // end class