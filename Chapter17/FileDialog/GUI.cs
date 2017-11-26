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

public class GUI : Form {
	private SplitContainer _splitContainer1;
	private TextBox _textBox1;
	private Button _button1; 

	public string TextBoxText {
		get { return _textBox1.Text;  }
		set { _textBox1.Text = value; }
	}  
     
	public GUI(MainApp ma){
		this.InitializeComponent(ma);
	}  
 
	private void InitializeComponent(MainApp ma) {
		_splitContainer1 = new SplitContainer();
		_textBox1 = new TextBox();
		_button1 = new Button();
		_splitContainer1.Panel1.SuspendLayout();
		_splitContainer1.Panel2.SuspendLayout();
		_splitContainer1.SuspendLayout();
		this.SuspendLayout();
      
		_splitContainer1.Dock = DockStyle.Fill;
		_splitContainer1.Location = new Point(0, 0);  
		_splitContainer1.Panel1.Controls.Add(_textBox1);
		_splitContainer1.Panel2.Controls.Add(_button1);
		_splitContainer1.Size = new Size(292, 273);
		_splitContainer1.SplitterDistance = 161;
		_splitContainer1.TabIndex = 0;
      
		_textBox1.Location = new Point(3, 3);
		_textBox1.AutoSize = true;
		_textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom 
											| AnchorStyles.Left | AnchorStyles.Right;
		_textBox1.Multiline = true;
		_textBox1.Name = "textBox1";
		_textBox1.Size = new Size(155, 267);
		_textBox1.TabIndex = 0;
       
		_button1.Location = new Point(27, 12);
		_button1.Size = new Size(75, 23);
		_button1.TabIndex = 0;
		_button1.Text = "Open File";
		_button1.UseVisualStyleBackColor = true;
		_button1.Click += ma.Button1ClickHandler;
      
		this.AutoScaleMode = AutoScaleMode.None;
		this.ClientSize = new Size(292, 273);
		this.Controls.Add(_splitContainer1);

		this.Text = "FileDialog Demo";
		_splitContainer1.Panel1.ResumeLayout(false);
		_splitContainer1.Panel1.PerformLayout();
		_splitContainer1.Panel2.ResumeLayout(false);
		_splitContainer1.ResumeLayout(false);
		this.ResumeLayout(false);
	} // End InitializeComponent()
} // End class definition