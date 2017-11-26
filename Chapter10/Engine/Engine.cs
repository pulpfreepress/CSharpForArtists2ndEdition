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

	public class Engine {
		private Compressor _itsCompressor = null;
    private FuelPump _itsFuelPump = null;
    private OilPump _itsOilPump = null;
    private OxygenSensor _itsOxygenSensor = null;
    private TemperatureSensor _itsTemperatureSensor = null;
    private int _itsEngineNumber = 0;
    private bool _isRunning = false;
    private PartStatus _itsStatus;

		public int EngineNumber {
		  get { return _itsEngineNumber; }
		}
		
    public Engine(int engine_number) {
			_itsEngineNumber = engine_number;
      _itsCompressor = new Compressor(PartStatus.WORKING, _itsEngineNumber);
      _itsFuelPump = new FuelPump(PartStatus.WORKING, _itsEngineNumber);
      _itsOilPump = new OilPump(PartStatus.WORKING, _itsEngineNumber);
      _itsOxygenSensor = new OxygenSensor(PartStatus.WORKING, _itsEngineNumber);
      _itsTemperatureSensor = new TemperatureSensor(PartStatus.WORKING, _itsEngineNumber);
      _itsStatus = PartStatus.WORKING;
      Console.WriteLine("Engine #" + _itsEngineNumber + " created!");
    }

    public void SetCompressorStatus(PartStatus status) {
			_itsCompressor.Status = status;
      CheckEngineStatus();
    }

    public void SetFuelPumpStatus(PartStatus status) {
      _itsFuelPump.Status = status;
      CheckEngineStatus();
    }

    public void SetOilPumpStatus(PartStatus status) {
			_itsOilPump.Status = status;
      CheckEngineStatus();
    }

    public void SetOxygenSensorStatus(PartStatus status) {
      _itsOxygenSensor.Status = status;
      CheckEngineStatus();
    }

    public void SetTemperatureSensorStatus(PartStatus status) {
      _itsTemperatureSensor.Status = status;
      CheckEngineStatus();
    }

    public bool CheckEngineStatus() {
      if (_itsCompressor.IsWorking && _itsFuelPump.IsWorking &&
					_itsOilPump.IsWorking && _itsOxygenSensor.IsWorking &&
					_itsTemperatureSensor.IsWorking) {
        _itsStatus = PartStatus.WORKING;
        Console.WriteLine("All engine #" + _itsEngineNumber + " components working properly.");
      } else {
					_itsStatus = PartStatus.NOT_WORKING;
          Console.WriteLine("Engine #" + _itsEngineNumber + " malfunction.");
          if (_isRunning) {
						Console.WriteLine("Engine #" + _itsEngineNumber + " shutting down!");
            StopEngine();
          }
        }
      return (_itsStatus == PartStatus.WORKING);
    }

    public void StartEngine() {
      if (!_isRunning) {
        if (CheckEngineStatus()) {
          _isRunning = true;
          Console.WriteLine("Engine #" + _itsEngineNumber + " is running!");
        } else {
            Console.WriteLine("There is a problem with an engine #" + _itsEngineNumber 
                              + " component. Engine cannot start.");
          }
      } else {
          Console.WriteLine("Engine #" + _itsEngineNumber + " is already running!");
        }
    }

    public void StopEngine() {
      _isRunning = false;
      Console.WriteLine("Engine #" + _itsEngineNumber + " has been stopped!");
    }
  } // end class definition
} // end namespace
