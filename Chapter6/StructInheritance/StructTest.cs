/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public struct StructTest {

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
     StructTest st1 = new StructTest();
     StructTest st2 = new StructTest();
     st1.Value = 1;
     st2.Value = 2;
     Console.WriteLine("st1.Value = " + st1.ToString());
     Console.WriteLine("st2.Value = " + st2.ToString());
     
     st1 = st2;
     st1.Value = 3;
     
     Console.WriteLine("st1.Value = " + st1.ToString());
     Console.WriteLine("st2.Value = " + st2.ToString());
  }

}