using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsMovement : MonoBehaviour, IMovement
{
    public List<Transform> transforms;
    public bool canMove { get; set; } = true;
    public int speed;
    private int goalTransformIndex;
    public void Start()
    {
        goalTransformIndex = 0;
    }

    public void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transforms[goalTransformIndex].position, speed * Time.deltaTime);

            if (Vector2.Distance((Vector2)transform.position, (Vector2)transforms[goalTransformIndex].position) < .2f)
            {
                goalTransformIndex++;
                if(goalTransformIndex >= transforms.Count)
                {
                    goalTransformIndex = 0;
                }
            }
        }
    }

}
