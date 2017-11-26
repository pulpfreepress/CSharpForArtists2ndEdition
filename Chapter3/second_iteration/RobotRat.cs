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
   
   public RobotRat(){
     PrintMenu();
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
   
   
   public static void Main(String[] args){
     RobotRat rr = new RobotRat();
   }

}