/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class CommandProperties : XmlProperties {

	// class constants - default key strings
	public const String PROPERTIES_FILE          			= "PROPERTIES_FILE";
	public const String NEXTMESSAGE_COMMAND						= "NextMessage";
	
 
	// class constants - default value strings
	private const String PROPERTIES_FILE_VALUE	 = "CommandProperties.XML";
	private const String NEXTMESSAGE_COMMAND_CLASSNAME	= "NextMessageCommand";
	
 
	// private fields
	private static CommandProperties _props;

	//private constructor
	private CommandProperties():this(PROPERTIES_FILE_VALUE) { }

	private CommandProperties(String filename):base(filename){
		SetProperty(PROPERTIES_FILE, PROPERTIES_FILE_VALUE);
		SetProperty(NEXTMESSAGE_COMMAND, NEXTMESSAGE_COMMAND_CLASSNAME);
		base.Store();
	}

	// default GetInstance() method
	public static CommandProperties GetInstance(){
		return CommandProperties.GetInstance(PROPERTIES_FILE_VALUE);
	}

	// Overloaded GetInstance() method
	public static CommandProperties GetInstance(String filename){
		if(_props == null){
			_props = new CommandProperties();
		}
	 return _props;
	}
} // end class definition
