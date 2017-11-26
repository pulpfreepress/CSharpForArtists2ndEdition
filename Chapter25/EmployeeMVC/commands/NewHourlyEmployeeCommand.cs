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
	public class NewHourlyEmployeeCommand : BaseCommand {
		public override void Execute(){
			if(_view != null){
				_view.EnableCommonFields(true);
				_view.EnableHourlyFields(true);
				_view.EnableSalaryFields(false);
				_view.ClearInputFields();
				_view.EnableSubmitButton(true);
				_view.Mode = ViewMode.HOURLY;
			}       
		} // end Execute() method
	} // end NewHourlyEmployeeCommand class definition
} // end namespace