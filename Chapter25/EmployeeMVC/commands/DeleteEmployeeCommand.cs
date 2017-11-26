/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace Com.PulpFreePress.Commands {
	public class DeleteEmployeeCommand : BaseCommand {
		public override void Execute(){
			if((_model != null) && (_view != null)){
				int index = _view.GetSelectedLineNumber();
				Console.WriteLine(index);
				try{
					_model.DeleteEmployeeByIndex(index);
					_view.DisplayEmployeeInfo(_model.GetAllEmployeesInfo());
					_view.ClearInputFields();
				}catch(IndexOutOfRangeException e){
					Console.WriteLine(e);
				}
			}
		} // end Execute() method
	} // end DeleteEmployeeCommand class definition
} // end namespace