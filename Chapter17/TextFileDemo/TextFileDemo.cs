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

public class TextFileDemo {
	public static void Main(){
		/***********************************************
		Create an array of Dogs and populate
		***********************************************/
		Dog[] dog_array = new Dog[3];

		dog_array[0] = new Dog("Schmoogle", new DateTime(2007, 07, 08));
		dog_array[1] = new Dog("Dippy", new DateTime(2007, 08, 10));
		dog_array[2] = new Dog("Hercules", new DateTime(2009, 05, 01));
   
		/**********************************************
		Iterate over the dog_array and print values
		**********************************************/
		Console.WriteLine("-----Original Dog Array Contents---------------------");
		foreach(Dog d in dog_array){
			Console.WriteLine(d);
		}

		/********************************************
		Save data to text file
		********************************************/
		TextWriter writer = null;
		try{
			writer = new StreamWriter("dogfile.txt");
			foreach(Dog d in dog_array){
				writer.WriteLine(d.Name + "," + d.Birthday.Year + "-" + 
													d.Birthday.Month + "-" + d.Birthday.Day);       
			}
			writer.Flush();
			}catch(Exception e){
				Console.WriteLine(e);
			}finally{
				if(writer != null) {
					writer.Close();
				}
		}


		/**********************************************
		Read data from text file and create objects...
		**********************************************/
		TextReader reader = null;
		Dog[] another_dog_array = new Dog[3];
		try{
			reader = new StreamReader("dogfile.txt");
			String s = String.Empty;
			int count = 0;
			while((s = reader.ReadLine()) != null){
				String[] line = s.Split(',');
				String name = line[0];
				String[] dob = line[1].Split('-');
				another_dog_array[count++] = new Dog(name, new DateTime(Int32.Parse(dob[0]), 
																							Int32.Parse(dob[1]), Int32.Parse(dob[2])));
			}
		}catch(Exception e){
			Console.WriteLine(e);
		}finally{
			if(reader != null) {
				reader.Close();
			}
		}

		Console.WriteLine("-----------After writing to and reading from text file------------");
		foreach(Dog d in another_dog_array){
			Console.WriteLine(d);
		}
  } // end Main()
} // end class