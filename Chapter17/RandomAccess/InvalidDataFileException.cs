/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class InvalidDataFileException : Exception {

	public InvalidDataFileException() : base("Invalid Data File Exception") { }

	public InvalidDataFileException(string message) : base(message) { }

	public InvalidDataFileException(string message, Exception inner_exception) : 
																	base(message, inner_exception) { }
}