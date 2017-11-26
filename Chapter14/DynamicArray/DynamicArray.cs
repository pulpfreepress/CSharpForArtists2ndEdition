/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class DynamicArray {
  private object[] _objectArray = null;
  private int _nextOpenElement = 0;
  private int _growthIncrement = 10;
  private const int INITIAL_SIZE = 25;
  
  public int Count { 
		get { return _nextOpenElement; }
  }
  
  public object this[int index] {
	  get {
	    if((index >= 0) && (index < _objectArray.Length)){
			  return _objectArray[index];
      }else return null; 
	  }
	  set {  // set ignores index parameter and functions like the Add() method
	   if(_nextOpenElement < _objectArray.Length){
		        _objectArray[_nextOpenElement++] = value;
		     }else{
		 	GrowArray();
		 	_objectArray[_nextOpenElement++] = value;
     }
	  }
	}
	
  public DynamicArray(int size){
    _objectArray = new Object[size];
  }

  public DynamicArray():this(INITIAL_SIZE){ }

  public void Add(Object o){
    if(_nextOpenElement < _objectArray.Length){
       _objectArray[_nextOpenElement++] = o;
    }else{
	GrowArray();
	_objectArray[_nextOpenElement++] = o;
     }
  } // end add() method;

  private void GrowArray(){
    object[] temp_array = _objectArray;
    _objectArray = new Object[_objectArray.Length + _growthIncrement];
    for(int i=0, j=0; i<temp_array.Length; i++){
      if(temp_array[i] != null){
        _objectArray[j++] = temp_array[i];
       }
       _nextOpenElement = j;
     }
     temp_array = null;
  } // end growArray() method
} // end DynamicArray class definition
