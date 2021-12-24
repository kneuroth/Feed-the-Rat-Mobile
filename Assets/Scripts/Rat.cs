using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    private int food;

    Hunger hunger;
    // Start is called before the first frame update
    void Start()
    {
        hunger = GetComponent<Hunger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Returns true if food was eated
    public bool FeedRat(int foodAmount)
    {
        return hunger.Eat(foodAmount);
    }

    public bool isFull()
    {
        return hunger.isFull();
    }

    public void GrabSnack(GameObject go)
    {
        go.transform.parent = transform;
    }
}
