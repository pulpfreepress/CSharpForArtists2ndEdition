/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

namespace EngineSimulation {

	public class Part {
		private PartStatus _partStatus;
		private String _partName;

		public PartStatus Status {
			get { return _partStatus; }
			set { _partStatus = value; }
		}
        
		public String PartName {
			get { return _partName; }
			set { _partName = value; }
		}
				
		public bool IsWorking {
			get { return (Status == PartStatus.WORKING); }
    }

		public Part(PartStatus status, String partName) {
			_partName = partName; 
			_partStatus = status;
			Console.WriteLine("Part Created...");
		}
	} // end class definition
} // end namespace
