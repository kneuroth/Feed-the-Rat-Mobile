using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour, IMovement 
{

    public Transform goal;

    public DestinationBehavior destinationBehavior;

    public float speed = 1;



    public bool canMove { get; set; } = true;




    public void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, goal.position, speed * Time.deltaTime);
            if (Vector2.Distance((Vector2)transform.position, (Vector2)goal.position) < 1)
            {
                gameObject.SendMessage("Delete", DestroyType.offScreen);
            }
        }
    }

    


}
