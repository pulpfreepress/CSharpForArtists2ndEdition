/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class XmlProperties {

	// private fields
	private readonly Dictionary<string, string> _properties;
	private string _filename;

	// constants
	protected const string DEFAULT_PROPERTIES_FILENAME = "properties.xml";

	// protected constructors
	protected XmlProperties():this(DEFAULT_PROPERTIES_FILENAME){ }
 
	protected XmlProperties(string filename){
		if(string.IsNullOrEmpty(filename)){
			_filename = DEFAULT_PROPERTIES_FILENAME;
		} else {
				_filename = filename;
			}
		_properties = new Dictionary<string, string>();
	}

	/*************************************************************
	Converts _properties dictionary into List<PropertyEntry> object
	and serializes it to an XML file.
	************************************************************/
	public void Store(string filename){
		TextWriter writer = null;
		try {
			writer = new StreamWriter(filename);
			List<PropertyEntry> entry_list = new List<PropertyEntry>();
			foreach(KeyValuePair<string, string> entry in _properties){
				PropertyEntry pe;
				pe.PropertyName = entry.Key;
				pe.Value = entry.Value;
				entry_list.Add(pe);
			}
		
			XmlSerializer serializer = new XmlSerializer(typeof(List<PropertyEntry>));
			serializer.Serialize(writer, entry_list);
		} catch(IOException ioe){
				Console.WriteLine(ioe);
		} catch(Exception ex){
				Console.WriteLine(ex);
		} finally {
				if(writer != null) writer.Close();
		}
		_filename = filename; 
	}

	/**************************************************************
	Stores property entries to default file
	****************************************************************/
	public void Store(){
		Store(_filename);
	}

	/**************************************************************
	Reads the XML properties file and populates the _properties 
	dictionary. Throws an IOException if the specified filename does
	not exist.
	**************************************************************/
	public void Read(string filename ){
		if(!File.Exists(filename)){
			throw new IOException("Requested file does not exist!");
		}
		FileStream fs = null;
		try {
			fs = new FileStream(filename, FileMode.Open);
			XmlSerializer serializer = new XmlSerializer(typeof(List<PropertyEntry>));
			List<PropertyEntry> entry_list = (List<PropertyEntry>)serializer.Deserialize(fs);
			//clear the dictionary entries
			_properties.Clear();
			foreach(PropertyEntry entry in entry_list){
				_properties[entry.PropertyName] = entry.Value;
			}
		} catch(IOException ioe){
				Console.WriteLine(ioe);
		} catch(Exception ex){
				Console.WriteLine(ex);
		} finally{
				if(fs != null){
				fs.Close();
				}
		}
	}

	/****************************************************************
	Reads the default XML properties file. 
	*****************************************************************/
	public void Read(){
		this.Read(_filename);
	}

	/***********************************************************
	Sets a property with given key and value
	***********************************************************/
	public void SetProperty(string key, string value){
		_properties[key] = value; // overrites old value if it already exists
	}

	/**********************************************************
	Gets the value of the specified property key. Will throw an exception
	if the property does not exist.
	**********************************************************/
	public string GetProperty(string key){
		return _properties[key];	
	}

	/***********************************************************
	Clears the dictionary containing the property keys and values
	***********************************************************/
	public void Clear() {
		_properties.Clear();
	}
} // end class definition
