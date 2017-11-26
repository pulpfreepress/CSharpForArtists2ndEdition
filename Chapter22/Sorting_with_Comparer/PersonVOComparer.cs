/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System.Collections.Generic;

public class PersonVOComparer : Comparer<PersonVO> {

	/***********************************
		Return -1 if p1 < p2 or p1 == null
		Return  0 if p1 == p2
		Return +1 if p1 > p2 or p2 == null
	************************************/
	public override int Compare(PersonVO p1, PersonVO p2){
		if(p1 == null) return -1;
		if(p2 == null) return  1;
		return p1.LastName.CompareTo(p2.LastName);
	}
}