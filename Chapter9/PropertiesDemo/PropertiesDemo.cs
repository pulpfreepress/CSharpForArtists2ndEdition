/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PropertiesDemo {
 
  /**** Constants and Fields *****/
  private const String MESSAGE = "Hello Stranger";
  private static int field_1 = 1;
         private int field_2 = 2;
  
  /***** Properties ******/
  public String ClassName {
    get { return this.GetType().ToString(); }
  }
  
  public String Message {
    get { return MESSAGE; }
  }
  
  public static int ObjectCount {
    get { return field_1; }
    set { field_1 = value; }
  }
  
  public int SomeProperty {
    get { return field_2; }
    set { field_2 = value; }
  }
  
  static void Main(){
    PropertiesDemo pd = new PropertiesDemo();
    Console.WriteLine(pd.ClassName);
    Console.WriteLine(pd.Message);
    Console.WriteLine(ObjectCount);
    ObjectCount++;
    Console.WriteLine(ObjectCount);
    Console.WriteLine(pd.SomeProperty++);
    Console.WriteLine(pd.SomeProperty);
  }
}