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
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class MainApp {
	public static void Main(String[] args){
		FileStream fs = null;
		BinaryFormatter bf = null;
		List<PersonVO> people_list = null;
		PersonVO p1 = null;

		if(args.Length > 0){
			switch(args[0]){
				case "create": 
							people_list = new List<PersonVO>();
							p1 = new PersonVO("Rick", "Warren", "Miller", PersonVO.Sex.MALE, 
																new DateTime(1985,7,8));
							people_list.Add(p1);
							fs = new FileStream("people.dat", FileMode.Create);
							bf = new BinaryFormatter();
							bf.Serialize(fs, people_list);
							fs.Close();
							break;

				case "append":
							fs = new FileStream("people.dat", FileMode.Open);
							bf = new BinaryFormatter();
							people_list = (List<PersonVO>) bf.Deserialize(fs);
							fs.Close();
							p1 = new PersonVO("Rick", "Warren", "Miller", PersonVO.Sex.MALE, 
																new DateTime(1985,7,8));
							people_list.Add(p1);
							fs = new FileStream("people.dat", FileMode.Create);
							bf = new BinaryFormatter();
							bf.Serialize(fs, people_list);
							fs.Close();
							break;

				case "read":
							fs = new FileStream("people.dat", FileMode.Open);
							bf = new BinaryFormatter();
							people_list = (List<PersonVO>) bf.Deserialize(fs);
							foreach(PersonVO p in people_list){
								Console.WriteLine(p);
							}
							fs.Close();
							break;

				default: break;
			} // end switch
		} // end if
	} // end Main
} // end class definition