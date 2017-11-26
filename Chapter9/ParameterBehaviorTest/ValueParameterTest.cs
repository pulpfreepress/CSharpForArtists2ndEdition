/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Text;


public class ValueParameterTest {

  int int_field;
  StringBuilder object_ref_field = new StringBuilder();
  
  public void F(int int_param, StringBuilder object_ref_param){
     int_param = 2;
     Console.WriteLine("Value of int_param modified in method: " + int_param);
     object_ref_param.Append("Two");
     Console.WriteLine("The value of object_ref_param after calling Append() in method: " 
                        + object_ref_param);
     object_ref_param = new StringBuilder();
     object_ref_param.Append("Three");
     Console.WriteLine("The value of object_ref_param after calling Append() in method: " 
                        + object_ref_param); 
  }
  
  public void G(){
     int_field = 1;
     object_ref_field.Append("One");
     Console.WriteLine("The value of int_field before method call is: " + 
												int_field);
     Console.WriteLine("The value of the object_ref_field before method call is: " + 
												object_ref_field);
     Console.WriteLine("-------------------------------------------------------------------");
     F(int_field, object_ref_field);
     Console.WriteLine("-------------------------------------------------------------------");
     Console.WriteLine("The value of int_field after method call is: " + 
												int_field);
     Console.WriteLine("The value of the object_ref_field after method call is: " + 
												object_ref_field); 
  }
   

  public static void Main(){
     ValueParameterTest pt = new ValueParameterTest();
     pt.G();
     
  } // end Main
} // end class definition