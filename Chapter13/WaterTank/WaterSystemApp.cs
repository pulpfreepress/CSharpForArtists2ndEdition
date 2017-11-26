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

public class WaterSystemApp : Form {
	
	private FlowLayoutPanel _panel;
	private Button _button;
	private WaterTank _tank;
	
	public WaterSystemApp(){
		this.InitializeComponents();
	}
	
	private void InitializeComponents(){
		_tank = new WaterTank();
		_button = new Button();
		_button.Text = "Add Water";
		_button.Click += new EventHandler(this.AddWaterButtonClick);		
		_button.Dock = DockStyle.Bottom;
		_panel = new FlowLayoutPanel();
		_panel.SuspendLayout();
		_panel.FlowDirection = FlowDirection.TopDown;
		_panel.AutoSize = true;
		_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_panel.Height = _tank.Height + _button.Height + 75;
		_panel.Controls.Add(_tank);
		_panel.Controls.Add(_button);
		this.SuspendLayout();
		this.Text = "Water System";
		this.Height = _panel.Height;
	  this.Width = _tank.Width;
		this.Controls.Add(_panel);
		_panel.ResumeLayout();
		this.ResumeLayout();
	}
	
	
	public void AddWaterButtonClick(object sender, EventArgs e){
	   _tank.ChangeWaterLevel(_tank.FillRate);	
	}
	
	public static void Main(){
		Application.Run(new WaterSystemApp());
	}
	
}