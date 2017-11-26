/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class Average {
  static void Main(){
      double[] grades      = null;
      double   total       = 0;
      double   average     = 0;
      int      grade_count = 0;
         
      Console.WriteLine("Welcome to Grade Averager");
      Console.Write("Please enter the number of grades to enter: ");
      try{
          grade_count = Int32.Parse(Console.ReadLine());
         } catch(FormatException) { Console.WriteLine("You did not enter a number!"); }
           
       
       if(grade_count > 0){
           grades = new double[grade_count];
              for(int i = 0; i < grade_count; i++){
                 Console.Write("Enter grade " + (i+1) + ": ");
                   try{
                      grades[i] = Double.Parse(Console.ReadLine());
                   } catch(FormatException) { Console.WriteLine("You did not enter a number!"); }  
              } //end for
             

              for(int i = 0; i < grade_count; i++){
                 total += grades[i];
              } //end for
 
             average = total/grade_count;
             Console.WriteLine("Number of grades entered: " + grade_count);
             Console.WriteLine("Grade average: {0:F2}           ", average);

        }//end if

   } //end main
}// end Average class definition