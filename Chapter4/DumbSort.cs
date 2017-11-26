/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class DumbSort{
	public static void Main(String[] args){
		int[] a = {11,10,9,8,7,6,5,4,3,2,1,0};

		int innerloop = 0;
		int outerloop = 0;
		int swaps = 0;

		for(int i=0; i<12; i++){
			outerloop++;
			for(int j=1; j<12; j++){
				innerloop++;
				if(a[j-1] > a[j]){
					int temp = a[j-1];
					a[j-1] = a[j];
					a[j] = temp;
					swaps++;
				}
			}
		}

		for(int i=0; i<12; i++){
			Console.Write(a[i] + " ");
		}

		Console.WriteLine();
		Console.WriteLine("Outer loop executed " + outerloop + " times.");
		Console.WriteLine("Inner loop executed " + innerloop + " times.");
		Console.WriteLine(swaps + " swaps completed.");
	}
}