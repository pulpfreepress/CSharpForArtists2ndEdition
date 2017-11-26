/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using EmployeeTraining.VO;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EmployeeTraining.DAO {

	public class TrainingDAO : BaseDAO {

		//List of column identifiers used in perpared statements
		private const string TRAINING_ID = "@training_id";
		private const string EMPLOYEE_ID = "@employee_id";
		private const string TITLE = "@title";
		private const string DESCRIPTION = "@description";
		private const string STARTDATE = "@startdate";
		private const string ENDDATE = "@enddate";
		private const string STATUS = "@status";
		
		// SQL statement string constants
		private const string SELECT_ALL_COLUMNS =
			"SELECT trainingid, employeeid, title, description, startdate, enddate, status ";

		private const string SELECT_ALL_TRAINING = 
			SELECT_ALL_COLUMNS +
			"FROM tbl_employee_training ";

		private const string SELECT_TRAINING_BY_TRAINING_ID =
			SELECT_ALL_TRAINING +
			"WHERE TrainingID = " + TRAINING_ID;

		private const string SELECT_TRAINING_BY_EMPLOYEE_ID =
			SELECT_ALL_TRAINING +
			"WHERE employeeid = " + EMPLOYEE_ID;

		private const string INSERT_TRAINING = 
			"INSERT INTO tbl_employee_training " +
					"(EmployeeID, Title, Description, StartDate, EndDate, Status) " +
			"VALUES (" + EMPLOYEE_ID + ", " + TITLE + ", " + DESCRIPTION + ", " +
							STARTDATE + ", " + ENDDATE + ", " + STATUS + ") " +
			"SELECT scope_identity()";
       
		private const string UPDATE_TRAINING =
			"UPDATE tbl_employee_training " +
			"SET EmployeeID = " + EMPLOYEE_ID + ", Title = " + TITLE + ", Description = " 
													+ DESCRIPTION + ", StartDate = " + STARTDATE + ", EndDate = " 
													+ ENDDATE + ", Status = " + STATUS + " " +
			"Where TrainingID = " + TRAINING_ID;

		private const string DELETE_TRAINING = 
			"DELETE FROM tbl_employee_training " +
			"WHERE TrainingID = " + TRAINING_ID;

		private const string DELETE_TRAINING_FOR_EMPLOYEEID =
			"DELETE FROM tbl_employee_training " +
			"WHERE EmployeeID = " + EMPLOYEE_ID;

		// Public methods
		/***************************************************************************
		Gets a list of all training in the database.
		****************************************************************************/
		public List<TrainingVO> GetAllTraining(){
			DbCommand command = DataBase.GetSqlStringCommand(SELECT_ALL_TRAINING);
			return this.GetTrainingList(command);
		}

		/***********************************************
		Returns a TrainingVO object given a valid trainingid
		*************************************************/
		public TrainingVO GetTraining(int trainingid){
			DbCommand command = null;
			try{
				command = DataBase.GetSqlStringCommand(SELECT_TRAINING_BY_TRAINING_ID);
				DataBase.AddInParameter(command, TRAINING_ID, DbType.Int32, trainingid);
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetTraining(command);
		}

		/***********************************************
		Returns a List<TrainingVO> object given a valid employeeid
		*************************************************/
		public List<TrainingVO> GetTrainingForEmployee(Guid employeeid){
			DbCommand command = null;
			try{
				command = DataBase.GetSqlStringCommand(SELECT_TRAINING_BY_EMPLOYEE_ID);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, employeeid);
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetTrainingList(command);
		}

		/*******************************************************************
		Inserts a row into tbl_employee_training given populated TrainingVO object.
		Returns fully-populated TrainingVO object, including primary key.
		********************************************************************/
		public TrainingVO InsertTraining(TrainingVO trainingVO){
			int trainingID = 0;
			try{
				DbCommand command = DataBase.GetSqlStringCommand(INSERT_TRAINING);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, trainingVO.EmployeeID);
				DataBase.AddInParameter(command, TITLE, DbType.String, trainingVO.Title);
				DataBase.AddInParameter(command, DESCRIPTION, DbType.String, trainingVO.Description);
				DataBase.AddInParameter(command, STARTDATE, DbType.DateTime, trainingVO.StartDate);
				DataBase.AddInParameter(command, ENDDATE, DbType.DateTime, trainingVO.EndDate);
				switch(trainingVO.Status){
					case TrainingVO.TrainingStatus.Passed : 
							DataBase.AddInParameter(command, STATUS, DbType.String, "Passed");
							break;
					case TrainingVO.TrainingStatus.Failed :
							DataBase.AddInParameter(command, STATUS, DbType.String, "Failed");
							break;
				}
				trainingID = Convert.ToInt32(DataBase.ExecuteScalar(command));
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetTraining(trainingID);
		}

		/***************************************************************************
		Updates a row in the tbl_employee_training table given a populated TrainingVO object.
		****************************************************************************/
		public TrainingVO UpdateTraining(TrainingVO trainingVO){
			try{
				DbCommand command = DataBase.GetSqlStringCommand(UPDATE_TRAINING);
				DataBase.AddInParameter(command, TRAINING_ID, DbType.Int32, trainingVO.TrainingID);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, trainingVO.EmployeeID);
				DataBase.AddInParameter(command, TITLE, DbType.String, trainingVO.Title);
				DataBase.AddInParameter(command, DESCRIPTION, DbType.String, trainingVO.Description);
				DataBase.AddInParameter(command, STARTDATE, DbType.DateTime, trainingVO.StartDate);
				DataBase.AddInParameter(command, ENDDATE, DbType.DateTime, trainingVO.EndDate);
				switch(trainingVO.Status){
					case TrainingVO.TrainingStatus.Passed : 
						DataBase.AddInParameter(command, STATUS, DbType.String, "Passed");
						break;
					case TrainingVO.TrainingStatus.Failed :
						DataBase.AddInParameter(command, STATUS, DbType.String, "Failed");
						break;
				}
				DataBase.ExecuteNonQuery(command);
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetTraining(trainingVO.TrainingID);
		}

		/***************************************************************************
		Deletes a row from the tbl_employee_training table for the given a training id.
		****************************************************************************/
		public void DeleteTraining(int trainingid){
			try {
				DbCommand command = DataBase.GetSqlStringCommand(DELETE_TRAINING);
				DataBase.AddInParameter(command, TRAINING_ID, DbType.Int32, trainingid);
				DataBase.ExecuteNonQuery(command);
			} catch(Exception e){
					Console.WriteLine(e);
			}
		}

		/***************************************************************************
		Deletes all training associated with given employee id.
		****************************************************************************/
		public void DeleteTrainingForEmployeeID(Guid employeeid){
			try {
				DbCommand command = DataBase.GetSqlStringCommand(DELETE_TRAINING_FOR_EMPLOYEEID);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, employeeid);
				DataBase.ExecuteNonQuery(command);
			} catch(Exception e){
					Console.WriteLine(e);
			}
		}

		/************************************************
		Private utility method that executes the given DbCommand
		and returns a fully-populated TrainingVO object
		*************************************************/
		private TrainingVO GetTraining(DbCommand command){
			TrainingVO trainingVO = null;
			IDataReader reader = null;
			try {
				reader = DataBase.ExecuteReader(command);
				if(reader.Read()){
					trainingVO = this.FillInTrainingVO(reader);
				}
			} catch(Exception e){
					Console.WriteLine(e);
			} finally {	
					base.CloseReader(reader);
			}
			return trainingVO;
		}

		/*************************************************************
		Private utility method that gets a list of TrainingVOs given a DbCommand
		*****************************************************************/
		private List<TrainingVO> GetTrainingList(DbCommand command){
			IDataReader reader = null;
			List<TrainingVO> training_list = new List<TrainingVO>();
			try{
				reader = DataBase.ExecuteReader(command);
				while(reader.Read()){
					TrainingVO trainingVO = this.FillInTrainingVO(reader);
					training_list.Add(trainingVO);
				}
			} catch(Exception e){
					Console.WriteLine(e);
			} finally{
					base.CloseReader(reader);
			}
			return training_list;
		}

		/*********************************************************************
		Private utility method that fills in a TrainingVO
		*********************************************************************/
		private TrainingVO FillInTrainingVO(IDataReader reader){
			TrainingVO trainingVO = new TrainingVO();
			trainingVO.TrainingID = reader.GetInt32(0);
			trainingVO.EmployeeID = reader.GetGuid(1);
			trainingVO.Title = reader.GetString(2);
			trainingVO.Description = reader.GetString(3);
			trainingVO.StartDate = reader.GetDateTime(4);
			trainingVO.EndDate = reader.GetDateTime(5);
			string status = reader.GetString(6);
			switch(status){
				case "Passed" : trainingVO.Status = TrainingVO.TrainingStatus.Passed;
												break;
				case "Failed" : trainingVO.Status = TrainingVO.TrainingStatus.Failed;
												break;            
			}
			return trainingVO;
		}
 
  } // end class definition
} // end namespace