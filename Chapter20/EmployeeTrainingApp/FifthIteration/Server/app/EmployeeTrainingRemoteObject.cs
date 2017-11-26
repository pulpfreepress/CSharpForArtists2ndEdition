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
using EmployeeTraining.BO;

public class EmployeeTrainingRemoteObject : MarshalByRefObject, IEmployeeTraining {

  #region Employee Methods 

	public List<EmployeeVO> GetAllEmployees(){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.GetAllEmployees();
	}

	public EmployeeVO GetEmployee(Guid employeeID){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.GetEmployee(employeeID);
	}

	public EmployeeVO CreateEmployee(EmployeeVO employee){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.CreateEmployee(employee);
	}

	public EmployeeVO UpdateEmployee(EmployeeVO employee){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.UpdateEmployee(employee);
	}

	public void DeleteEmployee(Guid employeeID){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.DeleteEmployee(employeeID);
	}
	#endregion Employee Methods

	#region Training Methods
	
	public TrainingVO CreateTraining(TrainingVO training){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.CreateTraining(training);
	}

	public TrainingVO GetTraining(int trainingID){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.GetTraining(trainingID);
	}

	public List<TrainingVO> GetTrainingForEmployee(Guid employeeID){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.GetTrainingForEmployee(employeeID);
	}

	public TrainingVO UpdateTraining(TrainingVO training){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		return bo.UpdateTraining(training);
	}

	public void DeleteTraining(int trainingID){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.DeleteTraining(trainingID);
	}

	public void DeleteTrainingForEmployee(Guid employeeID){
		EmployeeAdminBO bo = new EmployeeAdminBO();
		bo.DeleteTrainingForEmployee(employeeID);
	}

	#endregion Training Methods
}