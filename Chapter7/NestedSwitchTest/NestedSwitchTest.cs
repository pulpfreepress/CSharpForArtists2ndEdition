/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class NestedSwitchTest {
  public static void Main(String[] args){
  try{
     char char_c = (args[0])[0];
     int int_i = Convert.ToInt32(args[1]);

     switch(char_c){
       case 'U' : 
       case 'u' : switch(int_i){
                    case 1: 
                    case 2: 
                    case 3: 
                    case 4: 
                    case 5: Console.WriteLine("You entered " + char_c + " and " + int_i);
                            break;
                    default: Console.WriteLine("Please enter: 1, 2, 3, 4, or 5");
                             break;
                  }
                  break;
       case 'D' : 
       case 'd' : switch(int_i){
                    case 1: 
                    case 2:
                    case 3: 
                    case 4: 
                    case 5: Console.WriteLine("You entered " + char_c + " and " + int_i);
                            break;
                    default: Console.WriteLine("Please enter: 1, 2, 3, 4, or 5");
                             break;
                  }
                  break;
         default: Console.WriteLine("Please enter: U, u, D, or d");
                  break;
       }
       
     }catch(IndexOutOfRangeException){
         Console.WriteLine("The program requires two arguments! Please Try again.");
     }catch(FormatException){
         Console.WriteLine("Invalid number. Please try again.");
     }

    }    
  }
