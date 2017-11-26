/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Windows.Forms;

public class Controller {
	private readonly Model _model;
	private readonly View _view;

	public Controller(){
		_model = new Model();
		_view = new View(this);
		_view.SetMessage(_model.GetMessage());
	}

	public void ClickHandler(Object sender, EventArgs e){
		_view.SetMessage(_model.GetMessage());
	}

  public static void Main(){
	  Application.Run((new Controller())._view);
	}
} // end Controller class definition