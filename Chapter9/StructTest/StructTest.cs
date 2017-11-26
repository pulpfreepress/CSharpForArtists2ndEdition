/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;


public interface IMessage {
  String Message{
    get;
    set;
  }
  void PrintMessage();
}

public struct StrucTest : IMessage {

  int _i;
  int _j;
  String _message;
  
  public int I {
    get { return _i; }
    set { _i = value; }
  }
  
  public int J {
    get { return _j; }
    set { _j = value; }
  }
  
  
  public String Message {
    get{ return _message; }
    set{ _message = value; }
  }
  
  public void PrintMessage(){
    Console.WriteLine("{0}  {1}, {2}", _message, _i, _j);
  }
  
  
  public static void Main(){
    StrucTest st = new StrucTest();
    st.I = 1;
    st.J = 2;
    st.Message = "Hello World";
    st.PrintMessage();
    Object o = st;
    ((IMessage)o).Message = "Different Message";
    ((IMessage)o).PrintMessage();
    st.PrintMessage();
    
    
  }

}