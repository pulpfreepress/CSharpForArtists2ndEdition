/*****************************************************************  Copyright 2006 Rick Miller, Raffi Kasparian - Pulp Free Press         This source code accompanies the text Java For Artists and is
   provided for instructional purposes only. No warranty concerning
   the quality of this code is expressed or implied. You are free to 
   use this code in your programs so long as this copyright notice
   is included in its entirety.*****************************************************************/

public class TwoDArrayLiterals {
  public static void main(String[] args){
    /************** ragged int array **************************/
    int[][] int_2d_ragged_array = {{1,2},
                                   {1,2,3,4},
                                   {1,2,3},
                                   {1,2,3,4,5,6,7,8}};
   

   for(int i = 0; i < int_2d_ragged_array.length; i++){
     for(int j = 0; j < int_2d_ragged_array[i].length; j++){
       System.out.print(int_2d_ragged_array[i][j] + " ");
     }
     System.out.println();
   }

   /************* ragged String array ***********************/
   String[][] string_2d_ragged_array = {{"Now ", "is ", "the ", "time "},
                                        {"for ", "all ", "good men "},
                                        {"to come to ", "the aid "},
                                        {"of their country!"}};

   for(int i = 0; i < string_2d_ragged_array.length; i++){
     for(int j = 0; j < string_2d_ragged_array[i].length; j++){
       System.out.print(string_2d_ragged_array[i][j]);
     }
     System.out.println();
   }
  }
}