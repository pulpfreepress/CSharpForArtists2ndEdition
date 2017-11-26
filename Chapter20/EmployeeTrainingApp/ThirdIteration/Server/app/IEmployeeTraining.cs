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

public interface IEmployeeTraining {

	#region Employee Methods
	List<EmployeeVO> GetAllEmployees();
	EmployeeVO GetEmployee(Guid employeeID);
	EmployeeVO CreateEmployee(EmployeeVO employee);
	EmployeeVO UpdateEmployee(EmployeeVO employee);
	void DeleteEmployee(Guid employeeID);
	#endregion Employee Methods

	#region Training Methods
	List<TrainingVO> GetTrainingForEmployee(Guid employeeID);
	TrainingVO GetTraining(int trainingID);
	TrainingVO CreateTraining(TrainingVO training);
	TrainingVO UpdateTraining(TrainingVO training);
	void DeleteTraining(int trainingID);
	void DeleteTrainingForEmployee(Guid employeeID);
	#endregion TrainingMethods
}