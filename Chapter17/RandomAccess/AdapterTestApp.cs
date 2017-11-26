/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class AdapterTesterApp {
	public static void Main(){
		try{
			DataFileAdapter adapter = new DataFileAdapter("books.dat");
			string[] rec_1 = {"C++ For Artists", "Rick Miller", "0001", "1-932504-02-8", 
													"$59.95", "80"};
			string[] rec_2 = {"Java For Artists", "Rick Miller", "0002", "1-932504-04-X", 
													"$69.95", "100"};
			string[] rec_3 = { "C# For Artists", "Rick Miller", "0003", "1-932504-07-9", 
													"$76.00", "567" };
			string[] rec_4 = { "White Saturn", "Rick Miller", "0004", "1-932504-08-7", 
													"$45.00", "234" };
			string[] rec_5 = { "C# Collections: A Detailed Presentation", "Rick Miller", "0005", "9781932504095", 
													"$50.00", "100" };
			string[] rec_6 = { "ASP.NET: An Integrated Approach", "Rick Miller", "0006", "9781932504101", 
													"$80.00", "50" };

			string[] search_string = {"Java", " "};
     
			string[] temp_string = null;

			adapter.CreateRecord(rec_1);
			adapter.CreateRecord(rec_2);
			adapter.CreateRecord(rec_3);
			adapter.CreateRecord(rec_4);
			adapter.CreateRecord(rec_5);
			adapter.CreateRecord(rec_6);
			adapter.CreateRecord(rec_1);
			adapter.CreateRecord(rec_2);
			adapter.CreateRecord(rec_3);
			adapter.CreateRecord(rec_4);
			adapter.CreateRecord(rec_5);
			adapter.CreateRecord(rec_6);
			adapter.CreateRecord(rec_1);
			adapter.CreateRecord(rec_2);
			adapter.CreateRecord(rec_3);
			adapter.CreateRecord(rec_4);
			adapter.CreateRecord(rec_5);
			adapter.CreateRecord(rec_6);


			long lock_token = adapter.LockRecord(2);

			adapter.UpdateRecord(2, rec_2, lock_token);
			adapter.UnlockRecord(2, lock_token);

			lock_token = adapter.LockRecord(1);
			adapter.DeleteRecord(1, lock_token);
			adapter.UnlockRecord(1, lock_token);
			
			lock_token = adapter.LockRecord(4);
			adapter.UpdateRecord(4, rec_4, lock_token);
			adapter.UnlockRecord(4, lock_token);

			long[] search_hits = adapter.SearchRecords(search_string);

			Console.WriteLine(adapter.ReadHeader());

			for(int i=0; i<search_hits.Length; i++){
				try{
					temp_string = adapter.ReadRecord(search_hits[i]);
					for(int j = 0; j<temp_string.Length; j++){
						Console.Write(temp_string[j] + " ");
					}
					Console.WriteLine();
				} catch(RecordNotFoundException){ }
			}
			
			Console.WriteLine("----------------------------------------");
			for (int i = 0; i < adapter.RecordCount; i++) {
				try {
					temp_string = adapter.ReadRecord(i);
					for (int j = 0; j < temp_string.Length; j++) {
						Console.Write(temp_string[j] + " ");
					}
					Console.WriteLine();
				}	catch (RecordNotFoundException) {  }
			}
		}	catch (Exception e) { Console.WriteLine(e.ToString()); }
   } // end Main()
} // end class