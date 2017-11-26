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
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;

public class BackgroundWorkerDemo : Form {

	private const int MINIMUM = 0;
	private const int MAXIMUM = 3000;
	private const int MILLISECONDS = 1;

	private Button _button1;
	private Button _button2;
	private Button _button3;
	private Label _label1;
	private Label _label2;
	private Label _label3;
	private ProgressBar _pb1;
	private ProgressBar _pb2;
	private ProgressBar _pb3;
	private BackgroundWorker _bw1;
	private BackgroundWorker _bw2;
	private BackgroundWorker _bw3;

	public BackgroundWorkerDemo(){
		InitializeComponents();
	}

	private void InitializeComponents(){
		_button1 = new Button();
		_button2 = new Button();
		_button3 = new Button();
		_label1 = new Label();
		_label2 = new Label();
		_label3 = new Label();
		_pb1 = new ProgressBar();
		_pb2 = new ProgressBar();
		_pb3 = new ProgressBar();
		_bw1 = new BackgroundWorker();
		_bw2 = new BackgroundWorker();
		_bw3 = new BackgroundWorker();

		_button1.Text = "Do Something";
		_button1.AutoSize = true;
		_button1.Click += ButtonOneClickHandler;
		_button1.Dock = DockStyle.Fill;
		_label1.BackColor = Color.Green;
		_label1.Dock = DockStyle.Fill;
		_pb1.Minimum = 0;
		_pb1.Maximum = 3000;
		_pb1.Dock = DockStyle.Fill;
		_bw1.DoWork += DoWorkOne;
		_bw1.WorkerReportsProgress = true;
		_bw1.ProgressChanged += ReportProgressOne;
		_bw1.RunWorkerCompleted += ResetLabelOne;

		_button2.Text = "Do Something Else";
		_button2.AutoSize = true;
		_button2.Click += ButtonTwoClickHandler;
		_button2.Dock = DockStyle.Fill;
		_label2.BackColor = Color.Green;
		_label2.Dock = DockStyle.Fill;
		_pb2.Minimum = MINIMUM;
		_pb2.Maximum = MAXIMUM;
		_pb2.Dock = DockStyle.Fill;
		_bw2.DoWork += DoWorkTwo;
		_bw2.WorkerReportsProgress = true;
		_bw2.ProgressChanged += ReportProgressTwo;
		_bw2.RunWorkerCompleted += ResetLabelTwo;

		_button3.Text = "Do Something Different";
		_button3.AutoSize = true;
		_button3.Click += ButtonThreeClickHandler;
		_button3.Dock = DockStyle.Fill;
		_label3.BackColor = Color.Green;
		_label3.Dock = DockStyle.Fill;
		_pb3.Minimum = MINIMUM;
		_pb3.Maximum = MAXIMUM;
		_pb3.Dock = DockStyle.Fill;
		_bw3.DoWork += DoWorkThree;
		_bw3.WorkerReportsProgress = true;
		_bw3.ProgressChanged += ReportProgressThree;
		_bw3.RunWorkerCompleted += ResetLabelThree;
	 
		TableLayoutPanel tlp1 = new TableLayoutPanel();
		tlp1.RowCount = 3;
		tlp1.ColumnCount = 3;
		this.SuspendLayout();
		tlp1.SuspendLayout();
		tlp1.AutoSize = true;
		tlp1.Dock = DockStyle.Fill;
		tlp1.Controls.Add(_button1);
		tlp1.Controls.Add(_button2);
		tlp1.Controls.Add(_button3);
		tlp1.Controls.Add(_label1);
		tlp1.Controls.Add(_label2);
		tlp1.Controls.Add(_label3);
		tlp1.Controls.Add(_pb1);
		tlp1.Controls.Add(_pb2);
		tlp1.Controls.Add(_pb3);
		this.Controls.Add(tlp1);
		this.AutoSize = true;
		this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
		this.Height = tlp1.Height + 20;
		this.Width = tlp1.Width;
		tlp1.ResumeLayout();
		this.ResumeLayout();
	}

	private void ButtonOneClickHandler(Object sender, EventArgs e){
		if(!_bw1.IsBusy){
			_bw1.RunWorkerAsync(((Button)sender).Text);
		}
	}

	private void ButtonTwoClickHandler(Object sender, EventArgs e){
		if(!_bw2.IsBusy){     
			_bw2.RunWorkerAsync(((Button)sender).Text);
		}
	}

	private void ButtonThreeClickHandler(Object sender, EventArgs e){
		if(!_bw3.IsBusy){
			_bw3.RunWorkerAsync(((Button)sender).Text);
		}
	}

	private void DoWorkOne(Object sender, DoWorkEventArgs e){
		_label1.BackColor = Color.Black;
		for(int i=MINIMUM; i<MAXIMUM; i++){
			Console.Write(e.Argument + " ");
			Thread.Sleep(MILLISECONDS);
			_bw1.ReportProgress(i);
		}
	}
	
	private void DoWorkTwo(Object sender, DoWorkEventArgs e){
		_label2.BackColor = Color.Black;
		for(int i=MINIMUM; i<MAXIMUM; i++){
			Console.Write(e.Argument + " ");
			Thread.Sleep(MILLISECONDS);
			_bw2.ReportProgress(i);
		}
	}

	private void DoWorkThree(Object sender, DoWorkEventArgs e){
		_label3.BackColor = Color.Black;
		for(int i=MINIMUM; i<MAXIMUM; i++){
			Console.Write(e.Argument + " ");
			Thread.Sleep(MILLISECONDS);
			_bw3.ReportProgress(i);
		}
	}

	private void ReportProgressOne(object sender, ProgressChangedEventArgs e){
		_pb1.Value = e.ProgressPercentage;
	}
	
	private void ReportProgressTwo(object sender, ProgressChangedEventArgs e){
		_pb2.Value = e.ProgressPercentage;
	}
	
	private void ReportProgressThree(object sender, ProgressChangedEventArgs e){
		_pb3.Value = e.ProgressPercentage;
	}
	
	private void ResetLabelOne(Object sender, RunWorkerCompletedEventArgs e){
		_label1.BackColor = Color.Green;
		_pb1.Value = 0;
	}

	private void ResetLabelTwo(Object sender, RunWorkerCompletedEventArgs e){
		_label2.BackColor = Color.Green;
		_pb2.Value = 0;
	}

	private void ResetLabelThree(Object sender, RunWorkerCompletedEventArgs e){
		_label3.BackColor = Color.Green;
		_pb3.Value = 0;
	}

	[STAThread] // need this for Windows Vista
	public static void Main(){
		Application.Run(new BackgroundWorkerDemo());
	}// end main
} // end class definition