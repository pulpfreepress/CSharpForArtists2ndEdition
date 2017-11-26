/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using Com.PulpFreePress.Common;

namespace Com.PulpFreePress.Commands {
	public class SubmitCommand : BaseCommand {
		public override void Execute(){
			if((_view != null) && (_model != null)){
				switch(_view.Mode){
					case ViewMode.SALARIED: 
									_model.AddEmployee(_view.GetNewSalariedEmployee());
									_view.DisplayEmployeeInfo(_model.GetAllEmployeesInfo());
									break;
					case ViewMode.HOURLY:   
									_model.AddEmployee(_view.GetNewHourlyEmployee());
									_view.DisplayEmployeeInfo(_model.GetAllEmployeesInfo());
									break;
					case ViewMode.EDIT:    
									try{
										int index = _view.GetSelectedLineNumber();
										_model.EditEmployee(_view.GetEditedEmployee(), index);
										_view.DisplayEmployeeInfo(_model.GetAllEmployeesInfo());
										_view.EnableSubmitButton(false);
									}catch(IndexOutOfRangeException e){
									  Console.WriteLine(e);
									}catch(ArgumentException e1){
										Console.WriteLine(e1);
									}
									break;
				} // end switch
				_view.ClearInputFields();
				_view.EnableCommonFields(false);
				_view.EnableSubmitButton(false);
				_view.EnableSalaryFields(false);
				_view.Mode = ViewMode.RESTING;
			}	// end if
		} // end Execute() method
  } // end SubmitCommand class definition
} // end namespace