/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;public class GasTurbinePlant : PowerPlant {
	public GasTurbinePlant(String model):base(model) {		Console.WriteLine("GasTurbinePlant object created!");	}	public override void LightoffPlant(){		Console.WriteLine("Gas Turbine is running and ready to go!");	}	public override void ShutdownPlant(){		Console.WriteLine("Gas Turbine is secure!");	}}