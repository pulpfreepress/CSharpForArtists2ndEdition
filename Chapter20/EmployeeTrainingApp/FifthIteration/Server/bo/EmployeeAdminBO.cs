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
using EmployeeTraining.VO;
using EmployeeTraining.DAO;

namespace EmployeeTraining.BO {

	public class EmployeeAdminBO {

		#region Employee Methods  

		public EmployeeVO CreateEmployee(EmployeeVO employee){
			EmployeeDAO dao = new EmployeeDAO();
			return dao.InsertEmployee(employee);
		}

		public EmployeeVO GetEmployee(Guid employeeID){
			EmployeeDAO dao = new EmployeeDAO();
			return dao.GetEmployee(employeeID);
		}

		public List<EmployeeVO> GetAllEmployees(){
			EmployeeDAO dao = new EmployeeDAO();
			return dao.GetAllEmployees();
		}

		public EmployeeVO UpdateEmployee(EmployeeVO employee){
			EmployeeDAO dao = new EmployeeDAO();
			return dao.UpdateEmployee(employee);
		}

		public void DeleteEmployee(Guid employeeID){
			EmployeeDAO dao = new EmployeeDAO();
			dao.DeleteEmployee(employeeID);
		}
		#endregion Employee Methods

		#region Training Methods
		public TrainingVO CreateTraining(TrainingVO training){
			TrainingDAO dao = new TrainingDAO();
			return dao.InsertTraining(training);
		}

		public TrainingVO GetTraining(int trainingID){
			TrainingDAO dao = new TrainingDAO();
			return dao.GetTraining(trainingID);
		}

		public List<TrainingVO> GetTrainingForEmployee(Guid employeeID){
			TrainingDAO dao = new TrainingDAO();
			return dao.GetTrainingForEmployee(employeeID);
		}

		public TrainingVO UpdateTraining(TrainingVO training){
			TrainingDAO dao = new TrainingDAO();
			return dao.UpdateTraining(training);
		}

		public void DeleteTrainingForEmployee(Guid employeeID){
			TrainingDAO dao = new TrainingDAO();
			dao.DeleteTrainingForEmployeeID(employeeID);
		}
 
		public void DeleteTraining(int trainingID){
			TrainingDAO dao = new TrainingDAO();
			dao.DeleteTraining(trainingID);
		}   
		#endregion Training Methods
	} // End class definition
} // End namespace