using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{
    private int food;

    Hunger hunger;

    private bool isEating;

    private List<GameObject> holdingList;
    public int maxHolding = 2;

    public Transform eatingTransform;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        hunger = GetComponent<Hunger>();
        holdingList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isEating", isEating);
    }

    //Returns true if food was eated
    public bool FeedRat(int foodAmount)
    {
        if (hunger.Eat(foodAmount))
        {
            isEating = true;
            return true;
        }
        isEating = false;
        return false;
 
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
        }
        return false;
    }

    public void LetGoSnack(GameObject go)
    {
        if (IsHolding(go))
        {
            isEating = false;
            holdingList.Remove(go);
            go.transform.parent = null;
        }
    }

    public bool IsHolding(GameObject go)
    {
        return holdingList.Contains(go);
    }
}
