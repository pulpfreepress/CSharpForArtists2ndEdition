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
using System.Drawing;
using System.Windows.Forms;
using Com.PulpFreePress.Common;

namespace Com.PulpFreePress.View {
	public class View : Form, IView {
		// constants
		private const int WINDOW_HEIGHT = 600;
		private const int WINDOW_WIDTH = 860;
		private const string WINDOW_TITLE = "Employee Management Application ";
		private IEmployee _editingEmployee;
		private int _editingEmployeeIndex;

		//menu fields
		private MenuStrip _ms;
		private ToolStripMenuItem _fileMenu;
		private ToolStripMenuItem _loadMenuItem;
		private ToolStripMenuItem _saveMenuItem;
		private ToolStripMenuItem _exitMenuItem;
		private ToolStripMenuItem _editMenu;
		private ToolStripMenuItem _listMenuItem;
		private ToolStripMenuItem _sortMenuItem;
		private ToolStripMenuItem _newSalariedEmployeeMenuItem;
		private ToolStripMenuItem _newHourlyEmployeeMenuItem;
		private ToolStripMenuItem _editEmployeeMenuItem;
		private ToolStripMenuItem _deleteEmployeeMenuItem;

		// fields
		private ViewMode _mode;
		private TableLayoutPanel _mainTablePanel;
		private TableLayoutPanel _infoTablePanel;
		private FlowLayoutPanel _buttonPanel;
		private TextBox _mainTextBox;
		private Label _firstNameLabel;
		private Label _middleNameLabel;
		private Label _lastNameLabel;
		private Label _birthdayLabel;
		private Label _genderLabel;
		private Label _haircolorLabel;
		private Label _hoursWorkedLabel;
		private Label _hourlyRateLabel;
		private Label _salaryLabel;
		private Label _employeeNumberLabel;
		private TextBox _firstNameTextBox;
		private TextBox _middleNameTextBox;
		private TextBox _lastNameTextBox;
		private TextBox _hoursWorkedTextBox;
		private TextBox _hourlyRateTextBox;
		private TextBox _salaryTextBox;
		private TextBox _employeeNumberTextBox;
		private DateTimePicker _birthdayPicker;
		private GroupBox _genderBox;
		private RadioButton _maleRadioButton;
		private RadioButton _femaleRadioButton;
		private GroupBox _haircolorBox;
		private RadioButton _unknownRadioButton;
		private RadioButton _blondeRadioButton;
		private RadioButton _brownRadioButton;
		private RadioButton _blackRadioButton;
		private Button _clearButton;
		private Button _submitButton;
		private OpenFileDialog _openFileDialog;
		private SaveFileDialog _saveFileDialog;
		private bool _createMode;
    
		// public properties -
		public ViewMode Mode {
			get { return _mode; }
			set { 
				_mode = value;
				this.SetWindowTitleBasedOnMode();
			}
		}

		public IEmployee EditingEmployee {
			get { return _editingEmployee; }
			set { 
				_editingEmployee = value;
				if(_editingEmployee.GetType() == typeof(HourlyEmployee)){
					this.PopulateEditFields((HourlyEmployee)_editingEmployee);
				} else {
						this.PopulateEditFields((SalariedEmployee)_editingEmployee);
					}
			}
		}

		public int EditingEmployeeIndex {
			get { return _editingEmployeeIndex; }
			set { _editingEmployeeIndex = value; }
		}

		public String FirstName {
			get { return _firstNameTextBox.Text; }
			set { _firstNameTextBox.Text = value; }
		}

		public String MiddleName {
			get { return _middleNameTextBox.Text; }
			set { _middleNameTextBox.Text = value; }
		}

		public String LastName {
			get { return _lastNameTextBox.Text; }
			set { _lastNameTextBox.Text = value; }
		}

		public DateTime Birthday {
			get { return _birthdayPicker.Value; }
			set { _birthdayPicker.Value = value; }
		}

		public String MainTextBoxText {
			set { _mainTextBox.Text = value; }
		}

		public Sex Gender {
			get { return this.RadioButtonToSexEnum(); }
			set { this.SetGenderRadioButton(value); }
		}
		
		public Haircolor HairColor { 
			get { return this.RadioButtonToHaircolorEnum(); }
			set { this.SetHaircolorRadioButton(value); }
		}

		public bool CreateMode {
			get { return _createMode; }
			set { _createMode = value; }
		}

		public String Salary {
			get { return _salaryTextBox.Text; }
			set { _salaryTextBox.Text = value; }
		}

		public String HoursWorked {
			get { return _hoursWorkedTextBox.Text; }
			set { _hoursWorkedTextBox.Text = value; }
		}

		public String HourlyRate {
			get { return _hourlyRateTextBox.Text; }
			set { _hourlyRateTextBox.Text = value; }
		}

		public String EmployeeNumber {
			get { return _employeeNumberTextBox.Text; }
			set { _employeeNumberTextBox.Text = value; }
		}

		public bool SubmitOK {
			set { _submitButton.Enabled = value; }
		}

		#region Constructor
		public View(IController externalHandler){
			this.InitializeComponent(externalHandler);
		}
		#endregion Constructor
    
		#region Public Methods
		public void ClearInputFields(){
			_firstNameTextBox.Text = String.Empty;
			_middleNameTextBox.Text = String.Empty;
			_lastNameTextBox.Text = String.Empty;
			_maleRadioButton.Checked = true;
			_unknownRadioButton.Checked = true;
			_birthdayPicker.Value = DateTime.Now;
			_hoursWorkedTextBox.Text = String.Empty;
			_hourlyRateTextBox.Text = String.Empty;
			_salaryTextBox.Text = String.Empty;
			_employeeNumberTextBox.Text = String.Empty;
		}

		public void EnableSalaryFields(bool state){
			_salaryLabel.Enabled = state;
			_salaryTextBox.Enabled = state;
		}

		public void EnableHourlyFields(bool state){
			_hoursWorkedLabel.Enabled = state;
			_hoursWorkedTextBox.Enabled = state;
			_hourlyRateLabel.Enabled = state;
			_hourlyRateTextBox.Enabled = state;
		}

		public void EnableSubmitButton(bool state){
			_submitButton.Enabled = state;
		}
		
		public void EnableCommonFields(bool state){
		  _firstNameLabel.Enabled = state;
			_firstNameTextBox.Enabled = state;
			_middleNameLabel.Enabled = state;
			_middleNameTextBox.Enabled = state;
			_lastNameLabel.Enabled = state;
			_lastNameTextBox.Enabled = state;
			_birthdayLabel.Enabled = state;
			_birthdayPicker.Enabled = state;
			_employeeNumberLabel.Enabled = state;
			_employeeNumberTextBox.Enabled = state;
			_genderLabel.Enabled = state;
			_genderBox.Enabled = state;
			_haircolorLabel.Enabled = state;
			_haircolorBox.Enabled = state;
		}

		public void DisplayEmployeeInfo(String[] employees_info) {
			StringBuilder sb = new StringBuilder();
			foreach(String s in employees_info){
				sb.Append(s + "\r\n");
			}
			_mainTextBox.Text = sb.ToString();
		}

		public IEmployee GetNewSalariedEmployee(){
			SalariedEmployee employee = new SalariedEmployee();
			PayInfo p = new PayInfo();
			try {
			p.Salary = Double.Parse(Salary);
			} catch(Exception){
			  Salary = "0.0";
			}
			employee.PayInfo = p;
			this.FillInStandardEmployee(employee);
			return employee;
		}

		public IEmployee GetNewHourlyEmployee(){
			HourlyEmployee employee = new HourlyEmployee();
			PayInfo p = new PayInfo();
			try{
				p.HoursWorked = Double.Parse(HoursWorked);
				p.HourlyRate = Double.Parse(HourlyRate);
			}catch(FormatException){
				p.HoursWorked = 0.0;
				p.HourlyRate = 0.0;
			}
			employee.PayInfo = p;
			this.FillInStandardEmployee(employee);
			return employee;
		}

		public IEmployee GetEditedEmployee(){
			if(EditingEmployee.GetType() == typeof(HourlyEmployee)){
				return this.FillInEditedEmployee((HourlyEmployee)EditingEmployee);
			} else {
					return this.FillInEditedEmployee((SalariedEmployee)EditingEmployee);
				}
		}

		public String GetSaveFile(){
			_saveFileDialog.ShowDialog();
			return _saveFileDialog.FileName;
		}

		public String GetLoadFile(){
			_openFileDialog.ShowDialog();
			return _openFileDialog.FileName;
		}

		public int GetSelectedLineNumber(){
			int index = _mainTextBox.SelectionStart;
			int line_number = _mainTextBox.GetLineFromCharIndex(index);
			return line_number;
		}
		#endregion Public Methods
		
		#region Private Methods
		private void InitializeComponent(IController controller){
			this.InitializeMenus(controller);
			_mainTablePanel = new TableLayoutPanel();
			_mainTablePanel.RowCount = 2;
			_mainTablePanel.ColumnCount = 2;
			_mainTablePanel.Anchor = AnchorStyles.Top |   AnchorStyles.Bottom | 
															AnchorStyles.Right | AnchorStyles.Left;
			_mainTablePanel.Padding = new Padding(10, 50, 10, 10);
			_mainTablePanel.Height = 600;
			_mainTablePanel.Width = 550;
			_infoTablePanel = new TableLayoutPanel();
			_infoTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
															AnchorStyles.Right | AnchorStyles.Left;
			_infoTablePanel.RowCount = 10; // was 2
			_infoTablePanel.ColumnCount = 2;
			_infoTablePanel.Height = 450;
			_infoTablePanel.Width = 550;
			_buttonPanel = new FlowLayoutPanel();
			_buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													AnchorStyles.Right | AnchorStyles.Left;
			_buttonPanel.Height = 100;
			_buttonPanel.Width = 550;
     
			_mainTextBox = new TextBox();
			_mainTextBox.Height = 200;
			_mainTextBox.Width = 400;
			_mainTextBox.Multiline = true;
			_mainTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													AnchorStyles.Right | AnchorStyles.Left;
     
			_firstNameLabel = new Label();
			_firstNameLabel.Text = "First Name:";
			_middleNameLabel = new Label();
			_middleNameLabel.Text = "Middle Name:";
			_lastNameLabel = new Label();
			_lastNameLabel.Text = "Last Name:";
			_hoursWorkedLabel = new Label();
			_hoursWorkedLabel.Text = "Hours Worked:";
			_hourlyRateLabel = new Label();
			_hourlyRateLabel.Text = "Hourly Rate:";
			_salaryLabel = new Label();
			_salaryLabel.Text = "Salary:";
			_employeeNumberLabel = new Label();
			_employeeNumberLabel.Text = "Employee Number:";
			_employeeNumberLabel.Width = 200;
     
			_birthdayLabel = new Label();
			_birthdayLabel.Text = "Birthday";
			_genderLabel = new Label();
			_genderLabel.Text = "Gender";
			_firstNameTextBox = new TextBox();
			_firstNameTextBox.Width = 200;
			_middleNameTextBox = new TextBox();
			_middleNameTextBox.Width = 200;
			_lastNameTextBox = new TextBox();
			_lastNameTextBox.Width = 200;
			_hoursWorkedTextBox = new TextBox();
			_hoursWorkedTextBox.Width = 200;
			_hourlyRateTextBox = new TextBox();
			_hourlyRateTextBox.Width = 200;
			_salaryTextBox = new TextBox();
			_salaryTextBox.Width = 200;
			_employeeNumberTextBox = new TextBox();
			_employeeNumberTextBox.Width = 200;

			_birthdayPicker = new DateTimePicker();
			_genderBox = new GroupBox();
			_genderBox.Text = "Gender";
			_genderBox.Height = 75;
			_genderBox.Width = 200;
			_maleRadioButton = new RadioButton();
			_maleRadioButton.Text = "Male";
			_maleRadioButton.Checked = true;
			_maleRadioButton.Location = new Point(10, 20);
			_femaleRadioButton = new RadioButton();
			_femaleRadioButton.Text = "Female";
			_femaleRadioButton.Location = new Point(10, 40);
			_genderBox.Controls.Add(_maleRadioButton);
			_genderBox.Controls.Add(_femaleRadioButton);
			
			_haircolorLabel = new Label();
			_haircolorLabel.Text = "Hair Color:";
			_haircolorBox = new GroupBox();
			_haircolorBox.Text = "Hair Color";
			_haircolorBox.Height = 125;
			_haircolorBox.Width = 200;
			_unknownRadioButton = new RadioButton();
			_unknownRadioButton.Text = "Unknown";
			_unknownRadioButton.Checked = true;
			_unknownRadioButton.Location = new Point(10, 20);

			_blondeRadioButton = new RadioButton();
			_blondeRadioButton.Text = "Blonde";
			_blondeRadioButton.Checked = false;
			_blondeRadioButton.Location = new Point(10, 40);
		 
			_brownRadioButton = new RadioButton();
			_brownRadioButton.Text = "Brown";
			_brownRadioButton.Checked = false;
			_brownRadioButton.Location = new Point(10, 60);

			_blackRadioButton = new RadioButton();
			_blackRadioButton.Text = "Black";
			_blackRadioButton.Checked = false;
			_blackRadioButton.Location = new Point(10, 80);
		 
			_haircolorBox.Controls.Add(_unknownRadioButton);
			_haircolorBox.Controls.Add(_blondeRadioButton);
			_haircolorBox.Controls.Add(_brownRadioButton);
			_haircolorBox.Controls.Add(_blackRadioButton);
			
			_clearButton = new Button();
			_clearButton.Text = "Clear";
			_clearButton.Name = "Clear";
			_clearButton.Click += controller.CommandHandler;

			_submitButton = new Button();
			_submitButton.Text = "Submit";
			_submitButton.Name = "Submit";
			_submitButton.Click += controller.CommandHandler;
			_submitButton.Enabled = false;

			_infoTablePanel.SuspendLayout();
			_infoTablePanel.Controls.Add(_firstNameLabel);
			_infoTablePanel.Controls.Add(_firstNameTextBox);
			_infoTablePanel.Controls.Add(_middleNameLabel);
			_infoTablePanel.Controls.Add(_middleNameTextBox);
			_infoTablePanel.Controls.Add(_lastNameLabel);
			_infoTablePanel.Controls.Add(_lastNameTextBox);
			_infoTablePanel.Controls.Add(_birthdayLabel);
			_infoTablePanel.Controls.Add(_birthdayPicker);
			_infoTablePanel.Controls.Add(_genderLabel);
			_infoTablePanel.Controls.Add(_genderBox);
			_infoTablePanel.Controls.Add(_haircolorLabel);
			_infoTablePanel.Controls.Add(_haircolorBox);
			_infoTablePanel.Controls.Add(_employeeNumberLabel);
			_infoTablePanel.Controls.Add(_employeeNumberTextBox);
			_infoTablePanel.Controls.Add(_hoursWorkedLabel);
			_infoTablePanel.Controls.Add(_hoursWorkedTextBox);
			_infoTablePanel.Controls.Add(_hourlyRateLabel);
			_infoTablePanel.Controls.Add(_hourlyRateTextBox);
			_infoTablePanel.Controls.Add(_salaryLabel);
			_infoTablePanel.Controls.Add(_salaryTextBox);
			_infoTablePanel.Dock = DockStyle.Top;

			_buttonPanel.SuspendLayout();
			_buttonPanel.Controls.Add(_clearButton);
			_buttonPanel.Controls.Add(_submitButton);

			_mainTablePanel.SuspendLayout();
			_mainTablePanel.Controls.Add(_mainTextBox);
			_mainTablePanel.Controls.Add(_infoTablePanel);
			_mainTablePanel.Controls.Add(_buttonPanel);
			_mainTablePanel.SetColumnSpan(_buttonPanel, 2);

			this.SuspendLayout();
			this.Controls.Add(_mainTablePanel); 
			this.Width = WINDOW_WIDTH;
			this.Height = WINDOW_HEIGHT;
			this.MinimumSize = new Size(WINDOW_WIDTH, WINDOW_HEIGHT);
			this.Text = WINDOW_TITLE;
			_infoTablePanel.ResumeLayout();
			_buttonPanel.ResumeLayout();
			_mainTablePanel.ResumeLayout();
			this.ResumeLayout();
			_openFileDialog = new OpenFileDialog();
			_saveFileDialog = new SaveFileDialog();
			this.EnableCommonFields(false);
			this.EnableHourlyFields(false);
			this.EnableSalaryFields(false);
			this.Mode = ViewMode.RESTING;
		}

		private void InitializeMenus(IController controller){
			// setup the menus
			_ms = new MenuStrip();

			_fileMenu = new ToolStripMenuItem("File");
			_loadMenuItem = new ToolStripMenuItem("Load...", null, 
																	new EventHandler(controller.CommandHandler));
			_loadMenuItem.Name = "Load";
			_saveMenuItem = new ToolStripMenuItem("Save...", null, 
																	new EventHandler(controller.CommandHandler));
			_saveMenuItem.Name = "Save";
			_exitMenuItem = new ToolStripMenuItem("Exit", null, 
																	new EventHandler(controller.CommandHandler));
			_exitMenuItem.Name = "Exit";

			_editMenu = new ToolStripMenuItem("Edit");
			_listMenuItem = new ToolStripMenuItem("List", null, 
																	new EventHandler(controller.CommandHandler));
			_listMenuItem.Name = "List";
			_sortMenuItem = new ToolStripMenuItem("Sort", null, 
																	new EventHandler(controller.CommandHandler));
			_sortMenuItem.Name = "Sort";
			_newSalariedEmployeeMenuItem = new ToolStripMenuItem("New Salaried Employee", null,  
                                   new EventHandler(controller.CommandHandler));
			_newSalariedEmployeeMenuItem.Name = "NewSalariedEmployee";
			_newHourlyEmployeeMenuItem = new ToolStripMenuItem("New Hourly Employee", null, 
                                   new EventHandler(controller.CommandHandler));
			_newHourlyEmployeeMenuItem.Name = "NewHourlyEmployee";
			_editEmployeeMenuItem = new ToolStripMenuItem("Edit Employee", null, 
                                   new EventHandler(controller.CommandHandler));
			_editEmployeeMenuItem.Name = "EditEmployee";
			_deleteEmployeeMenuItem = new ToolStripMenuItem("Delete Employee", null, 
                                    new EventHandler(controller.CommandHandler));
			_deleteEmployeeMenuItem.Name = "DeleteEmployee";
     
			_fileMenu.DropDownItems.Add(_loadMenuItem);
			_fileMenu.DropDownItems.Add(_saveMenuItem);
			_fileMenu.DropDownItems.Add(_exitMenuItem);
			_ms.Items.Add(_fileMenu);

			_editMenu.DropDownItems.Add(_listMenuItem);
			_editMenu.DropDownItems.Add(_sortMenuItem);
			_editMenu.DropDownItems.Add("-");
			_editMenu.DropDownItems.Add(_newSalariedEmployeeMenuItem);
			_editMenu.DropDownItems.Add(_newHourlyEmployeeMenuItem);
			_editMenu.DropDownItems.Add(_editEmployeeMenuItem);
			_editMenu.DropDownItems.Add("-");
			_editMenu.DropDownItems.Add(_deleteEmployeeMenuItem);
			_ms.Items.Add(_editMenu);
			_ms.Dock = DockStyle.Top;
			this.MainMenuStrip = _ms;
			this.Controls.Add(_ms);
		}
		
		private void SetWindowTitleBasedOnMode(){
			switch(Mode){
				case ViewMode.RESTING: this.Text = WINDOW_TITLE + "- Resting";
															break;
				case ViewMode.SALARIED: this.Text = WINDOW_TITLE + "- New Salaried Employee";
															break;
				case ViewMode.HOURLY: this.Text = WINDOW_TITLE + " - New Hourly Employee";
															break;
				case ViewMode.EDIT: this.Text = WINDOW_TITLE + "- Edit Employee";
															break;
			}
		}
		
		private Sex RadioButtonToSexEnum(){
			Sex gender = Sex.MALE;
			if(_maleRadioButton.Checked){
				gender = Sex.MALE;
			} else {
					gender = Sex.FEMALE;
				}
			return gender;
		}

		private void SetGenderRadioButton(Sex gender){
			if(gender == Sex.MALE){
				_maleRadioButton.Checked = true;
			} else {
					_femaleRadioButton.Checked = true;
				}
		}
		
		private Haircolor RadioButtonToHaircolorEnum(){
			Haircolor haircolor = Haircolor.UNKNOWN;
			if(_unknownRadioButton.Checked){
			  haircolor = Haircolor.UNKNOWN;
			}
			if(_blondeRadioButton.Checked){
			  haircolor = Haircolor.BLONDE;
			}
			if(_brownRadioButton.Checked){
			  haircolor = Haircolor.BROWN;
			}
			if(_blackRadioButton.Checked){
			  haircolor = Haircolor.BLACK;
			}
			return haircolor;
		}
		
		private void SetHaircolorRadioButton(Haircolor haircolor){
			if(haircolor == Haircolor.UNKNOWN){
				_unknownRadioButton.Checked = true;
			}
			if(haircolor == Haircolor.BLONDE){
				_blondeRadioButton.Checked = true;
			}
			if(haircolor == Haircolor.BROWN){
				_brownRadioButton.Checked = true;
			}
			if(haircolor == Haircolor.BLACK){
				_blackRadioButton.Checked = true;
			}
		}
		
		private IEmployee FillInEditedEmployee(SalariedEmployee employee){
			employee.PayInfo.Salary = Double.Parse(Salary);
			return this.FillInStandardEmployee(employee);
		}

		private IEmployee FillInEditedEmployee(HourlyEmployee employee){
			employee.PayInfo.HoursWorked = Double.Parse(HoursWorked);
			employee.PayInfo.HourlyRate = Double.Parse(HourlyRate);
			return this.FillInStandardEmployee(employee);
		}

		private IEmployee FillInStandardEmployee(IEmployee employee){
			employee.FirstName = FirstName;
			employee.MiddleName = MiddleName;
			employee.LastName = LastName;
			employee.Gender = Gender;
			employee.HairColor = HairColor;
			employee.Birthday = Birthday;
			employee.EmployeeNumber = EmployeeNumber; 
			return employee;
		}

		public void PopulateEditFields(SalariedEmployee employee){
			EnableCommonFields(true);
			EnableSalaryFields(true);
			EnableHourlyFields(false);
			Salary = employee.PayInfo.Salary.ToString();
			this.PopulateStandardEditFields(employee);
		}

		public void PopulateEditFields(HourlyEmployee employee){
			EnableCommonFields(true);
			EnableHourlyFields(true);
			EnableSalaryFields(false);
			HoursWorked = employee.PayInfo.HoursWorked.ToString();
			HourlyRate = employee.PayInfo.HourlyRate.ToString();
			this.PopulateStandardEditFields(employee);
		}

		private void PopulateStandardEditFields(IEmployee employee){
			FirstName = employee.FirstName;
			MiddleName = employee.MiddleName;
			LastName = employee.LastName;
			Birthday = employee.Birthday;
			Gender = employee.Gender;
			HairColor = employee.HairColor;
			EmployeeNumber = employee.EmployeeNumber;
		}
		#endregion Private Methods
	} // end View class definition
} // end namespace