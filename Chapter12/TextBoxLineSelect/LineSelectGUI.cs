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
using System.Windows;



public class LineSelectGUI : Form {

   private TextBox _tb1;
   private TextBox _tb2;
   private FlowLayoutPanel _flowLayoutPanel;
   
   public LineSelectGUI(MainApp ma, int x, int y, int width, int height){ 
		 this.Bounds = new Rectangle(x, y, width, height);
		 this.Text = "LineSelectGUI Window"; 
		 InitializeComponents(ma);
	 }
	 
	 public LineSelectGUI(MainApp ma):this(ma, 125, 125, 375, 200){ }
	 
	 public void InitializeComponents(MainApp ma){
   
     _flowLayoutPanel = new FlowLayoutPanel();
         
     _flowLayoutPanel.SuspendLayout();
     
     _flowLayoutPanel.Height = 56;
     _flowLayoutPanel.Width = 20;
     _flowLayoutPanel.AutoSize = true;
     _flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
     _flowLayoutPanel.WrapContents = true;
     _flowLayoutPanel.Dock = DockStyle.Top;
   
     _tb1 = new TextBox();
     _tb1.Multiline = true;
     _tb1.Height = 150;
     _tb1.Width = 200;
     _tb1.DoubleClick += ma.DoubleClickHandler;
     
     _tb2 = new TextBox();
      _flowLayoutPanel.Controls.Add(_tb1);    
      _flowLayoutPanel.Controls.Add(_tb2);  
      
     this.SuspendLayout();
     this.Controls.Add(_flowLayoutPanel);
         
     _flowLayoutPanel.ResumeLayout();
     this.ResumeLayout();
   }
   
   
   public void ShowLineNumber(){
		  int index = _tb1.SelectionStart;
		  int line_number = _tb1.GetLineFromCharIndex(index);
      _tb2.Text = ("Line Number is: " + line_number);
	 }
   
} // end LineSelectGUI class definition
