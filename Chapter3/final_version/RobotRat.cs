/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

/// <summary>
/// RobotRat class lets a user control the movements
/// of a robot rat around a floor represented by
/// a 2-dimensional array.
/// </summary>
public class RobotRat {

	private bool _keepGoing = true;
	private const char PEN_UP 			= '1';
	private const char PEN_DOWN 		= '2';
	private const char TURN_RIGHT 	= '3';
	private const char TURN_LEFT 		= '4';
	private const char MOVE_FORWARD = '5';
	private const char PRINT_FLOOR 	= '6';
	private const char EXIT 				= '7';
	private enum PenPositions { UP, DOWN }
	private enum Directions { NORTH, SOUTH, EAST, WEST }
	private PenPositions _penPosition = PenPositions.UP;
	private Directions _direction = Directions.EAST;
	private bool[,] _floor;
	private int _currentRow = 0;
	private int _currentColumn = 0;

	/// <summary>
	/// Constructor method. 
	/// </summary>
	/// <param name="rows">Integer value representing number of floor rows</param>
	/// <param name="cols">Integer value representing number of floor columns</param>
	public RobotRat(int rows, int cols){
		Console.WriteLine("RobotRat Lives!");
		_floor = new bool[rows, cols];
	}

	/// <summary>
	/// Prints the menu to the screen.
	/// </summary>
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

	/// <summary>
	/// Processes user's menu selection.
	/// </summary>
	public void ProcessMenuChoice(){
		String input = Console.ReadLine();
		if (input == String.Empty){
			input = "0";
		}
		switch (input[0]){
			case PEN_UP:				SetPenUp();
													break;
			case PEN_DOWN: 			SetPenDown();
													break;
			case TURN_RIGHT: 		TurnRight();
													break;
			case TURN_LEFT: 		TurnLeft();
													break;
			case MOVE_FORWARD: 	MoveForward();
													break;
			case PRINT_FLOOR: 	PrintFloor();
													break;
			case EXIT: 					_keepGoing = false;
													break;
			default: 						PrintErrorMessage();
													break;
		}
	}

	/// <summary>
	/// Sets the pen to the UP state.
	/// </summary>
	public void SetPenUp(){
		_penPosition = PenPositions.UP;
		Console.WriteLine("The pen is " + _penPosition);
	}

	/// <summary>
	/// Sets the pen to the DOWN state.
	/// </summary>
	public void SetPenDown(){
		_penPosition = PenPositions.DOWN;
		Console.WriteLine("The pen is " + _penPosition);
	}

	/// <summary>
	/// Turns the robot rat right.
	/// </summary>
	public void TurnRight(){
		switch (_direction){
			case Directions.NORTH:	_direction = Directions.EAST;
															break;
			case Directions.EAST:		_direction = Directions.SOUTH;
															break;
			case Directions.SOUTH:	_direction = Directions.WEST;
															break;
			case Directions.WEST:		_direction = Directions.NORTH;
															break;
		}
		Console.WriteLine("Direction is " + _direction);
	}

	/// <summary>
	/// Turns the robot rat left.
	/// </summary>
	public void TurnLeft(){
		switch (_direction){
			case Directions.NORTH:	_direction = Directions.WEST;
															break;
			case Directions.WEST:		_direction = Directions.SOUTH;
															break;
			case Directions.SOUTH:	_direction = Directions.EAST;
															break;
			case Directions.EAST:		_direction = Directions.NORTH;
															break;
		}
		Console.WriteLine("Direction is " + _direction);
	}

	/// <summary>
	/// Prints the floor pattern to the console.
	/// </summary>
	public void PrintFloor(){
		for (int i = 0; i < _floor.GetLength(0); i++){
			for (int j = 0; j < _floor.GetLength(1); j++){
				if (_floor[i, j]){
					Console.Write('-');
				} else {
						Console.Write('0');
				}
			}
			Console.WriteLine();
		}
	}

	/// <summary>
	/// Prints an error message. Called if a user enters an invalid
	/// menu choice.
	/// </summary>
	public void PrintErrorMessage(){
		Console.WriteLine("Please enter a valid RobotRat control option!");
	}

	/// <summary>
	/// This method continuously displays the menu
	/// and processes user menu choices.
	/// </summary>
	public void Run(){
		while (_keepGoing){
			PrintMenu();
			ProcessMenuChoice();
		}
	}

	/// <summary>
	/// Called to move the robot rat forward.
	/// </summary>
	public void MoveForward(){
		int spaces_to_move = GetSpacesToMove();
		switch (_penPosition){
			case PenPositions.UP: 
				switch (_direction){
					case Directions.NORTH:
						if ((_currentRow - spaces_to_move) < 0){
							_currentRow = 0;
						} else {
								_currentRow = _currentRow - spaces_to_move;
						}
						break;
					case Directions.SOUTH:
						if ((_currentRow + spaces_to_move) > (_floor.GetLength(0) - 1)){
							_currentRow = (_floor.GetLength(0) - 1);
						} else {
								_currentRow = _currentRow + spaces_to_move;
						}
						break;
					case Directions.EAST:
						if ((_currentColumn + spaces_to_move) > (_floor.GetLength(1) - 1)){
							_currentColumn = (_floor.GetLength(1) - 1);
						} else {
								_currentColumn = _currentColumn + spaces_to_move;
						}
						break;
					case Directions.WEST:
						if ((_currentColumn - spaces_to_move) < 0){
							_currentColumn = 0;
						} else {
								_currentColumn = _currentColumn - spaces_to_move;
						}
						break;
				}
			break;
			case PenPositions.DOWN: 
				switch (_direction){
					case Directions.NORTH:
						while ((_currentRow > 0) && (spaces_to_move-- > 0)){
							_floor[_currentRow--, _currentColumn] = true;
						}
						break;
					case Directions.SOUTH:
						while ((_currentRow < _floor.GetLength(0) - 1) && (spaces_to_move-- > 0)){
							_floor[_currentRow++, _currentColumn] = true;
						}
						break;
					case Directions.EAST:
						while ((_currentColumn < _floor.GetLength(1) - 1) && (spaces_to_move-- > 0)){
							_floor[_currentRow, _currentColumn++] = true;
						}
						break;
					case Directions.WEST:
						while ((_currentColumn > 0) && (spaces_to_move-- > 0)){
							_floor[_currentRow, _currentColumn--] = true;
						}
						break;
				}
			break;
		}
	}

	/// <summary>
	///  Gets the number of spaces to move from the user.
	/// </summary>
	/// <returns></returns>
	public int GetSpacesToMove(){
		int spaces = 0;
		String input;
		Console.WriteLine("Please enter number of spaces to move: ");
		input = Console.ReadLine();

		if (input == String.Empty){
			spaces = 0;
		} else {
				try {
					spaces = Convert.ToInt32(input);
				} catch (Exception) {
						spaces = 0;
				}
			}
		return spaces;
	}

	/// <summary>
	/// The RobotRat's Main method.
	/// </summary>
	/// <param name="args"></param>
	public static void Main(String[] args){
		int rows = 20;
		int cols = 20;
		try {
			switch(args.Length){
				case 0: break;
				case 1: rows = Int32.Parse(args[0]);
								rows = (rows < 0) ? (rows *= -1) : rows;  // convert negative numbers
								rows = (rows == 0) ? (rows += 5) : rows;  // limit min value to 5
								rows = (rows > 50) ? (rows = 50) : rows;  // limit max value to 50
								cols = rows;
								break;
				case 2: rows = Int32.Parse(args[0]);
								cols = Int32.Parse(args[1]);
								rows = (rows < 0) ? (rows *= -1) : rows;  // convert negative numbers
								rows = (rows == 0) ? (rows += 5) : rows;  // limit min value to 5
								rows = (rows > 50) ? (rows = 50) : rows;  // limit max value to 50
								cols = (cols < 0) ? (cols *= -1) : cols;  // convert negative numbers
								cols = (cols == 0) ? (cols += 5) : cols;  // limit min value to 5
								cols = (cols > 50) ? (cols = 50) : cols;  // limit max value to 50
								break;
				default:	break;
			}
			RobotRat rr = new RobotRat(rows, cols);
			Console.Clear();
      rr.Run();
		}catch(FormatException){
			Console.WriteLine("Invalid number! Please enter a valid integer value!");
		}catch(OverflowException){
			Console.WriteLine("Please enter an integer value between: {0} and {1}", 5, 50);
		}  
  }
}
