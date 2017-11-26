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
using System.Windows.Forms;
using Com.PulpFreePress.Common;
using Com.PulpFreePress.Exceptions;
using Com.PulpFreePress.Commands;
using Com.PulpFreePress.Model;
using Com.PulpFreePress.View;
using Com.PulpFreePress.Utils;

namespace Com.PulpFreePress.Controller {
	public class Controller : IController {

		private readonly CommandFactory _commandFactory;
		private readonly IModel _model;
		private readonly IView  _view;

		public Controller(){
			_commandFactory = CommandFactory.GetInstance();
			_commandFactory.WorkingDirectory = Directory.GetCurrentDirectory();
			_model = new Com.PulpFreePress.Model.Model();
			_view = new Com.PulpFreePress.View.View(this);
		}
		
		public void CommandHandler(Object sender, EventArgs e){
			try {
				BaseCommand command;
				if(sender.GetType() == typeof(Button)){
					command = _commandFactory.GetCommand(((Button)sender).Name);
				} else {
						command = _commandFactory.GetCommand(((ToolStripMenuItem)sender).Name);
				}
				if(command != null){
					command.Model = _model;
					command.View = _view;
					command.Execute();
				}
			} catch(CommandNotFoundException){
					Console.WriteLine("Command not found!");
			} catch(Exception){
					Console.WriteLine("Problem executing command.");
			}
		}

		[STAThread]
		public static void Main(){
			Application.Run((Form)(new Controller())._view);
		} // end Main() method
	} // end Controller class definition
} // end namespace
