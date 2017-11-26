/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class FiveInchGun : Weapon {	public FiveInchGun(String model):base(model){		Console.WriteLine("FiveInchGun object created!");	}	public override void TrainWeapon(){		Console.WriteLine("Five Inch Gun is locked on target!");	}	public override void FireWeapon(){		Console.WriteLine("Blam! Blam! Blam!");	}}