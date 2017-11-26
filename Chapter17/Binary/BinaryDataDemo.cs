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

public class BinaryDataDemo {
	public static void Main(){
		int record_count = 5;
		int record_number = 0;
		int int_val = 125;
		double double_val = -4567.00;
		String string_val = "I love C#!";
		bool bool_val = true;

		/**********************************************************
		Create the file and write the data with a BinaryWriter
		**********************************************************/
		BinaryWriter writer = null;
		try{
			writer = new BinaryWriter(File.Open("binaryfile.dat", FileMode.Create));
			writer.Write(record_count);
			for(int i=0; i<record_count; i++){
				writer.Write(++record_number);
				writer.Write(int_val);
				writer.Write(double_val);
				writer.Write(string_val);
				writer.Write(bool_val);
			}
		}catch(Exception e){
			Console.WriteLine(e);
		}finally{
			if(writer != null) {
				writer.Close();
			}
		}

		/********************************************************
		Open the file and read the data with a BinaryReader
		********************************************************/    
		BinaryReader reader = null;
		record_count = 0; // reset record count
		try{
			reader = new BinaryReader(File.Open("binaryfile.dat", FileMode.Open));
			record_count = reader.ReadInt32();
			for(int i=0; i<record_count; i++){
				Console.WriteLine("Record #:     " + reader.ReadInt32());
				Console.WriteLine("Int value:    " + reader.ReadInt32());
				Console.WriteLine("Double value: " + reader.ReadDouble());
				Console.WriteLine("String value: " + reader.ReadString());
				Console.WriteLine("Bool value:   " + reader.ReadBoolean());
				Console.WriteLine("-------------------------------------------------------");
			}
		}catch(Exception e){
			Console.WriteLine(e);
		}finally{
			if(reader != null) {
				reader.Close();
			}
		}
	} // end Main()
} // end class