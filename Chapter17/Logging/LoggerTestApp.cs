/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class LoggerTestApp {
	static void Main(string[] args) {
	Logger logger = new Logger();
	LogEntry entry1 = new LogEntry(DateTime.Now, "Reactor Coolant", 3, 
																"Main coolant pump speed limited");
	LogEntry entry2 = new LogEntry(DateTime.Now, "Main Engine", 3, 
																"Main condenser loss of vacuum");
	LogEntry entry3 = new LogEntry(DateTime.Now, "Reactor Coolant", 3, 
																"Main coolant pump speed limited");
	LogEntry entry4 = new LogEntry(DateTime.Now, "Reactor", 1, 
																"Loss of control rod control");
	LogEntry entry5 = new LogEntry(DateTime.Now, "Reactor Coolant", 3, 
																"Main coolant pump speed limited");
      
	logger.Append(entry1);
	logger.Append(entry2);
	logger.Append(entry3);
	logger.Append(entry4);
	logger.Append(entry5);
	Console.Write(logger.GetLogRecords());
	logger.Dispose();
	} // end Main()
} // end class definition