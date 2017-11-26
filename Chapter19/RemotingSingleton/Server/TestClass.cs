/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class TestClass : MarshalByRefObject{

  private string _text;

  public string Text {
    get { return _text; }
    set { 
      _text = value; 
      Console.WriteLine("Property changed --> " + _text);
      }
  }
  
  public TestClass():this("This is the default text message!"){}

  public TestClass(string s){
    _text = s;
  }
  
}