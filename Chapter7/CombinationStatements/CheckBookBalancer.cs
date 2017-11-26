/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class CheckBookBalancer {
    static void Main(){
      /**** Initialize Program Variables ******/

      char keep_going = 'Y';
      double balance = 0.0;
      double deposits = 0.0;
      double withdrawals = 0.0;
      bool good_double = false;

      /**** Display Welcome Message ****/
      Console.WriteLine("Welcome to Checkbook Balancer");
      
    
      /**** Get Starting Balance *****/
      do{
       try{
         Console.Write("Please enter the opening balance: ");
         balance = Convert.ToDouble(Console.ReadLine());
         good_double = true;
         }catch(FormatException){ Console.WriteLine("Please enter a valid balance!");}
        }while(!good_double);
        

      /**** Add All Deposits ****/
      while((keep_going == 'y') || (keep_going == 'Y')){
          good_double = false;
          do{
            try{
               Console.Write("Enter a deposit amount: ");
               deposits += Convert.ToDouble(Console.ReadLine());
               good_double = true;
               }catch(FormatException){ Console.WriteLine("Please enter a valid deposit value!");}
             }while(!good_double);
           Console.WriteLine("Do you have to enter another deposit? y/n");
           try{
             keep_going = (Console.ReadLine())[0];
              }catch(IndexOutOfRangeException){ Console.WriteLine("Problem reading input!");}
      }

     /**** Subtract All Checks Written ****/
      keep_going = 'y';
      while((keep_going == 'y') || (keep_going == 'Y')){
          good_double = false;
          do{
            try{
               Console.Write("Enter a check amount: ");
               withdrawals += Convert.ToDouble(Console.ReadLine());
               good_double = true;
               }catch(FormatException){ Console.WriteLine("Please enter a valid check amount!");}
             }while(!good_double);
           Console.WriteLine("Do you have to enter another check? y/n");
           try{
             keep_going = (Console.ReadLine())[0];
              }catch(IndexOutOfRangeException){ Console.WriteLine("Problem reading input!");}
      }

      /**** Display Final Tally ****/

      Console.WriteLine("***************************************");
      Console.WriteLine("Opening balance:     $   " + balance);
      Console.WriteLine("Total deposits:     +$   " + deposits);
      Console.WriteLine("Total withdrawals:  -$   " + withdrawals);
      balance = balance + (deposits - withdrawals);
      Console.WriteLine("New balance is:      $   " + balance);
      Console.WriteLine("\n\n");
  }
}
