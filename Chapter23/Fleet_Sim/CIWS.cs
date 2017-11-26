/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class CIWS : Weapon {	public CIWS(String model):base(model){		Console.WriteLine("CIWS object created!");	}
		public override void TrainWeapon(){		Console.WriteLine("CIWS is locked on target!");	}	public override void FireWeapon(){		Console.WriteLine("The CIWS roars to life and fires a zillion bullets at the target!");	}}