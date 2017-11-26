/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ParamArrayTest {
  
  public void ParamMethod(params String[] args){
     Console.WriteLine("Method called with {0} arguments.", args.Length);
     for(int i = 0; i<args.Length; i++){
       Console.WriteLine("Argument " + i + " is " + args[i]);
     }
  }

  public static void Main(){
     ParamArrayTest pt = new ParamArrayTest();
     pt.ParamMethod();
     pt.ParamMethod("one");
     pt.ParamMethod("one", "two");
     pt.ParamMethod(new String[] {"one", "two", "three"});
  }
}