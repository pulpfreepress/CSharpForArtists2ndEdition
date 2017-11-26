/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class LogicalOperatorEnumTest {
  public enum EYE_COLOR {BLACK, BROWN, HAZEL, BLUE, GREY};
  
  static void Main(){
    
    Console.WriteLine(EYE_COLOR.BLACK & EYE_COLOR.BROWN);
    Console.WriteLine(EYE_COLOR.BROWN & EYE_COLOR.BROWN);
    Console.WriteLine(EYE_COLOR.BLACK & EYE_COLOR.BLUE);
    Console.WriteLine(EYE_COLOR.BLACK | EYE_COLOR.BROWN);
    Console.WriteLine(EYE_COLOR.BROWN | EYE_COLOR.HAZEL);
    Console.WriteLine(EYE_COLOR.BLACK | EYE_COLOR.BLUE);
    Console.WriteLine(EYE_COLOR.BLACK ^ EYE_COLOR.BROWN);
    Console.WriteLine(EYE_COLOR.BROWN ^ EYE_COLOR.BROWN);
    Console.WriteLine(EYE_COLOR.BLACK ^ EYE_COLOR.BLUE);
  }
}