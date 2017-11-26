/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class WaterLevelEventArgs : EventArgs {

  private int _waterLevel;
  
  public WaterLevelEventArgs(int waterLevel){
		_waterLevel = waterLevel;
	}
  
  public int WaterLevel {
		get { return _waterLevel; }
		set { _waterLevel = value; }
	}
}