/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Pump {
	
	private int _pumpingCapacity;
	private WaterTank _itsTank;
	
	public int PumpingCapacity {
		get { return _pumpingCapacity; }
		set { _pumpingCapacity = value; }
	}
	
	
	public Pump(WaterTank tank, int pumpingCapacity){
		_pumpingCapacity = pumpingCapacity;
		_itsTank = tank;
	}
	
	public void FullTankEventHandler(WaterLevelEventArgs e){
		Console.WriteLine("FullTankEventHandler: Draining the water tank!");
		_itsTank.ChangeWaterLevel(-_pumpingCapacity);
	}
	
	public void EmptyTankEventHandler(WaterLevelEventArgs e){
		Console.Write("EmptyTankEventHandler: ");
		Console.WriteLine("Water tank has been drained! The water tank contains " + e.WaterLevel + " gallons!");
	}
	
	public void FillTankEventHandler(WaterLevelEventArgs e){
		Console.Write("FillTankEventHandler: ");
		Console.WriteLine("The water tank contains " + e.WaterLevel + " gallons!");
	}
	
	public void DrainTankEventHandler(WaterLevelEventArgs e){
		Console.Write("DrainTankEventHandler: ");
		Console.WriteLine("The water tank contains " + e.WaterLevel + " gallons!");
		_itsTank.ChangeWaterLevel(-_pumpingCapacity);
			
	}
	
}