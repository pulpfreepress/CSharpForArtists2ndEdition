/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MainApp {
  public static void Main(){
    MyType mt = new MyType();
    MyType mt2 = new MyType(6);
		Console.WriteLine("mt  = " + mt);
		Console.WriteLine("mt2 = " + mt2);
    Console.WriteLine("mt == mt should be True : " + (mt == mt));
    Console.WriteLine("mt != mt should be False : " + (mt != mt));
    Console.WriteLine("mt != mt2 should be True : " + (mt != mt2));
    Console.WriteLine("mt == mt2 should be False : " + (mt == mt2));
    Console.WriteLine("mt > mt2 should be False : " + (mt > mt2)); 
    Console.WriteLine("mt >= mt2 should be False : " + (mt >= mt2)); 
    Console.WriteLine("mt < mt2 should be True : " + (mt < mt2)); 
    Console.WriteLine("mt <= mt2 should be True : " + (mt <= mt2));     
  }
}