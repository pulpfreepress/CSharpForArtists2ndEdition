/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Drawing;
using System.Windows.Forms;

public class WaterTank : Panel {
	
	// Private fields
	private WaterLevelSensor _highLevelSensor;
	private WaterLevelSensor _lowLevelSensor;
	private Pen _whitePen;
	private Pen _bluePen;
  private int _penWidth;
	private int _currentWaterLevel;
	private int _lastWaterLevel;
	private int _tankCapacity;
  private Point _bottomLeft;
  private Point _bottomRight;
  private Pump _itsPump;
  private Graphics _graphics;
  
  // Constants
  private const int UPPER_LEFT_CORNER_X = 100;
  private const int UPPER_LEFT_CORNER_Y = 100; 
  private const int WIDTH = 100;
  private const int HEIGHT = 500;
  private const int TANK_CAPACITY = 10000;
  private const int PUMP_CAPACITY = 1000;
  private const int ONE_PIXEL_WIDE = 1;
  private const int EMPTY = 0;
  
  public int WaterLevel {
		get {return _currentWaterLevel; }
	}
	
	public int FillRate {
		get {return _itsPump.PumpingCapacity; }
	}
	
	public int HighSetPoint {
		get { return _highLevelSensor.SetPoint; }
		set { _highLevelSensor.SetPoint = value; }
	}
	
	public int LowSetPoint {
		get { return _lowLevelSensor.SetPoint; }
		set { _lowLevelSensor.SetPoint = value; }
	}
	
	public WaterTank(int x, int y, int width, int height, int tankCapacity, int pumpCapacity){
		this.InitializeComponents(x, y, width, height, tankCapacity, pumpCapacity);
	}
	
	public WaterTank():this(UPPER_LEFT_CORNER_X, UPPER_LEFT_CORNER_Y, WIDTH, HEIGHT, TANK_CAPACITY, PUMP_CAPACITY){ }
	
	private void InitializeComponents(int x, int y, int width, int height, int tankCapacity, int pumpCapacity){
		
		this.Bounds = new Rectangle(x, y, width, height);
	  this.BackColor = Color.White;
		this.BorderStyle = BorderStyle.Fixed3D;
		_graphics = this.CreateGraphics();
		_bottomLeft = new Point(0, height);
		_bottomRight = new Point(width, height);
		_tankCapacity = tankCapacity;
		_currentWaterLevel = EMPTY;
		_itsPump = new Pump(this, pumpCapacity);
		_penWidth = this.Height/(_tankCapacity/_itsPump.PumpingCapacity);
		if(_penWidth < 1) _penWidth = 1;
    _whitePen = new Pen(Color.White, _penWidth);
		_bluePen = new Pen(Color.Blue, _penWidth);
		_highLevelSensor = new WaterLevelSensor(tankCapacity - pumpCapacity, EMPTY);
		_highLevelSensor.SensorMode = WaterLevelSensor.Mode.HighLevelIndicator;
		_highLevelSensor.Fill += new WaterLevelEventHandler(_itsPump.FillTankEventHandler);
		_highLevelSensor.Full += new WaterLevelEventHandler(_itsPump.FullTankEventHandler);
		_lowLevelSensor = new WaterLevelSensor(pumpCapacity, EMPTY);
		_lowLevelSensor.SensorMode = WaterLevelSensor.Mode.LowLevelIndicator;
		_lowLevelSensor.Drain += new WaterLevelEventHandler(_itsPump.DrainTankEventHandler);
		_lowLevelSensor.Empty += new WaterLevelEventHandler(_itsPump.EmptyTankEventHandler);
	}
	
	public void ChangeWaterLevel(int amount){
		_lowLevelSensor.WaterLevelChange(amount);
		_highLevelSensor.WaterLevelChange(amount);
		_currentWaterLevel += amount;
		_lastWaterLevel = _currentWaterLevel;
		this.ChangeVisualLevel(amount);	
	}

	private void ChangeVisualLevel(int amount){
		if(amount > 0){	    
			_graphics.DrawLine(_bluePen, _bottomLeft, _bottomRight);
			_bottomLeft.Y -= _penWidth;
			_bottomRight.Y -= _penWidth;
			
		}else{
			_graphics.DrawLine(_whitePen, _bottomLeft, _bottomRight);
			_bottomLeft.Y += _penWidth;
			_bottomRight.Y += _penWidth;
			Delay(30000000);
		}
		
	} // end ChangeVisualLevel method
	
	private void Delay(long ticks){
		for(long i = 0; i<ticks; i++){
			;
		}
	}
	
} // end class definition