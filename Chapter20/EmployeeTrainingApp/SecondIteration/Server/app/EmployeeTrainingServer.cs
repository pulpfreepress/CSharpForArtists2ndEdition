/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using EmployeeTraining.BO;
using EmployeeTraining.VO;

public class EmployeeTrainingServer : Form  {

	private PictureBox _picturebox;
	private TableLayoutPanel _tablepanel;

	private FlowLayoutPanel _flowpanel;
	private Button _create_employee_botton;
  private Button _find_picture_button;
	private Button _get_all_employees_button;
	private Button _next_employee_button;
	private Button _add_training_button;
	private Button _update_employee_button;
	private Button _update_training_button;
	private Button _next_training_button;
	private Button _delete_employee_button;
	private Button _delete_training_button;

	private TableLayoutPanel _employee_info_entry_panel;
	private Label _fname_label;
	private Label _mname_label;
	private Label _lname_label;
	private Label _bday_label;
	private Label _gender_label;
	private TextBox _fname_textbox;
	private TextBox _mname_textbox;
	private TextBox _lname_textbox;
  private DateTimePicker _bday_picker;
	private GroupBox _gender_groupbox;
	private RadioButton _male_button;
	private RadioButton _female_button;


	private const int TABLE_PANEL_ROW_COUNT = 2;
	private const int TABLE_PANEL_COLUMN_COUNT = 3;
	private const int TABLE_PANEL_HEIGHT = 600;
	private const int TABLE_PANEL_WIDTH = 600;
	private const int EMPLOYEE_INFO_PANEL_HEIGHT = 200;
	private const int EMPLOYEE_INFO_PANEL_WIDTH= 200;
	private const int EMPLOYEE_INFO_PANEL_ROW_COUNT = 5;
	private const int EMPLOYEE_INFO_PANEL_COLUMN_COUNT = 2;
	private const int TRAINING_INFO_PANEL_ROW_COUNT = 5;
	private const int TRAINING_INFO_PANEL_COLUMN_COUNT = 2;
	private const int TRAINING_INFO_PANEL_HEIGHT = 200;
	private const int TRAINING_INFO_PANEL_WIDTH = 200;
	private const int TEXTBOX_WIDTH = 200;
	private const int SMALL_PADDING = 100;
	private const int LARGE_PADDING = 150;
	private const int TRAINING_TEXTBOX_WIDTH = 400;
	private const int TRAINING_TEXTBOX_HEIGHT = 200;
	private const int PICTUREBOX_WIDTH = 150;
	private const int PICTUREBOX_HEIGHT = 150;
	private const int GROUPBOX_WIDTH = 200;
	private const int GROUPBOX_HEIGHT = 125;

	private TableLayoutPanel _training_info_entry_panel;
	private Label _title_label;
	private Label _description_label;
	private Label _startdate_label;
	private Label _enddate_label;
	private Label _status_label;
	private TextBox _title_textbox;
	private TextBox _description_textbox;
	private DateTimePicker _startdate_picker;
	private DateTimePicker _enddate_picker;
	private ListBox _status_listbox;
	
	private TextBox _training_textbox;

	private EmployeeVO _emp_vo;
	private List<EmployeeVO> _employee_list;
	private List<TrainingVO> _training_list;
	private int _next_employee = 0;
	private int _next_training = 0;
	private OpenFileDialog _dialog;

	public EmployeeTrainingServer(){
		this.InitializeComponent();
	}

	private void InitializeComponent(){
		this.SuspendLayout();
		_tablepanel = new TableLayoutPanel();
		_flowpanel = new FlowLayoutPanel();
		_flowpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												AnchorStyles.Left | AnchorStyles.Right;
		_tablepanel.SuspendLayout();
		_tablepanel.RowCount = TABLE_PANEL_ROW_COUNT;
		_tablepanel.ColumnCount = TABLE_PANEL_COLUMN_COUNT;
		_tablepanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												 AnchorStyles.Left | AnchorStyles.Right;
		_tablepanel.Dock = DockStyle.Top;

		_picturebox = new PictureBox();
		_picturebox.Height = PICTUREBOX_WIDTH;
		_picturebox.Width = PICTUREBOX_HEIGHT;
		_picturebox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												 AnchorStyles.Left | AnchorStyles.Right;

		_create_employee_botton = new Button();
		_create_employee_botton.Text = "Create Employee";
		_create_employee_botton.AutoSize = true;
		_create_employee_botton.Click += this.CreateEmployee;
		_create_employee_botton.Enabled = false;

		_find_picture_button = new Button();
		_find_picture_button.Text = "Find Picture";
		_find_picture_button.Click += this.ShowOpenFileDialog;

		_get_all_employees_button = new Button();
		_get_all_employees_button.Text = "Get All Employees";
		_get_all_employees_button.AutoSize = true;
		_get_all_employees_button.Click += this.GetAllEmployees;

		_next_employee_button = new Button();
		_next_employee_button.Text = "Next Employee";
		_next_employee_button.AutoSize = true;
		_next_employee_button.Click += this.NextEmployee;
		_next_employee_button.Enabled = false;

		_add_training_button = new Button();
		_add_training_button.Text = "Add Training";
		_add_training_button.AutoSize = true;
		_add_training_button.Click += this.AddTraining;
		_add_training_button.Enabled = false;

		_update_employee_button = new Button();
		_update_employee_button.Text = "Update Employee";
		_update_employee_button.AutoSize = true;
		_update_employee_button.Click += this.UpdateEmployee;
		_update_employee_button.Enabled = false;

		_update_training_button = new Button();
		_update_training_button.Text = "Update Training";
		_update_training_button.AutoSize = true;
		_update_training_button.Click += this.UpdateTraining;
		_update_training_button.Enabled = false;

		_next_training_button = new Button();
		_next_training_button.Text = "Next Training";
		_next_training_button.AutoSize = true;
		_next_training_button.Click += this.NextTraining;
		_next_training_button.Enabled = false;

		_delete_employee_button = new Button();
		_delete_employee_button.Text = "Delete Employee";
		_delete_employee_button.AutoSize = true;
		_delete_employee_button.Click += this.DeleteEmployee;
		_delete_employee_button.Enabled = false;

		_delete_training_button = new Button();
		_delete_training_button.Text = "Delete Training";
		_delete_training_button.AutoSize = true;
		_delete_training_button.Click += this.DeleteTraining;
		_delete_training_button.Enabled = false;

		_tablepanel.Controls.Add(_picturebox);
		_flowpanel.Controls.Add(_create_employee_botton);
		_flowpanel.Controls.Add(_find_picture_button);
		_flowpanel.Controls.Add(_get_all_employees_button);
		_flowpanel.Controls.Add(_next_employee_button);  
		_flowpanel.Controls.Add(_add_training_button);
		_flowpanel.Controls.Add(_update_employee_button);
		_flowpanel.Controls.Add(_update_training_button);
		_flowpanel.Controls.Add(_next_training_button);
		_flowpanel.Controls.Add(_delete_employee_button);
		_flowpanel.Controls.Add(_delete_training_button);
		
		_tablepanel.Controls.Add(_flowpanel);

		_employee_info_entry_panel = new TableLayoutPanel();
		_employee_info_entry_panel.SuspendLayout();
		_employee_info_entry_panel.Height = EMPLOYEE_INFO_PANEL_HEIGHT;
		_employee_info_entry_panel.Width = EMPLOYEE_INFO_PANEL_WIDTH;
		_employee_info_entry_panel.RowCount = EMPLOYEE_INFO_PANEL_ROW_COUNT;
		_employee_info_entry_panel.ColumnCount = EMPLOYEE_INFO_PANEL_COLUMN_COUNT;
		_fname_label = new Label();
		_fname_label.Text = "First Name";
		_mname_label = new Label();
		_mname_label.Text = "Middle Name";
		_lname_label = new Label();
		_lname_label.Text = "Last Name";
		_bday_label = new Label();
		_bday_label.Text = "Birthday";
		_gender_label = new Label();
		_gender_label.Text = "Gender";
		_fname_textbox = new TextBox();
		_fname_textbox.Width = TEXTBOX_WIDTH;
		_mname_textbox = new TextBox();
		_mname_textbox.Width = TEXTBOX_WIDTH;
		_lname_textbox = new TextBox();
		_lname_textbox.Width = TEXTBOX_WIDTH;
		_bday_picker = new DateTimePicker();
		_gender_groupbox = new GroupBox();
		_gender_groupbox.Text = "Gender";
		_gender_groupbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
															AnchorStyles.Left | AnchorStyles.Right;
		_gender_groupbox.Height = GROUPBOX_HEIGHT;
		_gender_groupbox.Width = GROUPBOX_WIDTH;

		_male_button = new RadioButton();
		_male_button.Text = "Male";
		_male_button.Checked = true;
		_male_button.Location = new Point(10, 20);
		_female_button = new RadioButton();
		_female_button.Text = "Female";
		_female_button.Location = new Point(10, 40);
		_gender_groupbox.Controls.Add(_male_button);
		_gender_groupbox.Controls.Add(_female_button);
		_gender_groupbox.Size = new Size(50, 50);
		_employee_info_entry_panel.Controls.Add(_fname_label);
		_employee_info_entry_panel.Controls.Add(_fname_textbox);
		_employee_info_entry_panel.Controls.Add(_mname_label);
		_employee_info_entry_panel.Controls.Add(_mname_textbox);
		_employee_info_entry_panel.Controls.Add(_lname_label);
		_employee_info_entry_panel.Controls.Add(_lname_textbox);
		_employee_info_entry_panel.Controls.Add(_bday_label);
		_employee_info_entry_panel.Controls.Add(_bday_picker);
		_employee_info_entry_panel.Controls.Add(_gender_label);
		_employee_info_entry_panel.Controls.Add(_gender_groupbox);
		_employee_info_entry_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
																				AnchorStyles.Left | AnchorStyles.Right;

		_tablepanel.Controls.Add(_employee_info_entry_panel);

		_training_info_entry_panel = new TableLayoutPanel();
		_training_info_entry_panel.RowCount = TRAINING_INFO_PANEL_ROW_COUNT;
		_training_info_entry_panel.ColumnCount = TRAINING_INFO_PANEL_COLUMN_COUNT;
		_training_info_entry_panel.Height = TRAINING_INFO_PANEL_HEIGHT;
		_training_info_entry_panel.Width = TRAINING_INFO_PANEL_WIDTH;
		_title_label = new Label();
		_title_label.Text = "Title";
		_description_label = new Label();
		_description_label.Text = "Description";
		_startdate_label = new Label();
		_startdate_label.Text = "Start Date";
		_enddate_label = new Label();
		_enddate_label.Text = "End Date";
		_status_label = new Label();
		_status_label.Text = "Status";
		_title_textbox = new TextBox();
		_title_textbox.Width = TEXTBOX_WIDTH;
		_description_textbox = new TextBox();
		_description_textbox.Width = TEXTBOX_WIDTH;
		_startdate_picker = new DateTimePicker();
		_enddate_picker = new DateTimePicker();
		_status_listbox = new ListBox();
		_status_listbox.Items.Add("Passed");
		_status_listbox.Items.Add("Failed");
		_status_listbox.SetSelected(0, true);

		_training_info_entry_panel.Controls.Add(_title_label);
		_training_info_entry_panel.Controls.Add(_title_textbox);
		_training_info_entry_panel.Controls.Add(_description_label);
		_training_info_entry_panel.Controls.Add(_description_textbox);
		_training_info_entry_panel.Controls.Add(_startdate_label);
		_training_info_entry_panel.Controls.Add(_startdate_picker);
		_training_info_entry_panel.Controls.Add(_enddate_label);
		_training_info_entry_panel.Controls.Add(_enddate_picker);
		_training_info_entry_panel.Controls.Add(_status_label);
		_training_info_entry_panel.Controls.Add(_status_listbox);
		_training_info_entry_panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
																				AnchorStyles.Left | AnchorStyles.Right;

		_tablepanel.Controls.Add(_training_info_entry_panel);

		_training_textbox = new TextBox();
		_training_textbox.Multiline = true;
		_training_textbox.ScrollBars = ScrollBars.Vertical;
		_training_textbox.Dock = DockStyle.Top;
		_training_textbox.Width = TRAINING_TEXTBOX_WIDTH;
		_training_textbox.Height = TRAINING_TEXTBOX_HEIGHT;
		_tablepanel.Controls.Add(_training_textbox);
		_tablepanel.SetRow(_training_textbox, 1);
		_tablepanel.SetColumn(_training_textbox, 0);
		_tablepanel.SetColumnSpan(_training_textbox, 2);

		this.Controls.Add(_tablepanel);
		_tablepanel.Width =  _training_textbox.Width + 
												 _employee_info_entry_panel.Width + LARGE_PADDING;
		_tablepanel.Height = TABLE_PANEL_HEIGHT;
		this.Width = _tablepanel.Width;
		this.Height = _tablepanel.Height;
		this.Text = "Employee Training Test Application";
		_employee_info_entry_panel.ResumeLayout();
		_tablepanel.ResumeLayout();
		this.ResumeLayout();
		_dialog = new OpenFileDialog();
		_dialog.FileOk += this.LoadPicture;
	}

	public void ShowOpenFileDialog(Object sender, EventArgs e){
		this.ResetEntryFields();
		this.ResetTrainingTextbox();
		_add_training_button.Enabled = false;
		_delete_employee_button.Enabled = false;
		_update_employee_button.Enabled = false;
		_next_training_button.Enabled = false;
		_dialog.ShowDialog();
	}

	public void LoadPicture(Object sender, EventArgs e){
		String filename = _dialog.FileName;
		_picturebox.Image = new Bitmap(filename);
		this.AdjustAppWindowSize();
		_create_employee_botton.Enabled = true;
	}
	
	public void CreateEmployee(Object sender, EventArgs e){
		EmployeeVO vo = new EmployeeVO();
		vo = this.PopulateEmployeeVOFromEntryFields(vo);
		EmployeeAdminBO bo = new EmployeeAdminBO();
		_emp_vo = bo.CreateEmployee(vo);
		_picturebox.Image = null;
		_create_employee_botton.Enabled = false;
		this.ResetEntryFields();
		this.DisplayEmployeeInfo();
		this.DisplayEmployeeTraining(bo);
	}

	public void GetAllEmployees(Object sender, EventArgs e){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		_employee_list = bo.GetAllEmployees();
		foreach(EmployeeVO emp in _employee_list){
			Console.WriteLine(emp);
		}
		_next_employee_button.Enabled = true;
	}

	public void NextEmployee(Object sender, EventArgs e){
		_next_employee++;
		_next_training = 0;
		Console.WriteLine(_next_employee);
		if(_next_employee >= _employee_list.Count){
			_next_employee = 0;
		}
		Console.WriteLine(_next_employee);
		if(_employee_list.Count > 0){
			Console.WriteLine(_employee_list[_next_employee]);
			_emp_vo = _employee_list[_next_employee];
			this.DisplayEmployeeInfo();
			this.DisplayEmployeeTraining(new EmployeeAdminBO());
			if(_training_list.Count > 0){
				_update_training_button.Enabled = true;
				_next_training_button.Enabled = true;
			} else {
				_update_training_button.Enabled = false;
				_next_training_button.Enabled = false;
				_delete_training_button.Enabled = false;
			}
			_delete_employee_button.Enabled = true;
			_add_training_button.Enabled = true;
			_update_employee_button.Enabled = true;
		} else {
			_delete_employee_button.Enabled = false;
			_add_training_button.Enabled = false;
			_update_employee_button.Enabled = false;
		}
		this.ResetTrainingEntryFields();
	}

	public void UpdateEmployee(Object sender, EventArgs e){
		_emp_vo = this.PopulateEmployeeVOFromEntryFields(_emp_vo);
		EmployeeAdminBO bo = new EmployeeAdminBO();
		_emp_vo = bo.UpdateEmployee(_emp_vo);
		this.ResetEntryFields();
		this.DisplayEmployeeInfo();
		this.DisplayEmployeeTraining(bo);
	}

	public void AddTraining(Object sender, EventArgs e){
		TrainingVO vo = new TrainingVO();
		vo = this.PopulateTrainingVOFromEntryFields(vo);
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.CreateTraining(vo);
		this.DisplayEmployeeTraining(bo);
		this.ResetTrainingEntryFields();
		_next_training_button.Enabled = true;
	}

	public void NextTraining(Object Sender, EventArgs e){
		_next_training++;
		if(_next_training >= _training_list.Count){
			_next_training = 0;
		}
		if(_training_list.Count > 0){
			this.DisplayTrainingInfo(_training_list[_next_training]);
			_delete_training_button.Enabled = true;
		}
	}

	public void UpdateTraining(Object Sender, EventArgs e){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.UpdateTraining(this.PopulateTrainingVOFromEntryFields(_training_list[_next_training]));
		_training_list = bo.GetTrainingForEmployee(_emp_vo.EmployeeID);
		this.DisplayEmployeeTraining(bo);
	}

	public void DeleteEmployee(Object sender, EventArgs e){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.DeleteEmployee(_emp_vo.EmployeeID);
		_employee_list = bo.GetAllEmployees();
		_next_employee = 0;
		_emp_vo = null;
		this.ResetEntryFields();
		if(_employee_list.Count > 0){
			_emp_vo = _employee_list[_next_employee];
			this.DisplayEmployeeInfo();
			this.DisplayEmployeeTraining(new EmployeeAdminBO());
			if(_training_list.Count > 0){
				_update_training_button.Enabled = true;
				_next_training_button.Enabled = true;
				_delete_training_button.Enabled = true;
			} else {
					_update_training_button.Enabled = false;
					_next_training_button.Enabled = false;
					_delete_training_button.Enabled = false;
			}
			_delete_employee_button.Enabled = true;
		} else {
				_delete_employee_button.Enabled = false;
				_delete_training_button.Enabled = false;
				_next_training_button.Enabled = false;
				_update_training_button.Enabled = false;
				_update_employee_button.Enabled = false;
				_next_employee_button.Enabled = false;
				this.ResetTrainingTextbox();
		}
	}

	public void DeleteTraining(Object sender, EventArgs e){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.DeleteTraining(_training_list[_next_training].TrainingID);
		this.DisplayEmployeeTraining(bo);
		if(_training_list.Count > 0){
			_update_training_button.Enabled = true;
			_next_training_button.Enabled = true;
			_delete_training_button.Enabled = true;
		} else {
				_update_training_button.Enabled = false;
				_next_training_button.Enabled = false;
				_delete_training_button.Enabled = false;
		}
		_next_training = 0;
		this.ResetTrainingEntryFields();
	}

	private void AdjustAppWindowSize(){
		this.SuspendLayout();
		_tablepanel.SuspendLayout();
		_employee_info_entry_panel.SuspendLayout();
		_training_info_entry_panel.SuspendLayout();
		_picturebox.Width = _picturebox.Image.Width;
		_picturebox.Height = _picturebox.Image.Height;
		_employee_info_entry_panel.Height = EMPLOYEE_INFO_PANEL_HEIGHT;
		_employee_info_entry_panel.Width = EMPLOYEE_INFO_PANEL_WIDTH;
		_training_info_entry_panel.Height = TRAINING_INFO_PANEL_HEIGHT;
		_training_info_entry_panel.Width = TRAINING_INFO_PANEL_WIDTH;
		_training_textbox.Width = TRAINING_TEXTBOX_WIDTH;
		_training_textbox.Height = TRAINING_TEXTBOX_HEIGHT;
		_tablepanel.Width = (_picturebox.Width + _flowpanel.Width + 
												 _employee_info_entry_panel.Width + SMALL_PADDING);
		_tablepanel.Height = (_picturebox.Image.Height + _training_textbox.Height + 
													SMALL_PADDING);
		this.Width = _tablepanel.Width + SMALL_PADDING;
		this.Height = _tablepanel.Height;
		_training_info_entry_panel.ResumeLayout();
		_employee_info_entry_panel.ResumeLayout();
		_tablepanel.ResumeLayout();
		this.ResumeLayout();
	}

	private void DisplayEmployeeTraining(EmployeeAdminBO bo){
		_training_list = bo.GetTrainingForEmployee(_emp_vo.EmployeeID);
		_training_textbox.Text = String.Empty;
		StringBuilder sb = new StringBuilder();
		foreach(TrainingVO t in _training_list){
			sb.Append(t.ToString() + "\r\n");
		}
		_training_textbox.Text = sb.ToString();
	}

	private TrainingVO.TrainingStatus StringToTrainingStatus(String s){
		TrainingVO.TrainingStatus status = TrainingVO.TrainingStatus.Passed;
		switch(s){
			case "Passed" : status = TrainingVO.TrainingStatus.Passed;
											break;
			case "Failed" : status = TrainingVO.TrainingStatus.Failed;
											break;              
		}
		return status;
	}

	private void ResetEntryFields(){
		_fname_textbox.Text = String.Empty;
		_mname_textbox.Text = String.Empty;
		_lname_textbox.Text = String.Empty;
		_male_button.Checked = true;
		_bday_picker.Value = DateTime.Now;
		_picturebox.Image = null;
		this.ResetTrainingEntryFields();
	}

	private void ResetTrainingEntryFields(){
		_title_textbox.Text = String.Empty;
		_description_textbox.Text = String.Empty;
		_startdate_picker.Value = DateTime.Now;
		_enddate_picker.Value = DateTime.Now;
		_status_listbox.SetSelected(0, true);
	}

  public void ResetTrainingTextbox(){
    _training_textbox.Text = String.Empty;
  }
  
	private void DisplayEmployeeInfo(){
		_fname_textbox.Text = _emp_vo.FirstName;
		_mname_textbox.Text = _emp_vo.MiddleName;
		_lname_textbox.Text = _emp_vo.LastName;
		switch(_emp_vo.Gender){
			case PersonVO.Sex.MALE : _male_button.Checked = true;
																break;
			case PersonVO.Sex.FEMALE : _female_button.Checked = true;
																break;
		}
		_bday_picker.Value = _emp_vo.Birthday;
		_picturebox.Image = _emp_vo.Picture; 
		if(_picturebox.Image != null){
			this.AdjustAppWindowSize();
		}  
	}

	private PersonVO.Sex RadioButtonToSexEnum(){
		PersonVO.Sex gender = PersonVO.Sex.MALE;
		if(_male_button.Checked){
			gender = PersonVO.Sex.MALE;
		} else {
			if(_female_button.Checked){
				gender = PersonVO.Sex.FEMALE;
			}
		}
		return gender;
	}

	private EmployeeVO PopulateEmployeeVOFromEntryFields(EmployeeVO vo){
		vo.FirstName = _fname_textbox.Text;
		vo.MiddleName = _mname_textbox.Text;
		vo.LastName = _lname_textbox.Text;
		vo.Gender = this.RadioButtonToSexEnum();
		vo.Birthday = _bday_picker.Value;
		vo.Picture = _picturebox.Image;
		return vo;
	}

	private TrainingVO PopulateTrainingVOFromEntryFields(TrainingVO vo){
		vo.EmployeeID = _emp_vo.EmployeeID;
		vo.Title = _title_textbox.Text;
		vo.Description = _description_textbox.Text;
		vo.StartDate = _startdate_picker.Value;
		vo.EndDate = _enddate_picker.Value;
		vo.Status = this.StringToTrainingStatus(_status_listbox.SelectedItem.ToString());
		return vo;
	}

	private void DisplayTrainingInfo(TrainingVO vo){
		_title_textbox.Text = vo.Title;
		_description_textbox.Text = vo.Description;
		_startdate_picker.Value = vo.StartDate;
		_enddate_picker.Value = vo.EndDate;
		switch(vo.Status){
			case TrainingVO.TrainingStatus.Passed :
									_status_listbox.SetSelected(0, true);
									break;
			case TrainingVO.TrainingStatus.Failed :
									_status_listbox.SetSelected(1, true);
									break;
		}
	}

	[STAThread]
	public static void Main(){
		Application.Run(new EmployeeTrainingServer());
	}
}