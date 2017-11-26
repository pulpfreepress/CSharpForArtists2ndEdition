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
	public class ClearInputFieldsCommand : BaseCommand {
		public override void Execute(){
			if(_view != null){
				_view.ClearInputFields();
				_view.EnableSubmitButton(false);
				_view.EnableCommonFields(false);
				_view.EnableHourlyFields(false);
				_view.EnableSalaryFields(false);
				_view.Mode = ViewMode.RESTING;
			}
		} // end Execute() method
	} // end ClearInputFieldsCommand
} // end namespace