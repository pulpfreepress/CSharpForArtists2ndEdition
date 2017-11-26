/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;

namespace Com.PulpFreePress.Utils {
	public class CommandProperties : XmlProperties {

		// class constants - default key strings
		public const String PROPERTIES_FILE          			= "PROPERTIES_FILE";
		public const String NEWHOURLYEMPLOYEE_COMMAND			= "NewHourlyEmployee";
		public const String NEWSALARIEDEMPLOYEE_COMMAND		= "NewSalariedEmployee";
		public const String EXIT_COMMAND			            = "Exit";
		public const String LIST_COMMAND			            = "List";
		public const String SORT_COMMAND			            = "Sort";
		public const String SAVE_COMMAND			            = "Save";
		public const String EDITEMPLOYEE_COMMAND		      = "EditEmployee";
		public const String DELETEEMPLOYEE_COMMAND		    = "DeleteEmployee";
		public const String LOAD_COMMAND			            = "Load";
		public const String CLEAR_COMMAND			          	= "Clear";
		public const String SUBMIT_COMMAND			          = "Submit";
   
		// class constants - default value strings
		private const String PROPERTIES_FILE_VALUE	 = "CommandProperties.XML";
		private const String NEWHOURLYEMPLOYEE_COMMAND_CLASSNAME	= "NewHourlyEmployeeCommand";
		private const String NEWSALARIEDEMPLOYEE_COMMAND_CLASSNAME	= "NewSalariedEmployeeCommand";
		private const String EXIT_COMMAND_CLASSNAME			= "ApplicationExitCommand";
		private const String LIST_COMMAND_CLASSNAME			= "ListEmployeesCommand";
		private const String SORT_COMMAND_CLASSNAME			= "SortEmployeesCommand";
		private const String SAVE_COMMAND_CLASSNAME			= "SaveEmployeesCommand";
		private const String EDITEMPLOYEE_COMMAND_CLASSNAME		= "EditEmployeeCommand";
		private const String DELETEEMPLOYEE_COMMAND_CLASSNAME		= "DeleteEmployeeCommand";
		private const String LOAD_COMMAND_CLASSNAME			= "LoadEmployeesCommand";
		private const String CLEAR_COMMAND_CLASSNAME			= "ClearInputFieldsCommand";
		private const String SUBMIT_COMMAND_CLASSNAME			= "SubmitCommand";
   
		// private fields
		private static CommandProperties _props;

		//private constructor
		private CommandProperties():this(PROPERTIES_FILE_VALUE) { }

		private CommandProperties(String filename):base(filename){
			try {
				base.Read(filename);
			}catch(IOException){
				SetProperty(PROPERTIES_FILE, PROPERTIES_FILE_VALUE);
				SetProperty(NEWHOURLYEMPLOYEE_COMMAND, NEWHOURLYEMPLOYEE_COMMAND_CLASSNAME);
				SetProperty(NEWSALARIEDEMPLOYEE_COMMAND, NEWSALARIEDEMPLOYEE_COMMAND_CLASSNAME);
				SetProperty(EXIT_COMMAND, EXIT_COMMAND_CLASSNAME);
				SetProperty(LIST_COMMAND, LIST_COMMAND_CLASSNAME);
				SetProperty(SORT_COMMAND, SORT_COMMAND_CLASSNAME);
				SetProperty(SAVE_COMMAND, SAVE_COMMAND_CLASSNAME);
				SetProperty(EDITEMPLOYEE_COMMAND, EDITEMPLOYEE_COMMAND_CLASSNAME);
				SetProperty(DELETEEMPLOYEE_COMMAND, DELETEEMPLOYEE_COMMAND_CLASSNAME);
				SetProperty(LOAD_COMMAND, LOAD_COMMAND_CLASSNAME);
				SetProperty(CLEAR_COMMAND, CLEAR_COMMAND_CLASSNAME);
				SetProperty(SUBMIT_COMMAND, SUBMIT_COMMAND_CLASSNAME);
				base.Store();
			}
		}

		// default GetInstance() method
		public static CommandProperties GetInstance(){
			return GetInstance(PROPERTIES_FILE_VALUE);
		}

		// Overloaded GetInstance() method
		public static CommandProperties GetInstance(String filename){
			if(_props == null){
				_props = new CommandProperties();
			}
     return _props;
		}
	} // end class definition
} // end namespace