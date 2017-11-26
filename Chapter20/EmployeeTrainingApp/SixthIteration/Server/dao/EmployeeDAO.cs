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
	public class EmployeeDAO : BaseDAO {
  
		private bool debug = false;

		//List of column identifiers used in prepared statements
		private const string EMPLOYEE_ID = "@employee_id";
		private const string FIRST_NAME = "@first_name";
		private const string MIDDLE_NAME = "@middle_name";
		private const string LAST_NAME = "@last_name";
		private const string BIRTHDAY = "@birthday";
		private const string GENDER = "@gender";
		private const string PICTURE = "@picture";

		private const string SELECT_ALL_COLUMNS =
			"SELECT employeeid, firstname, middlename, lastname, birthday, gender, picture ";

		private const string SELECT_ALL_EMPLOYEES = 
			SELECT_ALL_COLUMNS +
			"FROM tbl_employee ";

		private const string SELECT_EMPLOYEE_BY_EMPLOYEE_ID =
			SELECT_ALL_EMPLOYEES +
			"WHERE employeeid = " + EMPLOYEE_ID;

		private const string INSERT_EMPLOYEE = 
			"INSERT INTO tbl_employee " +
					"(EmployeeID, FirstName, MiddleName, LastName, Birthday, Gender, Picture) " +
			"VALUES (" + EMPLOYEE_ID + ", " + FIRST_NAME + ", " + MIDDLE_NAME + ", " 
								 + LAST_NAME + ", " + BIRTHDAY + ", " + GENDER + ", " + PICTURE + ")";

		private const string UPDATE_EMPLOYEE =
			"UPDATE tbl_employee " +
			"SET FirstName = " + FIRST_NAME + ", MiddleName = " + MIDDLE_NAME + 
											 ", LastName = " + LAST_NAME + ", Birthday = " + BIRTHDAY + 
											", Gender = " + GENDER + ", Picture = " + PICTURE + " " +
			"WHERE EmployeeID = " + EMPLOYEE_ID;

		private const string DELETE_EMPLOYEE =
			"DELETE FROM tbl_employee " +
			"WHERE EmployeeID = " + EMPLOYEE_ID;

		/************************************
		Returns a List<EmployeeVO> object
		**************************************/
		public List<EmployeeVO> GetAllEmployees(){
			DbCommand command = DataBase.GetSqlStringCommand(SELECT_ALL_EMPLOYEES);
			return this.GetEmployeeList(command);
		}

		/***********************************************
		Returns an EmployeeVO object given a valid employeeid
		*************************************************/
		public EmployeeVO GetEmployee(Guid employeeid){
			DbCommand command = null;
			try{
				command = DataBase.GetSqlStringCommand(SELECT_EMPLOYEE_BY_EMPLOYEE_ID);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, employeeid);
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetEmployee(command);
		}

		/*******************************************************
		Inserts an employee given a fully-populated EmployeeVO object
		*********************************************************/
		public EmployeeVO InsertEmployee(EmployeeVO employee){
			try{
				employee.EmployeeID = Guid.NewGuid();
				DbCommand command = DataBase.GetSqlStringCommand(INSERT_EMPLOYEE);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, employee.EmployeeID);
				DataBase.AddInParameter(command, FIRST_NAME, DbType.String, employee.FirstName);
				DataBase.AddInParameter(command, MIDDLE_NAME, DbType.String, employee.MiddleName);
				DataBase.AddInParameter(command, LAST_NAME, DbType.String, employee.LastName);
				DataBase.AddInParameter(command, BIRTHDAY, DbType.DateTime, employee.Birthday);
				switch(employee.Gender){
					case EmployeeVO.Sex.MALE: 
							DataBase.AddInParameter(command, GENDER, DbType.String, "M");
							break;
					case EmployeeVO.Sex.FEMALE: 
							DataBase.AddInParameter(command, GENDER, DbType.String, "F");
							break;
				}

				if(employee.Picture != null){
					if(debug) Console.WriteLine("Inserting picture!"); 
					if(debug){
						for(int i=0; i<employee.Picture.Length; i++){
						Console.Write(employee.Picture[i]);
						}
					} // end if debug
					DataBase.AddInParameter(command, PICTURE, DbType.Binary, employee.Picture); 
					if(debug) Console.WriteLine("Picture inserted, I think!");
				}
				DataBase.ExecuteNonQuery(command);
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetEmployee(employee.EmployeeID);
		}

		/********************************************************
		Updates a row in the tbl_employee table given the fully-populated
		EmployeeVO object.
		**********************************************************/
		public EmployeeVO UpdateEmployee(EmployeeVO employee){
			try {
				DbCommand command = DataBase.GetSqlStringCommand(UPDATE_EMPLOYEE);
				DataBase.AddInParameter(command, FIRST_NAME, DbType.String, employee.FirstName);
				DataBase.AddInParameter(command, MIDDLE_NAME, DbType.String, employee.MiddleName);
				DataBase.AddInParameter(command, LAST_NAME, DbType.String, employee.LastName);
				DataBase.AddInParameter(command, BIRTHDAY, DbType.DateTime, employee.Birthday);
				switch(employee.Gender){
					case EmployeeVO.Sex.MALE: 
							DataBase.AddInParameter(command, GENDER, DbType.String, "M");
							break;
					case EmployeeVO.Sex.FEMALE: 
							DataBase.AddInParameter(command, GENDER, DbType.String, "F");
							break;
				}
				if(employee.Picture != null){
					if(debug) Console.WriteLine("Inserting picture!");
					if(debug){
						for(int i=0; i<employee.Picture.Length; i++){
							Console.Write(employee.Picture[i]);
						}
					} // end if debug
					DataBase.AddInParameter(command, PICTURE, DbType.Binary, employee.Picture); 
					if(debug) Console.WriteLine("Picture inserted, I think!"); 
				}
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, employee.EmployeeID);
				DataBase.ExecuteNonQuery(command);
			} catch(Exception e){
					Console.WriteLine(e);
			}
			return this.GetEmployee(employee.EmployeeID);
		}

		/********************************************************
		Deletes a row from the tbl_employee table given an employee id.
		*********************************************************/
		public void DeleteEmployee(Guid employeeid){
			try{
				DbCommand command = DataBase.GetSqlStringCommand(DELETE_EMPLOYEE);
				DataBase.AddInParameter(command, EMPLOYEE_ID, DbType.Guid, employeeid);
				DataBase.ExecuteNonQuery(command);
			} catch(Exception e){
					Console.WriteLine(e);
			}
		}

		/************************************************
		Private utility method that executes the given DbCommand
		and returns a fully-populated EmployeeVO object
		*************************************************/
		private EmployeeVO GetEmployee(DbCommand command){
			EmployeeVO empVO = null;
			IDataReader reader = null;
			try {
				reader = DataBase.ExecuteReader(command);
				if(reader.Read()){
					empVO = this.FillInEmployeeVO(reader);
				}
			} catch(Exception e){
					Console.WriteLine(e);
			} finally {
					base.CloseReader(reader);
			}
			return empVO;
		}

		/****************************************************
		GetEmployeeList() - returns a List<EmployeeVO> object
		******************************************************/
		private List<EmployeeVO> GetEmployeeList(DbCommand command){
			IDataReader reader = null;
			List<EmployeeVO> employee_list = new List<EmployeeVO>();
			try{
				reader = DataBase.ExecuteReader(command);
				while(reader.Read()){
					EmployeeVO empVO = this.FillInEmployeeVO(reader);
					employee_list.Add(empVO);
				}
			} catch(Exception e){
					Console.WriteLine(e);
			} finally{
					base.CloseReader(reader);
			}
			return employee_list;
		}

		/********************************************************
		Private utility method that populates an EmployeeVO object from
		data read from the IDataReader object
		************************************************************/
		private EmployeeVO FillInEmployeeVO(IDataReader reader){
			EmployeeVO empVO = new EmployeeVO();
			empVO.EmployeeID = reader.GetGuid(0);
			empVO.FirstName = reader.GetString(1);
			empVO.MiddleName = reader.GetString(2);
			empVO.LastName = reader.GetString(3);
			empVO.Birthday = reader.GetDateTime(4);
			string gender = reader.GetString(5);
			switch(gender){
				case "M" : empVO.Gender = EmployeeVO.Sex.MALE;
									 break;
				case "F" : empVO.Gender = EmployeeVO.Sex.FEMALE;
									 break;
			}
			if(!reader.IsDBNull(6)){
				empVO.Picture = (byte[])reader.GetValue(6);
			}
			return empVO;
		}
	} // end EmployeeDAO definition
} // end namespace