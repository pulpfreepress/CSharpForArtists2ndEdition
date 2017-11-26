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
	public class SaveEmployeesCommand : BaseCommand {
		public override void Execute(){
			if((_model != null) && (_view != null)){
				_model.SaveEmployeesToFile(_view.GetSaveFile());
				_view.DisplayEmployeeInfo(_model.GetAllEmployeesInfo());
			}
		} // end Execute() method
	} // end SaveEmployeesCommand class definition
} // end namespace
