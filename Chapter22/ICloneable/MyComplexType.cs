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
using System.Collections.Generic;

public class MyComplexType : ICloneable {
	List<String> _stringList = null;
	String _name = String.Empty;

	public MyComplexType(String name){
		_name = name;
		_stringList = new List<String>();
		for(int i = 0; i<5; i++){	
			_stringList.Add(String.Empty);
		}
	}

	public List<String> StringList {
		get { return _stringList; }
	}

	public String Name {
		get { return _name; }
		set { _name = value; }
	}

	public Object Clone(){
		MyComplexType mct = new MyComplexType(this.Name + " Clone");
		for(int i = 0; i<this.StringList.Count; i++){	
			mct.StringList[i] = this.StringList[i];
		}
		return mct;
	}

	public Object GetMemberwiseClone(){
		return this.MemberwiseClone();
	}

	public override String ToString(){
		StringBuilder sb = new StringBuilder();
		sb.Append(Name + ": ");
		foreach(String s in StringList){
			sb.Append(s + " ");
		}
		return sb.ToString();
	}
} // end class definition