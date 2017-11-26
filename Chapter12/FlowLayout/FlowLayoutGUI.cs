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

public class FlowLayoutGUI : Form {
	
	private Button[] _buttonArray;
	private FlowLayoutPanel _panel;
	
	public FlowLayoutGUI(MainApp ma, int x, int y, int width, int height){
		this.Bounds = new Rectangle(x, y, width, height);
		this.Text = "Flow Layout GUI";
		InitializeComponents(ma);
	}
	
	public FlowLayoutGUI(MainApp ma):this(ma, 100, 200, 425, 150){ }
	
	public void InitializeComponents(MainApp ma){
		_panel = new FlowLayoutPanel();
		_panel.SuspendLayout();
		_panel.AutoSize = true;
		_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_panel.WrapContents = true;
		//_panel.BackColor = Color.Blue; // to see the effects of DockStyle.Top uncomment this line
		_panel.Dock = DockStyle.Top;
		
		_buttonArray = new Button[5];
		
		for(int i=0; i<_buttonArray.Length; i++){
			_buttonArray[i] = new Button();
			_buttonArray[i].Text = "Button " + (i+1);
			_buttonArray[i].Click += ma.ButtonClickHandler;
			_panel.Controls.Add(_buttonArray[i]);
		}
		
		this.SuspendLayout();
		this.Controls.Add(_panel);
		
		_panel.ResumeLayout();
		this.ResumeLayout();
	}
} // end FlowLayoutGUI class definition