/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class WeightedGradeTool {
    static void Main() {

        double[,] grades = null;
        double[] weights = null;
        String[] students = null;
        int student_count = 0;
        int grade_count = 0;
        double final_grade = 0;

        Console.WriteLine("Welcome to Weighted Grade Tool");

        /**************** get student count *********************/
        Console.Write("Please enter the number of students: ");
        try {
            student_count = Int32.Parse(Console.ReadLine());
        }
        catch (FormatException) {
            Console.WriteLine("That was not an integer!");
            Console.WriteLine("Student count will be set to 3.");
            student_count = 3;
        }


        if (student_count > 0) {
            students = new String[student_count];
            /***************** get student names **********************/
            for (int i = 0; i < students.Length; i++) {
                Console.Write("Enter student name: ");
                students[i] = Console.ReadLine();
            }

            /**************** get number of grades per student **********/
            Console.Write("Please enter the number of grades to average: ");
            try {
                grade_count = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException) {
                Console.WriteLine("That was not an integer!");
                Console.WriteLine("Grade count will be set to 3.");
                grade_count = 3;
            }

            /****************** get raw grades *****************************/
            grades = new double[student_count, grade_count];
            for (int i = 0; i < grades.GetLength(0); i++) {
                Console.WriteLine("Enter raw grades for " + students[i]);
                for (int j = 0; j < grades.GetLength(1); j++) {
                    Console.Write("Grade " + (j + 1) + ": ");
                    try {
                        grades[i, j] = Double.Parse(Console.ReadLine());
                    }
                    catch (FormatException) {
                        Console.WriteLine("That was not a double!");
                        Console.WriteLine("Grade will be set to 100");
                        grades[i, j] = 100;
                    }
                }//end inner for
            }

            /***************** get grade weights *********************/
            weights = new double[grade_count];
            Console.WriteLine("Enter grade weights. Make sure they total 100%");
            for (int i = 0; i < weights.Length; i++) {
                Console.Write("Weight for grade " + (i + 1) + ": ");
                try {
                    weights[i] = Double.Parse(Console.ReadLine());
                }
                catch (FormatException) {
                    Console.WriteLine("That was not a double!");
                    Console.WriteLine("The weight will be set to 25");
                    weights[i] = 25.0;
                }
            }

            /****************** calculate weighted grades ********************/
            for (int i = 0; i < grades.GetLength(0); i++) {
                for (int j = 0; j < grades.GetLength(1); j++) {
                    grades[i, j] *= weights[j];
                }//end inner for
            }

            /***************** calculate and print final grade *********************/
            for (int i = 0; i < grades.GetLength(0); i++) {
                Console.WriteLine("Weighted grades for " + students[i] + ": ");
                final_grade = 0;
                for (int j = 0; j < grades.GetLength(1); j++) {
                    final_grade += grades[i, j];
                    Console.Write(grades[i, j] + " ");
                }//end inner for
                Console.WriteLine(students[i] + "'s final grade is: " + final_grade);
            }
        }// end if
    }// end Main
}// end class
