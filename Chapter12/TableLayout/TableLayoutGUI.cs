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

public class TableLayoutGUI : Form {

   Button[,] _floor = new Button[10,10];
   TableLayoutPanel _panel;
   
   public TableLayoutGUI(MainApp ma){
     InitializeComponents(ma);   
	 }
      
public void InitializeComponents(MainApp ma){
     _panel = new TableLayoutPanel();
     _panel.SuspendLayout();
		 _panel.ColumnCount = 10;
     _panel.RowCount = 10;
     _panel.Dock = DockStyle.Top;
		 _panel.AutoSize = true;
     _panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
     
     for(int i = 0; i<_floor.GetLength(0); i++){
       for(int j = 0; j<_floor.GetLength(1); j++){
         _floor[i,j] = new Button();
         _floor[i,j].Click += ma.MarkSpace;
         _panel.Controls.Add(_floor[i,j]);
       }
     }
     
    this.SuspendLayout();
    this.Text = "TableLayoutGUI Window";
    this.Width = 850;
    this.Height = 325;
    this.Controls.Add(_panel);
    _panel.ResumeLayout();
    this.ResumeLayout();
   } // end InitializeComponents() method
   
} // end TableLayoutGUI class definition
