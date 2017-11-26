/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using  System.IO;

namespace Com.PulpFreePress.Commands {
	public class ListEmployeesCommand : BaseCommand {
		public override void Execute(){
			if((_model != null) && (_view != null)){
				try{
					_model.LoadEmployeesFromFile(_model.WorkingFileName);
				}catch(FileNotFoundException){
					_model.LoadEmployeesFromFile(_view.GetLoadFile());
				}finally{
					_view.DisplayEmployeeInfo(_model.GetAllEmployeesInfo());
				}
			}
		}
	} // end ListEmployeesCommand
} // end namespace