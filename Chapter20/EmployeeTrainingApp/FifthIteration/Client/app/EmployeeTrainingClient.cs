/********************************************************************************
  Copyright 2008 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Remoting;
using EmployeeTraining.VO;

public class EmployeeTrainingClient : Form {

	// Constants
	private const int WINDOW_HEIGHT = 500;
	private const int WINDOW_WIDTH = 900;
	private const String WINDOW_TITLE = "Employee Training Application";

	// fields
	private IEmployeeTraining _employeeTraining = null;
	private List<EmployeeVO> _employeeList = null;
	private TableLayoutPanel _tablePanel = null;
	private DataGridView _employeeGrid = null;
	private DataGridView _trainingGrid = null;
	private PictureBox _pictureBox = null;

	public EmployeeTrainingClient(IEmployeeTraining employeeTraining){
		_employeeTraining = employeeTraining;
		this.InitializeComponent();
	}

	private void InitializeComponent(){
		// setup the menus
		MenuStrip ms = new MenuStrip();
		
		ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
		ToolStripMenuItem exitMenuItem = 
				new ToolStripMenuItem("Exit", null, this.ExitProgramHandler);

		ToolStripMenuItem createMenu = new ToolStripMenuItem("Create");
		ToolStripMenuItem employeeMenuItem = 
				new ToolStripMenuItem("Employee...", null,  this.CreateEmployeeHandler);
		ToolStripMenuItem trainingMenuItem = 
				new ToolStripMenuItem("Training...", null, this.CreateTrainingHandler);

		fileMenu.DropDownItems.Add(exitMenuItem);
		ms.Items.Add(fileMenu);

		createMenu.DropDownItems.Add(employeeMenuItem);
		createMenu.DropDownItems.Add(trainingMenuItem);
		ms.Items.Add(createMenu);

		// create the table panel
		_tablePanel = new TableLayoutPanel();
		_tablePanel.RowCount = 2;
		_tablePanel.ColumnCount = 2;
		_tablePanel.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | 
													AnchorStyles.Left | AnchorStyles.Right;
		_tablePanel.Dock = DockStyle.Top;
		_tablePanel.Height = 400;

		// create and initialize the data grids
		_employeeGrid = new DataGridView();
		_employeeGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_employeeGrid.Height = 200;
		_employeeGrid.Width = 700;
		_employeeList = _employeeTraining.GetAllEmployees();
		_employeeGrid.DataSource = _employeeList;
		_employeeGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													 AnchorStyles.Left | AnchorStyles.Right;
		_employeeGrid.Click += this.EmployeeGridClickedHandler;

		_trainingGrid = new DataGridView();
		_trainingGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_trainingGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													 AnchorStyles.Left | AnchorStyles.Right;

		// create picture box
		_pictureBox = new PictureBox();
		_pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												 AnchorStyles.Left | AnchorStyles.Right;
  
		//add grids to table panel
		_tablePanel.Controls.Add(_employeeGrid);
		_tablePanel.Controls.Add(_pictureBox);
		_tablePanel.Controls.Add(_trainingGrid);
		_tablePanel.SetColumnSpan(_trainingGrid, 2);

		this.Controls.Add(_tablePanel);
		ms.Dock = DockStyle.Top;
		this.MainMenuStrip = ms;
		this.Controls.Add(ms);
		this.Height = WINDOW_HEIGHT;
		this.Width = WINDOW_WIDTH;
		this.Text = WINDOW_TITLE;
	}

	/************************************************************
		Event Handlers
	*************************************************************/
	private void ExitProgramHandler(Object sender, EventArgs e){
		Application.Exit();
	}

	private void CreateEmployeeHandler(Object sender, EventArgs e){
		// add code here
	}

	private void CreateTrainingHandler(Object sender, EventArgs e){
		// add code here
	}

	private void EmployeeGridClickedHandler(Object sender, EventArgs e){
		int selected_row = _employeeGrid.SelectedRows[0].Index;
		byte[] pictureBytes = _employeeList[selected_row].Picture;

		if(pictureBytes !=  null){
			MemoryStream ms = new MemoryStream();
			ms.Write(pictureBytes, 0, pictureBytes.Length);
			_pictureBox.Image = new Bitmap(ms);      
		} else {
				_pictureBox.Image = null;
		}
		Console.WriteLine(selected_row);
		Console.WriteLine(_employeeList[selected_row]);
		_trainingGrid.DataSource = null;
		_trainingGrid.DataSource = 
				_employeeTraining.GetTrainingForEmployee(_employeeList[selected_row].EmployeeID);
	}

	public static void Main(){
		try {
			RemotingConfiguration.Configure("EmployeeTrainingClient.exe.config", false);
			WellKnownClientTypeEntry[] client_types = 
					RemotingConfiguration.GetRegisteredWellKnownClientTypes(); 
			IEmployeeTraining employee_training = 
					(IEmployeeTraining)Activator.GetObject(typeof(IEmployeeTraining), 
																								 client_types[0].ObjectUrl );
			EmployeeTrainingClient client = new EmployeeTrainingClient(employee_training);
			Application.Run(client);
		} catch(Exception e){
				Console.WriteLine(e);
		}
	}
}