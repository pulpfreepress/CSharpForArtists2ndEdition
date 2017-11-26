/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class FleetTestApp {	public static void Main(){		Vessel v1 = new Submarine(new NukePlant("Preasureized Water Mk 85"), 
															new Torpedo("MK 50"), "USS Falls Church");		v1.LightoffPlant();		v1.TrainWeapon();		v1.FireWeapon();		v1.ShutdownPlant();	}}// end FleetTestApp class definition