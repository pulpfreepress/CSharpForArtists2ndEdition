/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Drawing;
using System.Windows.Forms;

public class View : Form, IView {
	
	private Button button;
	private Label label;
  private TableLayoutPanel panel;

	public View(IController c){
		button = new Button();
		button.Text = "Next Message";
		button.Name = "NextMessage";
		button.Click += c.CommandHandler;
		button.Dock = DockStyle.Fill;
		label = new Label();
		label.Text = "";
		label.Font = new Font(label.Font, FontStyle.Bold);
		label.Height = 50;
		label.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
									 AnchorStyles.Left | AnchorStyles.Right;
		label.TextAlign = ContentAlignment.MiddleCenter;
		panel = new TableLayoutPanel();
		panel.RowCount = 2;
		panel.ColumnCount = 1;
		panel.Dock = DockStyle.Top;
		panel.Height = 100;
		panel.Controls.Add(label);
		panel.Controls.Add(button);
		this.Controls.Add(panel);
		this.Text = "Inspirational Messages";
		this.Width = 400;
		this.Height = 125;
		this.Visible = true;
	}

	public void SetMessage(String message){
		label.Text = message;
	}
} // end View class definition