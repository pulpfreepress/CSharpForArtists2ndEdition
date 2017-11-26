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
using System.Text;

namespace RobotRat {

		/// <summary>
		/// RobotRat class lets a user control the movements
		/// of a robot rat around a floor represented by
		/// a 2-dimensional array.
		/// </summary>
		public class RobotRat {

				private bool keep_going = true;
				private const char PEN_UP = '1';
				private const char PEN_DOWN = '2';
				private const char TURN_RIGHT = '3';
				private const char TURN_LEFT = '4';
				private const char MOVE_FORWARD = '5';
				private const char PRINT_FLOOR = '6';
				private const char EXIT = '7';
				private enum PenPositions { UP, DOWN };
				private enum Directions { NORTH, SOUTH, EAST, WEST };
				private PenPositions pen_position = PenPositions.UP;
				private Directions direction = Directions.EAST;
				private bool[,] floor;
				private int current_row = 0;
				private int current_col = 0;

				/// <summary>
				/// Constructor method. 
				/// </summary>
				/// <param name="rows">Integer value representing number of floor rows</param>
				/// <param name="cols">Integer value representing number of floor columns</param>
				public RobotRat(int rows, int cols) {
						Console.WriteLine("RobotRat Lives!");
						floor = new bool[rows, cols];
				}

				/// <summary>
				/// Prints the floor pattern to the screen.
				/// </summary>
				public void PrintMenu() {
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
				public void ProcessMenuChoice() {
						String input = Console.ReadLine();

						if (input == String.Empty) {
								input = "0";
						}

						switch (input[0]) {
								case PEN_UP: SetPenUp();
										break;
								case PEN_DOWN: SetPenDown();
										break;
								case TURN_RIGHT: TurnRight();
										break;
								case TURN_LEFT: TurnLeft();
										break;
								case MOVE_FORWARD: MoveForward();
										break;
								case PRINT_FLOOR: PrintFloor();
										break;
								case EXIT: keep_going = false;
										break;
								default: PrintErrorMessage();
										break;
						}
				}

				/// <summary>
				/// Sets the pen to the UP state.
				/// </summary>
				public void SetPenUp() {
						pen_position = PenPositions.UP;
						Console.WriteLine("The pen is " + pen_position);
				}

				/// <summary>
				/// Sets the pen to the DOWN state.
				/// </summary>
				public void SetPenDown() {
						pen_position = PenPositions.DOWN;
						Console.WriteLine("The pen is " + pen_position);
				}


				/// <summary>
				/// Turns the robot rat right.
				/// </summary>
				public void TurnRight() {
						switch (direction) {
								case Directions.NORTH: direction = Directions.EAST;
										break;
								case Directions.EAST: direction = Directions.SOUTH;
										break;
								case Directions.SOUTH: direction = Directions.WEST;
										break;
								case Directions.WEST: direction = Directions.NORTH;
										break;
						}

						Console.WriteLine("Direction is " + direction);
				}



				/// <summary>
				/// Turns the robot rat left.
				/// </summary>
				public void TurnLeft() {
						switch (direction) {
								case Directions.NORTH: direction = Directions.WEST;
										break;
								case Directions.WEST: direction = Directions.SOUTH;
										break;
								case Directions.SOUTH: direction = Directions.EAST;
										break;
								case Directions.EAST: direction = Directions.NORTH;
										break;
						}

						Console.WriteLine("Direction is " + direction);
				}


				/// <summary>
				/// Prints the floor pattern to the console.
				/// </summary>
				public void PrintFloor() {
						for (int i = 0; i < floor.GetLength(0); i++) {
								for (int j = 0; j < floor.GetLength(1); j++) {
										if (floor[i, j]) {
												Console.Write('-');
										}
										else {
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
				public void PrintErrorMessage() {
						Console.WriteLine("Please enter a valid RobotRat control option!");
				}


				/// <summary>
				/// This method continuously displays the menu
				/// and processes user menu choices.
				/// </summary>
				public void Run() {
						while (keep_going) {
								PrintMenu();
								ProcessMenuChoice();
						}
				}

				/// <summary>
				/// Called to move the robot rat forward.
				/// </summary>
				public void MoveForward() {
						int spaces_to_move = GetSpacesToMove();

						switch (pen_position) {
								case PenPositions.UP: switch (direction) {
												case Directions.NORTH:
														if ((current_row - spaces_to_move) < 0) {
																current_row = 0;
														}
														else {
																current_row = current_row - spaces_to_move;
														}
														break;
												case Directions.SOUTH:
														if ((current_row + spaces_to_move) > (floor.GetLength(0) - 1)) {
																current_row = (floor.GetLength(0) - 1);
														}
														else {
																current_row = current_row + spaces_to_move;
														}
														break;
												case Directions.EAST:
														if ((current_col + spaces_to_move) > (floor.GetLength(1) - 1)) {
																current_col = (floor.GetLength(1) - 1);
														}
														else {
																current_col = current_col + spaces_to_move;
														}
														break;
												case Directions.WEST:
														if ((current_col - spaces_to_move) < 0) {
																current_col = 0;
														}
														else {
																current_col = current_col - spaces_to_move;
														}
														break;
										}
										break;
								case PenPositions.DOWN: switch (direction) {
												case Directions.NORTH:
														while ((current_row > 0) && (spaces_to_move-- > 0)) {
																floor[current_row--, current_col] = true;
														}
														break;
												case Directions.SOUTH:
														while ((current_row < floor.GetLength(0) - 1) && (spaces_to_move-- > 0)) {
																floor[current_row++, current_col] = true;
														}
														break;
												case Directions.EAST:
														while ((current_col < floor.GetLength(1) - 1) && (spaces_to_move-- > 0)) {
																floor[current_row, current_col++] = true;
														}
														break;
												case Directions.WEST:
														while ((current_col > 0) && (spaces_to_move-- > 0)) {
																floor[current_row, current_col--] = true;
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
				public int GetSpacesToMove() {
						int spaces = 0;
						String input;

						Console.WriteLine("Please enter number of spaces to move: ");
						input = Console.ReadLine();

						if (input == String.Empty) {
								spaces = 0;
						}
						else {
								try {
										spaces = Convert.ToInt32(input);

								}
								catch (Exception) {
										spaces = 0;
								}
						}
						return spaces;
				}


				/// <summary>
				/// The RobotRat's Main method.
				/// </summary>
				/// <param name="args"></param>
				public static void Main(String[] args) {
						RobotRat rr = new RobotRat(20, 20);
						rr.Run();
				}
		}
}
