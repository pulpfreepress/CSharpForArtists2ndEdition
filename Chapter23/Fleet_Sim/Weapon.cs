/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public abstract class Weapon {	private String _model = null;	public Weapon(String model){		_model = model;		Console.WriteLine("Weapon object created!");	}
	public abstract void TrainWeapon();	public abstract void FireWeapon();	
	public override String ToString(){ return "Weapon model: " + _model; }}