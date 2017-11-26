/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public interface LegacyDataFileInterface {

	/// <summary>
	/// Read the record indicated by the rec_no and return a string array
	/// where each element contains a field value.
	/// </summary>
	/// <param name="rec_no"></param>
	/// <returns>A string array populated with the contents of each field</returns>
	/// <exception cref="RecordNotFoundException"></exception>
	string[] ReadRecord(long rec_no);

	/// <summary>
	/// Update a record's fields. The record must be locked with the lockRecord()
	/// method and the lock_token must be valid. The value for field n appears in
	/// element record[n].
	/// </summary>
	/// <param name="rec_no"></param>
	/// <param name="record"></param>
	/// <param name="lock_token"></param>
	/// <exception cref="RecordNotFoundException"></exception>
	/// <exception cref="SecurityException"></exception>
	void UpdateRecord(long rec_no, string[] record, long lock_token);


	/// <summary>
	/// Marks a record for deletion by setting the deleted field to 1. The lock_token
	/// must be valid otherwise a SecurityException is thrown.
	/// </summary>
	/// <param name="rec_no"></param>
	/// <param name="lock_token"></param>
	/// <exception cref="RecordNotFoundException" ></exception>
	/// <exception cref="SecurityException"></exception>
	void DeleteRecord(long rec_no, long lock_token); 

	/// <summary>
	/// Creates a new datafile record and returns the record number.
	/// </summary>
	/// <param name="record"></param>
	/// <returns>Record number of newly created record</returns>
	/// <exception cref="FailedRecordCreationException"></exception>
	long CreateRecord(string[] record);

  
	/// <summary>
	/// Locks a record for updates and deletes and returns an integer
	/// representing a lock token.
	/// </summary>
	/// <param name="rec_no"></param>
	/// <returns>Lock record token</returns>
	/// <exception cref="RecordNotFoundException"></exception>
	long LockRecord(long rec_no);


	/// <summary>
	/// Unlocks a previously locked record. The lock_token must be valid or a
	/// SecurityException is thrown.
	/// </summary>
	/// <param name="rec_no"></param>
	/// <param name="lock_token"></param>
	/// <exception cref="SecurityException"></exception>
	void UnlockRecord(long rec_no, long lock_token);


	/// <summary>
	///  Searches the records in the datafile for records that match the String
	/// values of search_criteria. search_criteria[n] contains the search value
	/// applied against field n.
	/// </summary>
	/// <param name="search_criteria"></param>
	/// <returns>An array of longs containing the matched record numbers</returns>
	long[] SearchRecords(string[] search_criteria);

}//end interface definition