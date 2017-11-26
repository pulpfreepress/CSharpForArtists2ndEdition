/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.IO;

public class DirectoryClassDemo {
	public static void Main(){
		Console.WriteLine("The full path name of the current directory is...");
		Console.WriteLine("\t" + Directory.GetCurrentDirectory());
		Console.WriteLine("The current directory has the following files...");
		string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
		foreach(string s in files){
			FileInfo file = new FileInfo(s);
			Console.WriteLine("\t" + file.Name);
		}
		Console.WriteLine("The computer has the following attached drives...");
		string[] drives = Directory.GetLogicalDrives();
		foreach(string s in drives){
			Console.WriteLine("\t" + s);
		}
	} // end Main()
} // end class