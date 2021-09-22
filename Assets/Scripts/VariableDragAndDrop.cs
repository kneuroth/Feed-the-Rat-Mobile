using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableDragAndDrop : MonoBehaviour
{
    
    // How often rat will "try" to be draggable (0-1)
    public float draggableRarity; 

    // How likely that the rat will become draggable (0-1)
    public float draggableProbability;

    // How many seconds the rat is draggable for (-1 for random time between 1 and 5 seconds)
    public int draggableDuration;

    int draggableTickdown;

    private bool draggable;

    DragAndDrop dragAndDrop;

    // Start is called before the first frame update
    void Start()
    {
        setDraggableTickdown();
        dragAndDrop = GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        // if this instance of the rat is draggable..
        if (draggableRarity > 0)
        {
            // Try draggable probability after draggable tickdown is up and then reset the tickdown
            if (draggableTickdown < 0)
            {
                rollDraggable();
                setDraggableTickdown();
            }
        }

        if (draggable)
        {
            // TODO show draggable sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.red;
        } else
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
            // TODO show non draggable sprite(s)
        }


    }

    private void FixedUpdate()
    {
        if (!draggable)
        {
            draggableTickdown--;
        }
    }

    IEnumerator Draggable()
    {
        draggable = true;
        dragAndDrop.active = true;
        yield return new WaitForSeconds(draggableDuration == -1 ? Random.Range(1, 5) : draggableDuration);
        draggable = false;
        dragAndDrop.active = false;
    }

    private void setDraggableTickdown()
    {
        // tickdown is inverse of rarity factor * 1000
        draggableTickdown = (int) (1/draggableRarity * 100);
    }

    private void rollDraggable()
    {
        // try random function 
        if(Random.value <= draggableProbability)
        {
            // Success
            StartCoroutine(Draggable());
        }
    }
}
