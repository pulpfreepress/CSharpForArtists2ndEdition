/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Com.PulpFreePress.Common;

namespace Com.PulpFreePress.Model { 
	public class Model : IModel {

		// constants
		private const string DEFAULT_EMPLOYEES_FILENAME = "Employees.dat";
		// fields
		private List<IEmployee> _employeeList;
		private string _workingFileName;
		
		public string WorkingFileName {
		  get { return _workingFileName; }
			set { _workingFileName = value; }
		}

		public Model(){
			_employeeList = new List<IEmployee>();
		}

		/****************************************************
		Throws ArgumentException if employee argument is null.
		*****************************************************/
		public void AddEmployee(IEmployee employee){ 
			if(employee == null){
				throw new ArgumentException("Employee argument is null.");
			}
			_employeeList.Add(employee);                                                                
		}

		/*****************************************************
		Throws IndexOutOfRangeException if index is invalid.
		Throws ArgumentException if employee argument
		is null.
		*****************************************************/
		public void EditEmployee(IEmployee employee, int index){
			if((index < 0) || (index >= _employeeList.Count)){ 
				throw new IndexOutOfRangeException("Index value " + index + " is invalid."); 
			}
			if(employee == null){
			  throw new ArgumentException("Employee argument is null.");
			}
			_employeeList[index] = employee;                               
		}

		public String[] GetAllEmployeesInfo(){
			String[] emp_info = new String[_employeeList.Count];
			for(int i = 0; i<_employeeList.Count; i++){
				emp_info[i] = _employeeList[i].ToString();
			}
			return emp_info;
		}

		/*******************************************************
		Throws ArgumentException if employeeNumber argument
		is null or empty. Returns null if employee not found.
		*******************************************************/
		public IEmployee GetEmployeeByEmployeeNumber(String employeeNumber){
			if(string.IsNullOrEmpty(employeeNumber)){
				throw new ArgumentException("employeeNumber argument is invalid.");
			}
			IEmployee employee = null;
			foreach(IEmployee emp in _employeeList){
				employee = emp;
				if(employee.EmployeeNumber.Equals(employeeNumber)) break;
			}
			return employee;
		}

		/*********************************************************
		Throws IndexOutOfRangeException if index is invalid.
		Returns null if _employeeList is empty.
		*********************************************************/
		public IEmployee GetEmployeeByIndex(int index){
			if((index < 0) || (index >= _employeeList.Count)){ 
				throw new IndexOutOfRangeException("Index value " + index + " is invalid.");    
			}
			if(_employeeList.Count > 0) {
				return _employeeList[index];
			} 
			return null;
		}

		public void SortEmployees(){
			_employeeList.Sort();
		}

		/*********************************************************
		Throws IndexOutOfRangeException if index is invalid.
		*********************************************************/
		public void DeleteEmployeeByIndex(int index){
			if((index < 0) || (index >= _employeeList.Count)){ 
				throw new IndexOutOfRangeException("Index value " + index + " is invalid.");
			}
			if(_employeeList.Count > 0) {
				_employeeList.RemoveAt(index);
			}
		}

		public void SaveEmployeesToFile(String filename){
			if(string.IsNullOrEmpty(filename)){
				filename = DEFAULT_EMPLOYEES_FILENAME;
			}
			_workingFileName = filename;
			FileStream fs = null;
			try {
				fs = new FileStream(_workingFileName, FileMode.Create);
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(fs, _employeeList);
			} catch(FileNotFoundException){
					Console.WriteLine(_workingFileName + " file not found!");
			} catch(Exception e){
					Console.WriteLine(e);
			} finally {
					if(fs != null) fs.Close();
				}
		} 

		/*********************************************************
		Throws FileNotFoundException if filename does not exist.
		*********************************************************/
		public void LoadEmployeesFromFile(String filename){
			if(string.IsNullOrEmpty(filename)){
				filename = DEFAULT_EMPLOYEES_FILENAME;
			}
			
			if(!File.Exists(filename)){
				throw new FileNotFoundException(filename + " not found!");
			}
			
			_workingFileName = filename;
			FileStream fs = null;
			try {
				fs = new FileStream(_workingFileName, FileMode.Open);
				BinaryFormatter bf = new BinaryFormatter();
				_employeeList  = (List<IEmployee>)bf.Deserialize(fs);
			} catch(FileNotFoundException){
					Console.WriteLine(_workingFileName + " file not found!");
			} catch(Exception ex){
					Console.WriteLine(ex);
			} finally{
					if(fs != null) fs.Close();
				}
		}
	} // end Model class definition
} // namespace