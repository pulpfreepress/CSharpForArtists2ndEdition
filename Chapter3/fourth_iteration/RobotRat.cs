/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class RobotRat {

	private bool _keepGoing = true;

	private const char PEN_UP       = '1';
	private const char PEN_DOWN     = '2';
	private const char TURN_RIGHT   = '3';
	private const char TURN_LEFT    = '4';
	private const char MOVE_FORWARD = '5';
	private const char PRINT_FLOOR  = '6';
	private const char EXIT         = '7';

	private enum PenPositions { UP, DOWN }
	private enum Directions { NORTH, SOUTH, EAST, WEST }

	private PenPositions _penPosition = PenPositions.UP;
	private Directions   _direction    = Directions.EAST;

	private bool[,] _floor;

	public RobotRat(int rows, int cols){
		Console.WriteLine("RobotRat Lives!");
		_floor = new bool[rows,cols];
	}

	public void PrintMenu(){
		Console.WriteLine("\n\n");
		Console.WriteLine("   RobotRat Control Menu");
		Console.WriteLine();
		Console.WriteLine("  1. Pen Up");
		Console.WriteLine("  2. Pen Down");
		Console.WriteLine("  3. Turn Right");
		Console.WriteLine("  4. Turn Left");
		Console.WriteLine("  5. Move Forward");
		Console.WriteLine("  6. Print Floor");
		Console.WriteLine("  7. Exit");
		Console.WriteLine("\n\n");
	}
   
	public void ProcessMenuChoice(){
		String input = Console.ReadLine();
 
		if(input == String.Empty){
			input = "0"; 
		}
 
		switch(input[0]){
			case PEN_UP :       SetPenUp();
													break;
			case PEN_DOWN :     SetPenDown();
													break;
			case TURN_RIGHT :   TurnRight();
													break;
			case TURN_LEFT :    TurnLeft();
													break;
			case MOVE_FORWARD : MoveForward();
													break;
			case PRINT_FLOOR :  PrintFloor();
													break;
			case EXIT :         _keepGoing = false;
													break;
			default :           PrintErrorMessage();
													break;
		}
	}

	public void SetPenUp(){
		_penPosition = PenPositions.UP;
		Console.WriteLine("The pen is " + _penPosition);
	}

	public void SetPenDown(){
		_penPosition = PenPositions.DOWN;
		Console.WriteLine("The pen is " + _penPosition);
	}

	public void TurnRight(){
		switch(_direction){
			case Directions.NORTH : _direction = Directions.EAST;
															break;
			case Directions.EAST  : _direction = Directions.SOUTH;
															break;
			case Directions.SOUTH : _direction = Directions.WEST;
															break;
			case Directions.WEST  : _direction = Directions.NORTH;
															break;
		}
		Console.WriteLine("Direction is " + _direction);
	}

	public void TurnLeft(){
		switch(_direction){
			case Directions.NORTH : _direction = Directions.WEST;
															break;
			case Directions.WEST  : _direction = Directions.SOUTH;
															break;
			case Directions.SOUTH : _direction = Directions.EAST;
															break;
			case Directions.EAST  : _direction = Directions.NORTH;
															break;
		}     
		Console.WriteLine("Direction is " + _direction);
	}

	public void MoveForward(){
		Console.WriteLine("MoveForward method called.");
	}
   
	public void PrintFloor(){
		for(int i = 0; i<_floor.GetLength(0); i++){
			for(int j = 0; j<_floor.GetLength(1); j++){
				if(_floor[i,j]){
					Console.Write('-');
				}else{
					Console.Write('0');
				}
			}
			Console.WriteLine();
		}
	}
   
	public void PrintErrorMessage(){
		Console.WriteLine("Please enter a valid RobotRat control option!");
	}

	public void Run(){
		while(_keepGoing){
			PrintMenu();
			ProcessMenuChoice();
		}
	}
    
	public static void Main(String[] args){
		RobotRat rr = new RobotRat(20, 20);
		rr.Run();
	}
}
