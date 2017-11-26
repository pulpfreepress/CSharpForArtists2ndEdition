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

public class MenuGUI : Form {
	
	private FlowLayoutPanel _panel;
	
	
	public MenuGUI(MainApp ma, int x, int y, int width, int height){
		this.Bounds = new Rectangle(x, y, width, height);
		this.Text = "MenuGUI Window";
		InitializeComponents(ma);
	}
	
	public MenuGUI(MainApp ma):this(ma, 125, 125, 300, 300){ }
	
	
	private void InitializeComponents(MainApp ma){
		MenuStrip ms = new MenuStrip();
		
		ToolStripMenuItem addMenu = new ToolStripMenuItem("Add");
		ToolStripMenuItem addButtonItem = new ToolStripMenuItem("Button", null, ma.AddButtonItemHandler);
		
		ToolStripMenuItem addTextBoxItem = new ToolStripMenuItem("TextBox", null, ma.AddTextBoxItemHandler);
		
		ToolStripMenuItem addExitItem = new ToolStripMenuItem("Exit", null, ma.AddExitItemHandler);
		
		addMenu.DropDownItems.Add(addButtonItem);
		addMenu.DropDownItems.Add(addTextBoxItem);
		addMenu.DropDownItems.Add("-"); // <---- use a dash to add menu item separators
		addMenu.DropDownItems.Add(addExitItem);
		
		ms.Items.Add(addMenu);
		ms.Dock = DockStyle.Top;
		this.MainMenuStrip = ms;
		
		_panel = new FlowLayoutPanel();
	  _panel.SuspendLayout();
		_panel.AutoSize = true;
		_panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		_panel.WrapContents = true;
		_panel.Dock = DockStyle.Fill;
		//_panel.BackColor = Color.Blue;
		
		this.SuspendLayout();
		this.Controls.Add(_panel);
		this.Controls.Add(ms); // IMPORTANT: Add the MenuStrip last!!
		_panel.ResumeLayout();
		this.ResumeLayout();
		
	}
	
	public void AddButton(MainApp ma){
		Button b = new Button();
		b.Text = "C# Rocks";
		b.Click += ma.ButtonClickHandler;
		_panel.SuspendLayout();
		_panel.Controls.Add(b);
		_panel.ResumeLayout();
	}
	
	public void AddTextBox(MainApp ma){
		TextBox t = new TextBox();
		t.Text = "Default Text";
		t.Click += ma.TextBoxClickHandler;
		_panel.SuspendLayout();
		_panel.Controls.Add(t);
		_panel.ResumeLayout();
	}
} // end MenuGUI class definition