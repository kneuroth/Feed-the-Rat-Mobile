using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{

    public int hungriness = 20;
    private int maxHungriness;
    private void Start()
    {
        maxHungriness = hungriness;
    }

    // Returns true if food was eated
    public bool Eat(int foodAmount)
    {
        if (!isFull())
        {
            hungriness = hungriness - foodAmount;
            return true;
        }
        return false;
    }

    public bool isFull()
    {
        return hungriness <= 0;
    }

    public float fullPercent()
    {
        return Mathf.Abs(100 - (hungriness * 100 / maxHungriness * 100) );
    }
}
