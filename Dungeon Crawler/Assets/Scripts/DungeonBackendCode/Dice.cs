using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public static int roll(int sides)
    {
        return Random.Range(1, sides + 1);
    }
}
