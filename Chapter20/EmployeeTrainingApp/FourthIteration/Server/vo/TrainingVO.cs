/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace EmployeeTraining.VO {

	[Serializable]
	public class TrainingVO {

		// Status enumeration
		public enum TrainingStatus { Passed, Failed };
		// Private fields    
		private int _trainingID;
		private Guid _employeeID;
		private string _title;
		private string _description;
		private DateTime _startDate;
		private DateTime _endDate;
		private TrainingStatus _status;

		//Constructors
		public TrainingVO(){}

		public TrainingVO(int trainingID, Guid employeeID, string title, string description,
											DateTime startdate, DateTime enddate, TrainingStatus status){ 
			_trainingID = trainingID;
			_employeeID = employeeID;
			_title = title;
			_description = description;
			_startDate = startdate;
			_endDate = enddate;
			_status = status;
		}

		//Properties
		public int TrainingID {
			get { return _trainingID; }
			set { _trainingID = value; }
		}

		public Guid EmployeeID {
			get { return _employeeID; }
			set { _employeeID = value; }
		}

		public string Title {
			get { return _title; }
			set { _title = value; }
		}

		public string Description {
			get { return _description; }
			set { _description = value; }
		}

		public DateTime StartDate {
			get { return _startDate; }
			set {_startDate = value; }
		}

		public DateTime EndDate {
			get { return _endDate; }
			set { _endDate = value; }
		}

		public TrainingStatus Status {
			get { return _status; }
			set { _status = value; }
		}

		public override string ToString(){
			return _title + " " + _description + " " + _endDate + " " + _startDate +
							" " + _status;
		}
	} // end class definition
} // end namespace