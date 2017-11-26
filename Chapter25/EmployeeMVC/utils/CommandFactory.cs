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
using System.Reflection;
using Com.PulpFreePress.Commands;
using Com.PulpFreePress.Exceptions;

namespace Com.PulpFreePress.Utils {
	public class CommandFactory {

		private static CommandFactory _commandFactoryInstance;
		private static CommandProperties _commandProperties;
		private static string _workingDirectory = string.Empty;

		static CommandFactory() {
			_commandProperties = CommandProperties.GetInstance();
		}

		private CommandFactory(){}

		public static CommandFactory GetInstance(){
			if(_commandFactoryInstance == null){
				_commandFactoryInstance = new CommandFactory();
			}
			return _commandFactoryInstance;
		}
  
		public string WorkingDirectory {
			get { return _workingDirectory; }
			set { _workingDirectory = value; }
		}

		/******************************************************************
		Throws CommandNotFoundException if command does not exist or 
		commandString equals null.
		****************************************************************/
		public BaseCommand GetCommand(string commandString){
			BaseCommand command = null;
			if(string.IsNullOrEmpty(commandString)){
				throw new ArgumentException( commandString + " command class not found!");
			} else { 
					try {
						// expect to find commands in Commands.dll
						Assembly assembly = Assembly.LoadFrom(_workingDirectory + "\\Commands.dll"); 
						string commandTypeName = _commandProperties.GetProperty(commandString);
						foreach(Type t in assembly.GetTypes()){
							if(t.Name == commandTypeName){
								command = (BaseCommand) Activator.CreateInstance(t);
							}
						}
					} catch(Exception ex){
							Console.WriteLine(ex);
							throw new CommandNotFoundException(ex.ToString(), ex);
					}
				} // end else
			return command;
		} // end GetCommand() method
	} // end CommandFactory class definition
} // end namespace