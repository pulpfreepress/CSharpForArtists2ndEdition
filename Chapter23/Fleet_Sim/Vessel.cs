/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public abstract class Vessel {
	private PowerPlant _plant;
	private Weapon 		 _weapon;
	private String 		 _name;
	// protected properties	protected Weapon Weapon { 		get { return _weapon; }	}
	protected PowerPlant Plant { 		get { return _plant; }	}
	public Vessel(PowerPlant plant, Weapon weapon, String name){
		_weapon = weapon;
		_plant = plant;
		_name = name;
		Console.WriteLine("The vessel " + _name + " created!");
	}

	/* ********************************************************
		Public Abstract Methods - must be implemented in
		derived classes.
	*********************************************************/
	public abstract void LightoffPlant();
	public abstract void ShutdownPlant();
	public abstract void TrainWeapon();
	public abstract void FireWeapon();

	/* ********************************************************
		ToString() Method - may be overridden in subclasses.
	*********************************************************/
	public override String ToString(){
		return "Vessel name: " + _name + " " + _plant + " " + _weapon;
	}
}// end Vessel class definition
