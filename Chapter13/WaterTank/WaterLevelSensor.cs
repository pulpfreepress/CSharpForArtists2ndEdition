/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class WaterLevelSensor {
	
	public enum Mode { HighLevelIndicator, LowLevelIndicator };
	
	private int _setPoint;
	private int _currentLevel;
	private bool _rising;
	private Mode _mode = Mode.HighLevelIndicator;
	
	public event WaterLevelEventHandler Full;
	public event WaterLevelEventHandler Empty;
	public event WaterLevelEventHandler Fill;
	public event WaterLevelEventHandler Drain;
	
	public int SetPoint {
		get { return _setPoint; }
		set { _setPoint = value; }
	}
	
	public int CurrentLevel {
		get { return _currentLevel; }
		set { _currentLevel = value; }
	}
	
	public Mode SensorMode {
		get { return _mode; }
		set { _mode = value; }
	}
	
	public WaterLevelSensor(int setPoint, int currentLevel){
		_setPoint = setPoint;
		_currentLevel = currentLevel;
	}
	
	public void WaterLevelChange(int amount){
		int lastLevel = _currentLevel;
		_currentLevel += amount;
		_rising = (CurrentLevel >= lastLevel);
		
		switch(_mode){
			case Mode.HighLevelIndicator : 
			     if(_rising){
		         if(_currentLevel >= _setPoint){
							 WaterLevelEventArgs args = new WaterLevelEventArgs(_currentLevel);
							 OnFull(args);
						 }else{
							 WaterLevelEventArgs args = new WaterLevelEventArgs(_currentLevel);
							 OnFill(args);
						 }
				   }
					break;
		
			case Mode.LowLevelIndicator : 
			  if(!_rising){
          if(_currentLevel <= _setPoint){
					 WaterLevelEventArgs args = new WaterLevelEventArgs(_currentLevel);
					 OnEmpty(args);
				  }else{
					  WaterLevelEventArgs args = new WaterLevelEventArgs(_currentLevel);
					  OnDrain(args);
				  } 
		    }
		    break;
		} // end switch
 }
	
	public void OnFull(WaterLevelEventArgs e){
	  if(Full != null){
			Full(e);
		}
	 }
	
	public void OnEmpty(WaterLevelEventArgs e){ 
		if(Empty != null){
		  Empty(e);
		}
	}
	
	public void OnFill(WaterLevelEventArgs e){
	  if(Fill != null){
		  Fill(e);
		}
	}
	
	public void OnDrain(WaterLevelEventArgs e){
	  if(Drain != null){
		  Drain(e);
	  }
	}
}// end WaterLevelSensor Class definition