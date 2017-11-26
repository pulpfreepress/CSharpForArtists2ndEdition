/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public abstract class BaseCommand {
	protected static IModel _model;
	protected static IView  _view;

	public IModel Model {
		set { 
			if(_model == null){
				_model = value;
			}
		}
	}

	public IView View {
		set {
			if(_view == null){
				_view = value;
			}
		}
	}

	public abstract void Execute(); // must be implemented in derived classes
} // end BaseCommand class definition
