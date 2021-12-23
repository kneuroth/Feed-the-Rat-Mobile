using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public TMPro.TextMeshProUGUI tummyText;
    public int hungriness = 20;
    private int maxHungriness;
    private void Start()
    {
        maxHungriness = hungriness;
        tummyText.text = "0%";
    }

    // Returns true if food was eated
    public bool Eat(int foodAmount)
    {
        if (!isFull())
        {
            hungriness = hungriness - foodAmount;
            tummyText.text = fullPercent() + "%";
            return true;
        }
        return false;
    }

    public bool isFull()
    {
        return hungriness <= 0;
    }

    public int fullPercent()
    {
        
        return (int)Mathf.Round(Mathf.Abs(1 - ((float)hungriness / (float)maxHungriness)) * 100);
    }
}
