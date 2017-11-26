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
		private int _engineNumber;
		private bool _isRunning;
		private EnginePart[] _itsParts;
		
		public int EngineNumber {
			get { return _engineNumber; }
		}
		
		public bool IsRunning {
			get { return _isRunning; }
		}
		
		public Engine(int engineNumber){
			_engineNumber = engineNumber;
			_isRunning = false;
			_itsParts = new EnginePart[6];
			_itsParts[0] = new Compressor(PartStatus.WORKING, EngineNumber);
			_itsParts[1] = new FuelPump(PartStatus.WORKING, _engineNumber);
			_itsParts[2] = new OilPump(PartStatus.WORKING, _engineNumber);
			_itsParts[3] = new WaterPump(PartStatus.WORKING, _engineNumber);
			_itsParts[4] = new OxygenSensor(PartStatus.WORKING, _engineNumber);
			_itsParts[5] = new TemperatureSensor(PartStatus.WORKING, _engineNumber);
			Console.WriteLine("Engine number {0} created", _engineNumber);
		}
		
		
		private bool CheckEngine(){
			Console.WriteLine("Checking engine number {0}...", _engineNumber);
			bool is_working = false;
			
			for(int i=0; i<_itsParts.Length; i++){
				is_working = _itsParts[i].IsWorking;
				if(!is_working){
					Console.WriteLine(_itsParts[i].PartIdentifier + " " + _itsParts[i].Status);
					break;
				}
			}
			   
			if(is_working){
				Console.WriteLine("Engine number {0} working properly!", _engineNumber);
			}else{
				Console.WriteLine("Engine number {0} malfunction!", _engineNumber);
				StopEngine();
			}
			return is_working;
		}
		
		public void StartEngine(){
			if(!_isRunning){
				_isRunning = CheckEngine();
			if(!_isRunning){
					Console.WriteLine("Engine number {0} failed to start!", _engineNumber);
				}else{
					Console.WriteLine("Engine number {0} started!", _engineNumber);
				}
			}else{
				Console.WriteLine("Engine number {0} is already running!", _engineNumber);
			}
		}
		
		public void StopEngine(){
			if(_isRunning){
				_isRunning = false;
				Console.WriteLine("Engine number {0} has been stopped!", _engineNumber);
			}else{
				Console.WriteLine("Engine number {0} is not running!", _engineNumber);
			}
		}
		
		
		public void SetPartFault(String partName){
			for(int i=0; i<_itsParts.Length; i++){
				if(_itsParts[i].PartName.Equals(partName)){
					_itsParts[i].SetFault();
					Console.WriteLine("The status of Engine number {0}'s {1} is {2}", _engineNumber, 
														_itsParts[i].PartName, _itsParts[i].Status);
				  break;
				}
			}
			CheckEngine();
		}
		
		public void ClearPartFault(String partName){
			for(int i=0; i<_itsParts.Length; i++){
				if(_itsParts[i].PartName.Equals(partName)){
					_itsParts[i].ClearFault();
					Console.WriteLine("The status of Engine number {0}'s {1} is {2}", _engineNumber, 
														_itsParts[i].PartName, _itsParts[i].Status);
					break;
				}
			}
			CheckEngine();
		}
	} // end class
} // end namespace