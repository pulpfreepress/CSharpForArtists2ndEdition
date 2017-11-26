/********************************************************************************
  Copyright 2015 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 

using System;

public class PeopleManager {
  // private fields
  private Person[] _peopleArray;
  int index = 0;
  
  // overloaded constructor
  public PeopleManager(int length){
    _peopleArray = new Person[length];
  }
  
  // default constructor
  public PeopleManager():this(10){ }
  
  
  public void AddPerson(String firstName, String middleName, String lastName,
                        Person.Sex gender, int dob_year, int dob_month, int dob_day){
    if(index >= _peopleArray.Length){
       index = 0;
    }
    if(_peopleArray[index] == null){
      _peopleArray[index++] = new Person(firstName, middleName, lastName, gender,
                                          new DateTime(dob_year, dob_month, dob_day));
    }
  } // end method
  
  
  public void ListPeople(){
    for(int i = 0; i<_peopleArray.Length; i++){
      if(_peopleArray[i] != null){
        Console.WriteLine(_peopleArray[i]);
      }
    }
  } // end method
  
  
  public void DeletePersonAtIndex(int index){
    if(!(index < 0) || (index >= _peopleArray.Length)){
      _peopleArray[index] = null;
      this.index = index;
    }
  }
  
  
  public void InsertPersonAtIndex( int index, String firstName, String middleName, 
                                   String lastName, Person.Sex gender, int dob_year, 
                                   int dob_month, int dob_day){
      if(!(index < 0) || (index >= _peopleArray.Length)){
        this.index = index;
        _peopleArray[this.index++] = new Person(firstName, middleName, lastName, gender,
                                          new DateTime(dob_year, dob_month, dob_day));
      }                               
   }
  

} // end PeopleManager class