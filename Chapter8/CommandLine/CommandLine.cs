/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
using System.Text;

public class CommandLine {
    static void Main(String[] args){
    StringBuilder sb = null;
    bool upper_case = false;
    int start_index = 0;
   
    
   /********** check for upper case option **************/
   if(args.Length > 0){
      switch(args[0][0]){ // get the first character of the first argument
        case '-' : 
                 if(args[0].Length > 1){
                   switch(args[0][1]){ // get the second character of the first argument
                      case 'U' :
                      case 'u' : upper_case = true;
                                 break;
                      default:   upper_case = false;
                                 break;
                   }
                  }
                 start_index = 1;
                 break;
        default: upper_case = false;
                 break;

      }// end outer switch
     
      sb = new StringBuilder();   //create StringBuffer object
 
   /******* process text string **********************/
     for(int i = start_index; i < args.Length; i++){
           sb.Append(args[i] + " ");
     }//end for
   
      if(upper_case){
        
        Console.WriteLine(sb.ToString().ToUpper());
      }else { 
          
        Console.WriteLine(sb.ToString().ToLower());
       }//end if/else
    
   } else { Console.WriteLine("Usage: CommandLine [-U | -u] Text string");}

  }//end main
}//end class
