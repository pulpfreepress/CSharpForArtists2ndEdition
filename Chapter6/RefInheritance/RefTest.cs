/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class RefTest {

  private int _value;
  
  public int Value {
     get{
       return _value;
     }
     
     set{
       _value = value;
     }
  }
  
  public override String ToString(){
    return _value.ToString();
  }


  public static void Main(){
     RefTest rt1 = new RefTest();
     RefTest rt2 = new RefTest();
     rt1.Value = 1;
     rt2.Value = 2;
     Console.WriteLine("rt1.Value = " + rt1.ToString());
     Console.WriteLine("rt2.Value = " + rt2.ToString());
     
     rt1 = rt2;
     rt1.Value = 3;
     
     Console.WriteLine("rt1.Value = " + rt1.ToString());
     Console.WriteLine("rt2.Value = " + rt2.ToString());
  }

}