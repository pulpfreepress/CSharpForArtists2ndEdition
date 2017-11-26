/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PeopleManagerApplication {
  public static void Main(){
   PeopleManager pm = new PeopleManager(); // default constructor call
   pm.AddPerson("Jeff", "J", "Meyer", Person.Sex.MALE, 1975, 03, 12);
   pm.AddPerson("Pete", "M", "Luongo", Person.Sex.MALE, 1967, 06, 18);
   pm.AddPerson("Alex", "T", "Remily", Person.Sex.MALE, 1965, 11, 24);
   pm.ListPeople();
   Console.WriteLine("----------------------------------------");
   pm.DeletePersonAtIndex(0);
   pm.ListPeople();
   Console.WriteLine("----------------------------------------");
   pm.InsertPersonAtIndex(0, "Coralie", "S", "Miller", Person.Sex.FEMALE, 1963, 04, 04); 
   pm.ListPeople();
  } // end Main
} // end class definition