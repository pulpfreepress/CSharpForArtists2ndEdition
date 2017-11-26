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
using System.Configuration;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EmployeeTraining.DAO {
	public class BaseDAO {
		private static Database _database;

		protected Database DataBase {
			get {
				if(_database == null){
					try {
						DatabaseProviderFactory factory = new DatabaseProviderFactory();
						_database = factory.Create("EmployeeTrainingDatabase");
					} catch(ConfigurationException ce){
							Console.WriteLine(ce);
					}
				}
				return _database;
			}
		}

		protected void CloseReader(IDataReader reader){
			if(reader != null){
				try{
					reader.Close();
				} catch(Exception e){
						Console.WriteLine(e);
				}
			}
		}

	} // end BaseDAO class definition
} // end namespace