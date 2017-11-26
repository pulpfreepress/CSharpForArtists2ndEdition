/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

public class SimpleConnection {
	public static void Main(){
		Console.WriteLine("Simple Connection!");
		DatabaseProviderFactory factory = new DatabaseProviderFactory();
		Database database = factory.Create("TestDatabase");
		Console.WriteLine("Database created!");
		DbCommand command = 
			database.GetSqlStringCommand("select table_name from information_schema.tables");
		IDataReader reader = database.ExecuteReader(command);
		while(reader.Read()){
			Console.WriteLine(reader.GetString(0));
		}
		if(reader != null) reader.Close(); 
	} // end Main()
} // end class definition
