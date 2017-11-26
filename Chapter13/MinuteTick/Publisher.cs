/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;
 
public class Publisher {
        
   public event ElapsedMinuteEventHandler MinuteTick;
   
   
   public Publisher(){
     Console.WriteLine("Publisher Created");
   }
   
   public void CountMinutes(){
     int current_minute = DateTime.Now.Minute;
     while(true){
       if(current_minute != DateTime.Now.Minute){ 
          Console.WriteLine("Publisher: {0}", DateTime.Now.Minute);
          OnMinuteTick(new MinuteEventArgs(DateTime.Now));
          current_minute = DateTime.Now.Minute;
       }//end if 
     } // end while
   } // end countMinutes method
   
   private void OnMinuteTick(MinuteEventArgs e){
      if(MinuteTick != null){
         MinuteTick(this, e);
       }
   }// end onMinuteTick method
} // end Publisher class definition
