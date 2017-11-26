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
using System.Windows.Forms;
using EmployeeTraining.VO;

public class EmployeeForm : Form {

	// constants
	private const int WINDOW_HEIGHT = 300;
	private const int WINDOW_WIDTH = 550;

	// fields
	private TableLayoutPanel _mainTablePanel;
	private TableLayoutPanel _infoTablePanel;
	private FlowLayoutPanel _buttonPanel;
	private PictureBox _pictureBox;
	private Label _firstNameLabel;
	private Label _middleNameLabel;
	private Label _lastNameLabel;
	private Label _birthdayLabel;
	private Label _genderLabel;
	private TextBox _firstNameTextBox;
	private TextBox _middleNameTextBox;
	private TextBox _lastNameTextBox;
	private DateTimePicker _birthdayPicker;
	private GroupBox _genderBox;
	private RadioButton _maleRadioButton;
	private RadioButton _femaleRadioButton;
	private Button _clearButton;
	private Button _loadPictureButton;
	private Button _submitButton;
	private OpenFileDialog _dialog;
	private bool _createMode;
  
	// public properties -
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

	public Image Picture {
		get { return _pictureBox.Image; }
		set { _pictureBox.Image = value; }
	}

	public PersonVO.Sex Gender {
		get { return this.RadioButtonToSexEnum(); }
		set { this.SetRadioButton(value); }
  }
  
  public bool CreateMode {
    get { return _createMode; }
    set { _createMode = value; }
	}

	public bool SubmitOK {
		set { _submitButton.Enabled = value; }
	}

	public EmployeeForm(EmployeeTrainingClient externalHandler){
		this.InitializeComponent(externalHandler);
	}

	private void InitializeComponent(EmployeeTrainingClient externalHandler){
		_mainTablePanel = new TableLayoutPanel();
		_mainTablePanel.RowCount = 2;
		_mainTablePanel.ColumnCount = 2;
		_mainTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
														 AnchorStyles.Right | AnchorStyles.Left;
		_mainTablePanel.Height = 500;
		_mainTablePanel.Width = 700;
		_infoTablePanel = new TableLayoutPanel();
		_infoTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
														 AnchorStyles.Right | AnchorStyles.Left;
		_infoTablePanel.RowCount = 2;
		_infoTablePanel.ColumnCount = 2;
		_infoTablePanel.Height = 200;
		_infoTablePanel.Width = 400;
		_buttonPanel = new FlowLayoutPanel();
		_buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													AnchorStyles.Right | AnchorStyles.Left;
		_buttonPanel.Width = 500;
		_buttonPanel.Height = 200;

		_pictureBox = new PictureBox();
		_pictureBox.Height = 200;
		_pictureBox.Width = 200;
		_pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
												 AnchorStyles.Right | AnchorStyles.Left;

		_firstNameLabel = new Label();
		_firstNameLabel.Text = "First Name:";
		_middleNameLabel = new Label();
		_middleNameLabel.Text = "Middle Name:";
		_lastNameLabel = new Label();
		_lastNameLabel.Text = "Last Name:";
		_birthdayLabel = new Label();
		_birthdayLabel.Text = "Birthday:";
		_genderLabel = new Label();
		_genderLabel.Text = "Gender:";
		_firstNameTextBox = new TextBox();
		_firstNameTextBox.Width = 200;
		_middleNameTextBox = new TextBox();
		_middleNameTextBox.Width = 200;
		_lastNameTextBox = new TextBox();
		_lastNameTextBox.Width = 200;
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
		_clearButton = new Button();
		_clearButton.Text = "Clear";
		_clearButton.Click += this.ClearButtonHandler;
		_loadPictureButton = new Button();
		_loadPictureButton.Text = "Load Picture";
		_loadPictureButton.AutoSize = true;
		_loadPictureButton.Click += this.LoadPictureButtonHandler;
		_submitButton = new Button();
		_submitButton.Text = "Submit";
		_submitButton.Click += externalHandler.EmployeeSubmitButtonHandler;
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
		_infoTablePanel.Dock = DockStyle.Top;

		_buttonPanel.SuspendLayout();
		_buttonPanel.Controls.Add(_clearButton);
		_buttonPanel.Controls.Add(_loadPictureButton);
		_buttonPanel.Controls.Add(_submitButton);

		_mainTablePanel.SuspendLayout();
		_mainTablePanel.Controls.Add(_pictureBox);
		_mainTablePanel.Controls.Add(_infoTablePanel);
		_mainTablePanel.Controls.Add(_buttonPanel);
		_mainTablePanel.SetColumnSpan(_buttonPanel, 2);

		this.SuspendLayout();
		this.Controls.Add(_mainTablePanel); 
		this.Width = WINDOW_WIDTH;
		this.Height = WINDOW_HEIGHT;
		this.Text = "Employee Form";
		_infoTablePanel.ResumeLayout();
		_buttonPanel.ResumeLayout();
		_mainTablePanel.ResumeLayout();
		this.ResumeLayout();
		_dialog = new OpenFileDialog();
		_dialog.FileOk += this.LoadPicture;
	}

	private void ClearButtonHandler(Object sender, EventArgs e){
		this.ClearFields();
		_submitButton.Enabled = false;
	}

	private void LoadPictureButtonHandler(Object sender, EventArgs e){
		_dialog.ShowDialog();
	}

	private void LoadPicture(Object sender, EventArgs e){
		String filename = _dialog.FileName;
		_pictureBox.Image = new Bitmap(filename);
		_submitButton.Enabled = true;
	}

	public void ClearFields(){
		_firstNameTextBox.Text = String.Empty;
		_middleNameTextBox.Text = String.Empty;
		_lastNameTextBox.Text = String.Empty;
		_maleRadioButton.Checked = true;
		_birthdayPicker.Value = DateTime.Now;
		_pictureBox.Image = null;
	}

	private PersonVO.Sex RadioButtonToSexEnum(){
		PersonVO.Sex gender = PersonVO.Sex.MALE;
		if(_maleRadioButton.Checked){
			gender = PersonVO.Sex.MALE;
		} else{
				gender = PersonVO.Sex.FEMALE;
		}
		return gender;
	}

	private void SetRadioButton(PersonVO.Sex gender){
		if(gender == PersonVO.Sex.MALE){
			_maleRadioButton.Checked = true;
		} else{
			_femaleRadioButton.Checked = true;
		}
	}
} // end class definition