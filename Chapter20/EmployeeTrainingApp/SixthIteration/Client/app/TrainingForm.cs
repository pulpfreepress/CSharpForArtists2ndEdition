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
using System.Collections.Generic;
using EmployeeTraining.VO;

public class TrainingForm : Form {
	// constants
	private const int WINDOW_HEIGHT = 300;
	private const int WINDOW_WIDTH = 450;
	private const bool DEBUG = true;

	// fields
	private TableLayoutPanel _mainTablePanel;
	private TableLayoutPanel _infoTablePanel;
	private FlowLayoutPanel _buttonPanel;
	private Label _titleLabel;
	private Label _descriptionLabel;
	private Label _startDateLabel;
	private Label _endDateLabel;
	private Label _statusLabel;
	private TextBox _titleTextBox;
	private TextBox _descriptionTextBox;
	private DateTimePicker _startDatePicker;
	private DateTimePicker _endDatePicker;
	private GroupBox _statusGroupBox;
	private RadioButton _passedRadioButton;
	private RadioButton _failedRadioButton;
	private Button _clearButton;
	private Button _submitButton;
	private bool _createMode;

	// public properties -
	public String Title {
		get { return _titleTextBox.Text; }
		set { _titleTextBox.Text = value; }
	}

	public String Description {
		get { return _descriptionTextBox.Text; }
		set { _descriptionTextBox.Text = value; }
	}

	public DateTime StartDate {
		get { return _startDatePicker.Value; }
		set { _startDatePicker.Value = value; }
	}

	public DateTime EndDate {
		get { return _endDatePicker.Value; }
		set { _endDatePicker.Value = value; }
	}

	public TrainingVO.TrainingStatus Status {
		get { return this.RadioButtonToTrainingStatusEnum(); }
		set { this.SetRadioButton(value); }
	}

	public bool CreateMode {
		get { return _createMode; }
		set { _createMode = value; }
	}

	public TrainingForm(EmployeeTrainingClient externalHandler){
		this.InitializeComponent(externalHandler);
	}

	private void InitializeComponent(EmployeeTrainingClient externalHandler){
		_mainTablePanel = new TableLayoutPanel();
		_mainTablePanel.RowCount = 2;
		_mainTablePanel.ColumnCount = 1;
		_mainTablePanel.Height = 400;
		_mainTablePanel.Width = 500;
		_mainTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
														 AnchorStyles.Left | AnchorStyles.Right;

		_infoTablePanel = new TableLayoutPanel();
		_infoTablePanel.RowCount = 5;
		_infoTablePanel.ColumnCount = 2;
		_infoTablePanel.Height = 200;
		_infoTablePanel.Width = 300;
		_infoTablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
														 AnchorStyles.Left | AnchorStyles.Right;

		_buttonPanel = new FlowLayoutPanel();
		_buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | 
													AnchorStyles.Left | AnchorStyles.Right;

		_titleLabel = new Label();
		_titleLabel.Text = "Title:";
		_descriptionLabel = new Label();
		_descriptionLabel.Text = "Description:";
		_startDateLabel = new Label();
		_startDateLabel.Text = "Start Date:";
		_endDateLabel = new Label();
		_endDateLabel.Text = "End Date:";
		_statusLabel = new Label();
		_statusLabel.Text = "Status:";
		_titleTextBox = new TextBox();
		_titleTextBox.Width = 300;
		_descriptionTextBox = new TextBox();
		_descriptionTextBox.Width = 300;
		_startDatePicker = new DateTimePicker();
		_endDatePicker = new DateTimePicker();
		_statusGroupBox = new GroupBox();
		_statusGroupBox.Height = 75;
		_statusGroupBox.Width = 300;
		_passedRadioButton = new RadioButton();
		_passedRadioButton.Text = "Passed";
		_passedRadioButton.Checked = true;
		_passedRadioButton.Location = new Point(10, 10);
		_failedRadioButton = new RadioButton();
		_failedRadioButton.Text = "Failed";
		_failedRadioButton.Location = new Point(10, 30);
		_clearButton = new Button();
		_clearButton.Text = "Clear";
		_clearButton.Click += this.ClearButtonHandler;
		_submitButton = new Button();
		_submitButton.Text = "Submit";
		_submitButton.Click += externalHandler.TrainingSubmitButtonHandler;

		_statusGroupBox.Controls.Add(_passedRadioButton);
		_statusGroupBox.Controls.Add(_failedRadioButton);

		_infoTablePanel.SuspendLayout();
		_infoTablePanel.Controls.Add(_titleLabel);
		_infoTablePanel.Controls.Add(_titleTextBox);
		_infoTablePanel.Controls.Add(_descriptionLabel);
		_infoTablePanel.Controls.Add(_descriptionTextBox);
		_infoTablePanel.Controls.Add(_startDateLabel);
		_infoTablePanel.Controls.Add(_startDatePicker);
		_infoTablePanel.Controls.Add(_endDateLabel);
		_infoTablePanel.Controls.Add(_endDatePicker);
		_infoTablePanel.Controls.Add(_statusLabel);
		_infoTablePanel.Controls.Add(_statusGroupBox);

		_buttonPanel.Controls.Add(_clearButton);
		_buttonPanel.Controls.Add(_submitButton);

		_mainTablePanel.SuspendLayout();
		_mainTablePanel.Controls.Add(_infoTablePanel);
		_mainTablePanel.Controls.Add(_buttonPanel);
    
		this.SuspendLayout();
		this.Controls.Add(_mainTablePanel);
		this.Height = WINDOW_HEIGHT;
		this.Width = WINDOW_WIDTH;
		this.Text = "Training Form";
		_infoTablePanel.ResumeLayout();
		_mainTablePanel.ResumeLayout();
		this.ResumeLayout();
	}

	private TrainingVO.TrainingStatus RadioButtonToTrainingStatusEnum(){
		TrainingVO.TrainingStatus status = TrainingVO.TrainingStatus.Passed;
		if(_passedRadioButton.Checked){
			status = TrainingVO.TrainingStatus.Passed;
		} else{
				status = TrainingVO.TrainingStatus.Failed;
		}
		return status;
	}
	
	private void ClearButtonHandler(Object sender, EventArgs e){
		this.ClearFields();
	}

	public void ClearFields(){
		_titleTextBox.Text = String.Empty;
		_descriptionTextBox.Text = String.Empty;
		_startDatePicker.Value = DateTime.Now;
		_endDatePicker.Value = DateTime.Now;
		_passedRadioButton.Checked = true;
	}

	private void SetRadioButton(TrainingVO.TrainingStatus status){
		if(status == TrainingVO.TrainingStatus.Passed){
			_passedRadioButton.Checked = true;
		} else{
				_failedRadioButton.Checked = true;
		}
	}
} // end class definition