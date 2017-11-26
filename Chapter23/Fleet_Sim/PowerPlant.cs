/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public abstract class PowerPlant {	private String _model = null;
		public PowerPlant(String model){		_model = model;
		Console.WriteLine("PowerPlant object created!");	}
		public abstract void LightoffPlant();	public abstract void ShutdownPlant();	public override String ToString(){ return "Power plant model: " + _model; }}