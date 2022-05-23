using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShuffleArrayLists
{
    //array to be shuffled
    public static void Shuffle<T>(this T[] array, int shufflAccuracy) //constructor, i think, with "T" being a generic variable
    {
        for (int i = 0; i < shufflAccuracy; i++) //loop
        {
            int randomIndex = UnityEngine.Random.Range(1, array.Length); //define random range based on array length (max number for loop)

            T temp = array[randomIndex];
            array[randomIndex] = array[0];
            array[0] = temp;
        }
    }

    public static void Shuffle<T>(this List<T> list, int shufflAccuracy) //constructor, i think
    {
        for (int i = 0; i < shufflAccuracy; i++) //loop
        {
            int randomIndex = UnityEngine.Random.Range(1, list.Count); //define random range based on list length

            T temp = list[randomIndex];
            list[randomIndex] = list[0];
            list[0] = temp;
        }
    }


}
/*
 * Because this is not a MondBehaviour, but just a single Class, the method "Shuffle" was created. 
 * This could be helpful. 
 * 
 * 
 */