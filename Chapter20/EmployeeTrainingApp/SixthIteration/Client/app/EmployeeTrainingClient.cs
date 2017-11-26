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
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Remoting;
using EmployeeTraining.VO;

public class EmployeeTrainingClient : Form {

	// Constants
	private const int WINDOW_HEIGHT = 500;
	private const int WINDOW_WIDTH = 900;
	private const String WINDOW_TITLE = "Employee Training Application";
	private const bool DEBUG = false;

	// fields
	private MenuStrip _ms;
	private ToolStripMenuItem _fileMenu;
	private ToolStripMenuItem _exitMenuItem;
	private ToolStripMenuItem _editMenu;
	private ToolStripMenuItem _createEmployeeMenuItem;
	private ToolStripMenuItem _createTrainingMenuItem;
	private ToolStripMenuItem _editEmployeeMenuItem;
	private ToolStripMenuItem _editTrainingMenuItem;
	private ToolStripMenuItem _deleteEmployeeMenuItem;
	private ToolStripMenuItem _deleteTrainingMenuItem;
	private IEmployeeTraining _employeeTraining = null;
	private List<EmployeeVO> _employeeList = null;
	private List<TrainingVO> _trainingList = null;
	private TableLayoutPanel _tablePanel = null;
	private DataGridView _employeeGrid = null;
	private DataGridView _trainingGrid = null;
	private PictureBox _pictureBox = null;
	private EmployeeForm _employeeForm;
	private TrainingForm _trainingForm;

	public EmployeeTrainingClient(IEmployeeTraining employeeTraining){
		_employeeTraining = employeeTraining;
		this.InitializeComponent();
	}

	private void InitializeComponent(){
		// setup the menus
		_ms = new MenuStrip();

		_fileMenu = new ToolStripMenuItem("File");
		_exitMenuItem = new ToolStripMenuItem("Exit", null, this.ExitProgramHandler);

		_editMenu = new ToolStripMenuItem("Edit");
		_createEmployeeMenuItem = 
					new ToolStripMenuItem("Create Employee...", null,  this.CreateEmployeeHandler);
		_createTrainingMenuItem = 
					new ToolStripMenuItem("Create Training...", null, this.CreateTrainingHandler);
		_editEmployeeMenuItem = 
					new ToolStripMenuItem("Edit Employee...", null, this.EditEmployeeHandler);
		_editEmployeeMenuItem.Enabled = false;
		_editTrainingMenuItem = 
					new ToolStripMenuItem("Edit Training...", null, this.EditTrainingHandler);
		_editTrainingMenuItem.Enabled = false; 
		_deleteEmployeeMenuItem = 
					new ToolStripMenuItem("Delete Employee...", null, this.DeleteEmployeeHandler);
		_deleteEmployeeMenuItem.Enabled = false;
		_deleteTrainingMenuItem = 
					new ToolStripMenuItem("Delete Training...", null, this.DeleteTrainingHandler);
		_deleteTrainingMenuItem.Enabled = false;

		_fileMenu.DropDownItems.Add(_exitMenuItem);
		_ms.Items.Add(_fileMenu);

		_editMenu.DropDownItems.Add(_createEmployeeMenuItem);
		_editMenu.DropDownItems.Add(_createTrainingMenuItem);
		_editMenu.DropDownItems.Add("-");
		_editMenu.DropDownItems.Add(_editEmployeeMenuItem);
		_editMenu.DropDownItems.Add(_editTrainingMenuItem);
		_editMenu.DropDownItems.Add("-");
		_editMenu.DropDownItems.Add(_deleteEmployeeMenuItem);
		_editMenu.DropDownItems.Add(_deleteTrainingMenuItem);
		_ms.Items.Add(_editMenu);

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
		_employeeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
		_employeeGrid.Height = 200;
		_employeeGrid.Width = 700;
		_employeeList = _employeeTraining.GetAllEmployees();
		_employeeGrid.DataSource = _employeeList;
		_employeeGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													 AnchorStyles.Left | AnchorStyles.Right;
		_employeeGrid.Click += this.EmployeeGridClickedHandler;
		_employeeGrid.DataBindingComplete += this.EmployeeGridDataBindingCompleteHandler;
		_employeeGrid.CellEndEdit += this.EmployeeGridCellEndEditHandler;

		_trainingGrid = new DataGridView();
		_trainingGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		_trainingGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													 AnchorStyles.Left | AnchorStyles.Right;
		_trainingGrid.DataBindingComplete += this.TrainingGridDataBindingCompleteHandler;
		
		if(_employeeList.Count > 0){
			_trainingList = _employeeTraining.GetTrainingForEmployee(_employeeList[0].EmployeeID);
			_trainingGrid.DataSource = _trainingList;
		}

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
		_ms.Dock = DockStyle.Top;
		this.MainMenuStrip = _ms;
		this.Controls.Add(_ms);
		this.Height = WINDOW_HEIGHT;
		this.Width = WINDOW_WIDTH;
		this.Text = WINDOW_TITLE;
		_employeeForm = new EmployeeForm(this);
		_employeeForm.Visible = false;
		_trainingForm = new TrainingForm(this);
		_trainingForm.Visible = false;
	}

	/************************************************************
	Event Handlers
	*************************************************************/
	private void ExitProgramHandler(Object sender, EventArgs e){
		Application.Exit();
	}

	private void CreateEmployeeHandler(Object sender, EventArgs e){
		_employeeForm.CreateMode = true;
		_employeeForm.SubmitOK = false;
		_employeeForm.ClearFields();
		_employeeForm.ShowDialog();
	}

	private void CreateTrainingHandler(Object sender, EventArgs e){
		_trainingForm.CreateMode = true;
		_trainingForm.ClearFields();
		_trainingForm.ShowDialog();
	}

	private void EditEmployeeHandler(Object sender, EventArgs e){
		_employeeForm.ClearFields();
		_employeeForm.SubmitOK = true;
		_employeeForm.CreateMode = false;
		EmployeeVO vo = _employeeList[_employeeGrid.SelectedRows[0].Index];
		_employeeForm.FirstName = vo.FirstName;
		_employeeForm.MiddleName = vo.MiddleName;
		_employeeForm.LastName = vo.LastName;
		_employeeForm.Birthday = vo.Birthday;
		_employeeForm.Gender = vo.Gender;
		if(vo.Picture != null) {
			MemoryStream ms = new MemoryStream();
			ms.Write(vo.Picture, 0, vo.Picture.Length);
			_employeeForm.Picture = new Bitmap(ms);
		}
		_employeeForm.ShowDialog();
	}

	private void EditTrainingHandler(Object sender, EventArgs e){
		_trainingForm.CreateMode = false;
		TrainingVO vo = _trainingList[_trainingGrid.SelectedRows[0].Index];
		_trainingForm.Title = vo.Title;
		_trainingForm.Description = vo.Description;
		_trainingForm.StartDate = vo.StartDate;
		_trainingForm.EndDate = vo.EndDate;
		_trainingForm.Status = vo.Status;
		_trainingForm.ShowDialog();
	}

	private void EmployeeGridClickedHandler(Object sender, EventArgs e){
		if(_employeeList.Count > 0){
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
			_trainingList = 
					_employeeTraining.GetTrainingForEmployee(_employeeList[selected_row].EmployeeID);
			_trainingGrid.DataSource = _trainingList;
			if(_trainingList.Count > 0){
				_trainingGrid.Rows[0].Selected = true;
				_editTrainingMenuItem.Enabled = true;
				_deleteTrainingMenuItem.Enabled = true; 
			} else {
					_editTrainingMenuItem.Enabled = false;
					_deleteTrainingMenuItem.Enabled = false; 
			}

			if(DEBUG){
				foreach(EmployeeVO emp in _employeeList){
					Console.WriteLine(emp.FirstName + " " + emp.LastName);
				}
			}
		} // end if
	}

	private void EmployeeGridDataBindingCompleteHandler(Object sender, 
																											DataGridViewBindingCompleteEventArgs e){
		_employeeGrid.Columns["Picture"].Visible = false;
		_employeeGrid.Columns["FullName"].Visible = false;
		_employeeGrid.Columns["FullNameAndAge"].Visible = false;
		_employeeGrid.Columns["Age"].ReadOnly = true;
		_employeeGrid.Columns["Age"].ToolTipText = "Read Only!";
		_employeeGrid.Columns["EmployeeID"].Visible = false;
		if(_employeeList.Count > 0){
			_employeeGrid.Rows[0].Selected = true;
			this.EmployeeGridClickedHandler(this, new EventArgs());
			_editEmployeeMenuItem.Enabled = true;
			_deleteEmployeeMenuItem.Enabled = true;
		}
	}

	private void TrainingGridDataBindingCompleteHandler(Object sender, 
																											DataGridViewBindingCompleteEventArgs e){
		_trainingGrid.Columns["TrainingID"].Visible = false;
		_trainingGrid.Columns["EmployeeID"].Visible = false;
		if(_trainingList.Count > 0){
			_trainingGrid.Rows[0].Selected = true;
			_editTrainingMenuItem.Enabled = true;
			_deleteTrainingMenuItem.Enabled = true;
		}
	}

	public void EmployeeSubmitButtonHandler(Object sender, EventArgs e){
		if(_employeeForm.CreateMode){ // creating new employee
			EmployeeVO vo = new EmployeeVO();
			vo = this.FillInEmployeeVO(vo);
			_employeeTraining.CreateEmployee(vo);
		} else { // editing existing employee
				EmployeeVO vo = _employeeList[_employeeGrid.SelectedRows[0].Index];
				vo = this.FillInEmployeeVO(vo);
				_employeeTraining.UpdateEmployee(vo);
		}
		_employeeForm.Visible = false;
		_employeeList = _employeeTraining.GetAllEmployees();
		_employeeGrid.DataSource = _employeeList;
		_employeeForm.ClearFields();
	}

	private EmployeeVO FillInEmployeeVO(EmployeeVO vo){
		vo.FirstName = _employeeForm.FirstName;
		vo.MiddleName = _employeeForm.MiddleName;
		vo.LastName = _employeeForm.LastName;
		vo.Birthday = _employeeForm.Birthday;
		MemoryStream ms = new MemoryStream();
		_employeeForm.Picture.Save(ms, ImageFormat.Tiff);
		vo.Picture = ms.ToArray();
		vo.Gender = _employeeForm.Gender;
		return vo;
	}
	
	public void TrainingSubmitButtonHandler(Object sender, EventArgs e){
		if(_trainingForm.CreateMode){
			TrainingVO vo = new TrainingVO();
			int selected_row = _employeeGrid.SelectedRows[0].Index;
			vo.EmployeeID = _employeeList[selected_row].EmployeeID;
			vo.Title = _trainingForm.Title;
			vo.Description = _trainingForm.Description;
			vo.StartDate = _trainingForm.StartDate;
			vo.EndDate = _trainingForm.EndDate;
			vo.Status = _trainingForm.Status;
			_employeeTraining.CreateTraining(vo);
			_trainingGrid.DataSource = null;
			_trainingGrid.DataSource = _employeeTraining.GetTrainingForEmployee(vo.EmployeeID);
			_trainingForm.Visible = false;
			_trainingForm.ClearFields();
		} else {
				TrainingVO vo = _trainingList[_trainingGrid.Rows[0].Index];
				vo.Title = _trainingForm.Title;
				vo.Description = _trainingForm.Description;
				vo.StartDate = _trainingForm.StartDate;
				vo.EndDate = _trainingForm.EndDate;
				vo.Status = _trainingForm.Status;
				_employeeTraining.UpdateTraining(vo);
				_trainingGrid.DataSource = null;
				_trainingGrid.DataSource = _employeeTraining.GetTrainingForEmployee(vo.EmployeeID);
				_trainingForm.Visible = false;
				_trainingForm.ClearFields();
		}
	}

	private void DeleteEmployeeHandler(Object sender, EventArgs e){
		DialogResult result = MessageBox.Show("Are you sure? Click OK to delete, " + 
																					"or Cancel to return to the application.", 
																					"Warning!", MessageBoxButtons.OKCancel, 
																					MessageBoxIcon.Warning);
		if(result == DialogResult.OK){
			int selected_row = _employeeGrid.SelectedRows[0].Index;
			_employeeTraining.DeleteEmployee(_employeeList[selected_row].EmployeeID);
			_pictureBox.Image = null;
			_employeeGrid.DataSource = null;
			_trainingGrid.DataSource = null;
			_employeeList = _employeeTraining.GetAllEmployees();
			_employeeGrid.DataSource = _employeeList;
			if(_employeeList.Count > 0){
				_employeeGrid.Rows[0].Selected = true;
				this.EmployeeGridClickedHandler(this, new EventArgs());
				_editEmployeeMenuItem.Enabled = true;
				_deleteEmployeeMenuItem.Enabled = true;
			} 
		}
	}

	private void DeleteTrainingHandler(Object sender, EventArgs e){
		DialogResult result = MessageBox.Show("Are you sure? Click OK to delete, " + 
																					"or Cancel to return to the application.", 
																					"Warning!", MessageBoxButtons.OKCancel, 
																					MessageBoxIcon.Warning);
		if(result == DialogResult.OK){
			int selected_row = _trainingGrid.SelectedRows[0].Index;
			_employeeTraining.DeleteTraining(_trainingList[selected_row].TrainingID);
			_trainingGrid.DataSource = null;
			int selected_employee = _employeeGrid.SelectedRows[0].Index;
			_trainingList = 
					_employeeTraining.GetTrainingForEmployee(_employeeList[selected_employee].EmployeeID);
			_trainingGrid.DataSource = _trainingList;
			if(_trainingList.Count > 0){
				_trainingGrid.Rows[0].Selected = true;
				_editTrainingMenuItem.Enabled = true;
				_deleteTrainingMenuItem.Enabled = true;
			}
		}
	}

	private void EmployeeGridCellEndEditHandler(Object sender, EventArgs e){
	   Console.WriteLine("Employee Cell End Edit Handler");
	   EmployeeVO vo = (EmployeeVO)_employeeGrid.SelectedRows[0].DataBoundItem;
		 Console.WriteLine(vo);
		_employeeTraining.UpdateEmployee(vo);
		_employeeList = _employeeTraining.GetAllEmployees();
		_employeeGrid.DataSource = null;
		_employeeGrid.DataSource = _employeeList;
		 
	}
	
	
	[STAThread]
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
} // end class definition