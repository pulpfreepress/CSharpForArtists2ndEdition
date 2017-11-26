/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections;

public class PersonArrayList : ArrayList {
	
	public new Person this[int index]{
		get { return (Person) base[index];}
		set { base[index] =  value; }
	}
	
	public override int Add(object o){
		if(o is Person) {
		  return base.Add(o);
		}else{
		  throw new ArgumentException("You can only pass Person objects!");
		 }
	}
}