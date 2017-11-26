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
using System.Collections.Generic;
using EmployeeTraining.DAO;
using EmployeeTraining.VO;

public class EmployeeTrainingServer : Form  {

	private PictureBox _picturebox;
	private TableLayoutPanel _tablepanel;
	private FlowLayoutPanel _flowpanel;
	private Button _button1;
	private Button _button2; 
	private Button _button3;
	private Button _button4;
	private Button _button5;
	private EmployeeVO _emp_vo;
	private List<EmployeeVO> _list;
	private int _next_employee = 0;
	private OpenFileDialog _dialog;

	public EmployeeTrainingServer(){
		this.InitializeComponent();
	}

	private void InitializeComponent(){
		this.SuspendLayout();
		_tablepanel = new TableLayoutPanel();
		_flowpanel = new FlowLayoutPanel();
		_tablepanel.SuspendLayout();
		_tablepanel.RowCount = 1;
		_tablepanel.ColumnCount = 2;
		_tablepanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												 AnchorStyles.Left | AnchorStyles.Right;
		_tablepanel.Dock = DockStyle.Left;
		_tablepanel.Width = 600;
    
		_picturebox = new PictureBox();
		_picturebox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												 AnchorStyles.Left | AnchorStyles.Right;
 
		_button1 = new Button();
		_button1.Text = "Create";
		_button1.Click += this.CreateEmployee;
		_button1.Enabled = false;

		_button2 = new Button();
		_button2.Text = "Load";
		_button2.Click += this.LoadEmployee;
		_button2.Enabled = false;

		_button3 = new Button();
		_button3.Text = "Find Picture";
		_button3.Click += this.ShowOpenFileDialog;

		_button4 = new Button();
		_button4.Text = "Get All Employees";
		_button4.AutoSize = true;
		_button4.Click += this.GetAllEmployees;

		_button5 = new Button();
		_button5.Text = "Next";
		_button5.Click += this.NextEmployee;
		_button5.Enabled = false;

		_tablepanel.Controls.Add(_picturebox);
		_flowpanel.Controls.Add(_button1);
		_flowpanel.Controls.Add(_button2);
		_flowpanel.Controls.Add(_button3);
		_flowpanel.Controls.Add(_button4);
		_flowpanel.Controls.Add(_button5);  
		_tablepanel.Controls.Add(_flowpanel);

		this.Controls.Add(_tablepanel);
		this.Width = _tablepanel.Width;
		this.Height = 300;
		_tablepanel.ResumeLayout();
		this.ResumeLayout();
		_dialog = new OpenFileDialog();
		_dialog.FileOk += this.LoadPicture;
	}

	public void ShowOpenFileDialog(object sender, EventArgs e){
		_dialog.ShowDialog();
	}

	public void LoadPicture(object sender, EventArgs e){
		string filename = _dialog.FileName;
		_picturebox.Image = new Bitmap(filename);
		this.AdjustPicturebox();
		_button1.Enabled = true;
	}

	public void CreateEmployee(object sender, EventArgs e){
		EmployeeVO vo = new EmployeeVO();
		vo.FirstName = "Rick";
		vo.MiddleName = "Warren";
		vo.LastName = "Miller";
		vo.Gender = EmployeeVO.Sex.MALE;
		vo.Birthday = new DateTime(1972, 2, 18);
		vo.Picture = _picturebox.Image;

		EmployeeDAO dao = new EmployeeDAO();
		_emp_vo = dao.InsertEmployee(vo);
		_picturebox.Image = null;
		_button2.Enabled = true;
		_button1.Enabled = false;
	}

	public void LoadEmployee(object sender, EventArgs e){
		EmployeeDAO dao = new EmployeeDAO();
		_emp_vo.Picture = null;
		_emp_vo = dao.GetEmployee(_emp_vo.EmployeeID);
		_picturebox.Image = _emp_vo.Picture;
	}

	public void GetAllEmployees(object sender, EventArgs e){
		EmployeeDAO dao = new EmployeeDAO();
		_list = dao.GetAllEmployees();
		foreach(EmployeeVO emp in _list){
			Console.WriteLine(emp);
		}
		if(_list.Count > 0) _button5.Enabled = true;
	}

	public void NextEmployee(object sender, EventArgs e){
		Console.WriteLine(_next_employee);
		if(_next_employee >= _list.Count){
			_next_employee = 0;
		}
		Console.WriteLine(_next_employee);
		Console.WriteLine(_list[_next_employee]);
		_picturebox.Image = _list[_next_employee++].Picture; 
		if(_picturebox.Image != null){
			this.AdjustPicturebox();	
		}  
	}

	private void AdjustPicturebox(){
		this.SuspendLayout();
		_tablepanel.SuspendLayout();
		_picturebox.Width = _picturebox.Image.Width;
		_picturebox.Height = _picturebox.Image.Height;
		_tablepanel.Width = _picturebox.Image.Width + 300;
		this.Width = _tablepanel.Width;
		_tablepanel.ResumeLayout();
		this.ResumeLayout();
	}

	[STAThread]
	public static void Main(){
		Application.Run(new EmployeeTrainingServer());
	} // end Main()
} // end class