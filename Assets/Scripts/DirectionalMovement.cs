using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour, IMovement
{
    public float speed = 1;

    public Transform goal;

    public bool canMove { get; set; } = true;


    public Direction direction = Direction.Left;

    public void Step()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, (Vector2)transform.position + GetDirection(), speed * Time.deltaTime);
            if (OutOfBounds())
            {
                gameObject.SendMessage("Delete", DestroyType.offScreen);
            }
        }
    }

    private Vector2 GetDirection()
    {
        switch (direction)
        {
            case Direction.Left: return Vector2.left;
            case Direction.Right: return Vector2.right;
            case Direction.Up: return Vector2.up;
            case Direction.Down: return Vector2.down;
            default: return Vector2.left;
        }
    }

    // Returns true if current position is past goal depending on direction of movement
    private bool OutOfBounds()
    {
        switch (direction)
        {
            case Direction.Left: return transform.position.x < goal.position.x;
            case Direction.Right: return transform.position.x > goal.position.x;
            case Direction.Up: return transform.position.y > goal.position.y;
            case Direction.Down: return transform.position.y < goal.position.y;
            default: return transform.position.x < goal.position.x;
        }
    }
}
