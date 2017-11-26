/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class SingleThreadedVacation {

	private bool _hungry;
	private bool _thirsty;

	public SingleThreadedVacation(){
		_hungry = true;
		_thirsty = true;
	}

	public void FetchDrink(){
		int steps_to_the_bar = 1000;
		for(int i=0; i<steps_to_the_bar*2; i++){
			if((i%100) == 0){
				Console.WriteLine();
				Console.Write("Fetching Drinks");
			} else {
					Console.Write(".");
				}
		}
		Console.WriteLine();
		_thirsty = false;
	}
  
	public void FetchFood(){
		int steps_to_the_grill = 1000;
		for(int i=0; i<steps_to_the_grill*2; i++){
			if((i%100)==0){
				Console.WriteLine();
				Console.Write("Fetching Food");
			} else {
					Console.Write(".");
				}
		}
		Console.WriteLine();
		_hungry = false;
	}
  
	public static void Main(){
		SingleThreadedVacation stv = new SingleThreadedVacation();
		Console.WriteLine("Relaxing!");
		while(stv._hungry && stv._thirsty){
			stv.FetchDrink();
			stv.FetchFood();
			Console.WriteLine("Relaxing!");
		}
	} // end Main()
} // end class