/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class MyProperties : XmlProperties {

	// private fields
	private static MyProperties _props;

	//private constructor
	private MyProperties(string filename):base(filename){ }

	// default GetInstance() method
	public static MyProperties GetInstance(){
		return GetInstance(DEFAULT_PROPERTIES_FILENAME);
	}

	// Overloaded GetInstance() method
	public static MyProperties GetInstance(string filename){
		if(_props == null){
			_props = new MyProperties(filename);
		}
		return _props;
	}
} // end class definition