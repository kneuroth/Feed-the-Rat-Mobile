using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    private int food;

    Hunger hunger;

    private List<GameObject> holdingList;
    public int maxHolding = 2;

    public Transform eatingTransform;


    // Start is called before the first frame update
    void Start()
    {
        hunger = GetComponent<Hunger>();
        holdingList = new List<GameObject>();
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

    public bool GrabSnack(GameObject go)
    {
        if(holdingList.Count < maxHolding)
        {
            holdingList.Add(go);
            return true;
            //go.transform.parent = eatingLocation;
            //go.transform.position = eatingLocation.position;
        }
        return false;
    }

    public void LetGoSnack(GameObject go)
    {
        if (IsHolding(go))
        {
            holdingList.Remove(go);
            go.transform.parent = null;
        }
    }

    public bool IsHolding(GameObject go)
    {
        return holdingList.Contains(go);
    }
}
