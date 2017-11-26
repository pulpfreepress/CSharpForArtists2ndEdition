/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Threading;

public class MultiThreadedVacation {
  
  private bool hungry;
  private bool thirsty;
  
  public MultiThreadedVacation(){
    hungry = true;
	thirsty = true;
  }
  
  public void FetchDrink(){
    int steps_to_the_bar = 1000;
	for(int i=0; i<steps_to_the_bar*2; i++){
	 if((i%100) == 0){
	   Console.WriteLine();
	   Console.Write("Fetching Drinks");
	 }else{
	   Console.Write(".");
	 }
	}
	Console.WriteLine();
	thirsty = false;
  }
  
  public void FetchFood(){
    int steps_to_the_grill = 1000;
	for(int i=0; i<steps_to_the_grill*2; i++){
	 if((i%100)==0){
	   Console.WriteLine();
	   Console.Write("Fetching Food");
	 }else{
	   Console.Write(".");
	 }
	}
	Console.WriteLine();
	hungry = false;
  }
  
  public static void Main(){
    MultiThreadedVacation mtv = new MultiThreadedVacation();
	Thread drinkFetcher = new Thread(mtv.FetchDrink);
	Thread foodFetcher = new Thread(mtv.FetchFood);
    Console.WriteLine("Relaxing!");
	drinkFetcher.Start();
	foodFetcher.Start();
    while(mtv.hungry && mtv.thirsty){
	  Console.Write("Relaxing! ");
	}
  }
}