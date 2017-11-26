/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

[Serializable]
public class LogEntry {
	private string _subSystem;
	private int _severity;
	private string _text;
	private DateTime _timeStamp;

	public DateTime TimeStamp {
		get { return _timeStamp; }
		set { _timeStamp = value; }
	}
  
	public string SubSystem {
		get { return _subSystem; }
		set { _subSystem = value; }
	}

	public int Severity {
		get { return _severity; }
		set { _severity = value; }
	}

	public string Text {
		get { return _text; }
		set { _text = value; }
	}

	public LogEntry(DateTime timeStamp, string subSystem, int severity, string text){
		_timeStamp = timeStamp;
		_subSystem = subSystem;
		_severity = severity;
		_text = text;
  }
  
	public override string ToString(){
		return TimeStamp + " " + _subSystem + " " + _severity + " " + _text;
	}
} // end LogEntry class definition
