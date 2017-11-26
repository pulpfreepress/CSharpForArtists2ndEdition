/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class ReadOnlyTest {
  public static readonly DateTime DATE_CONSTANT;
  public const DateTime DATE_CONSTANT_2;
  
  static ReadOnlyTest(){
    DATE_CONSTANT = DateTime.Now;
    
  }
  
  public static void Main(){
    ReadOnlyTest rt = new ReadOnlyTest();
    Console.WriteLine(ReadOnlyTest.DATE_CONSTANT);
  }


}