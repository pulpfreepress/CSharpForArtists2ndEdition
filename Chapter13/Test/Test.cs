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

public class Test : Form {
	private PictureBox _pictureBox;
	private Graphics _graphics;
	private TextBox _textbox;
	private Button _fillButton;
	private Button _drainButton;
	private Image _image;
	private FlowLayoutPanel _panel;
	private Point _bottomLeft, _bottomRight;
	
	
	public Test(){
		
		
		_pictureBox = new PictureBox();
		_image = new Bitmap("WCC_2.jpg");
		_pictureBox.Size = _image.Size;
		_graphics = _pictureBox.CreateGraphics();
		_bottomLeft = new Point(_pictureBox.Left, _pictureBox.Bottom);
		_bottomRight = new Point(_pictureBox.Right, _pictureBox.Bottom);
		
		_panel = new FlowLayoutPanel();
		_panel.Dock = DockStyle.Top;
		_panel.Height = _image.Height;
		
		_textbox = new TextBox();
		_fillButton = new Button();
		_fillButton.Text = "Fill Tank";
		_fillButton.MouseMove += new MouseEventHandler(FillTank);
		
		_drainButton = new Button();
		_drainButton.Text = "Drain Tank";
		_drainButton.MouseMove += new MouseEventHandler(DrainTank);
		
		_panel.Controls.Add(_pictureBox);
		_panel.Controls.Add(_fillButton);
		_panel.Controls.Add(_drainButton);
		this.Controls.Add(_panel);
	}
	
  public void FillTank(Object sender, MouseEventArgs e){
	  Pen bluePen = new Pen(Color.Blue, 3);
		// Create points that define line.
		Point point1 = _bottomLeft;
		Point point2 = _bottomRight;
		
		_bottomLeft.Y--;
		_bottomRight.Y--;
		             
	// Draw line to screen.
		_graphics.DrawLine(bluePen, point1, point2);
		//this.Refresh();

	}
	
	public void DrainTank(Object sender, MouseEventArgs e){
		  Pen whitePen = new Pen(Color.White, 3);
			// Create points that define line.
			Point point1 = _bottomLeft;
			Point point2 = _bottomRight;
			
			_bottomLeft.Y++;
			_bottomRight.Y++;
			             
		// Draw line to screen.
			_graphics.DrawLine(whitePen, point1, point2);
			//this.Refresh();
	
	}
	
	public static void Main(){
		Application.Run(new Test());
	}
} // end class definition