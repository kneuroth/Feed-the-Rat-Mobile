using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    public int snackProgress = 100;
    private int snackMaxProgress;

    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Rat rat;


    private DragAndDrop dragAndDrop;
    private IMovement movement;

    private bool dragging = false;

    // Start is called before the first frame update
    void Start()
    {

        //rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        snackMaxProgress = snackProgress;

        dragAndDrop = GetComponent<DragAndDrop>();
        movement = GetComponent<IMovement>();

        

    }

    // Update is called once per frame
    void Update()
    {

        if (movement.canMove)
        {
            movement.Step();
        }

        if(snackProgress <= 0)
        {
            Destroy(gameObject);
        }
        //spriteRenderer.sprite = spriteArray[snackProgress * spriteArray.Length / snackMaxProgress];
        int spriteIndex = (snackProgress * spriteArray.Length / snackMaxProgress) - 1;
        if(spriteIndex >= 0)
        {
            spriteRenderer.sprite = spriteArray[spriteIndex];
        }

        // if dragAndDrop script detects change in dragAllowed variable update snack variable and disable movement script
        bool dragUpdated = dragAndDrop.GetDragAllowed();
        if (dragging != dragUpdated)
        {
            dragging = dragUpdated;
            movement.canMove = !dragging;
        }

        // if it was just released
        if (dragAndDrop.GetLetGo())
        {
            dragAndDrop.SetLetGo(false);
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Rat")
        {
            //Debug.Log("colllide");
            snackProgress--;
            rat.FeedRat();
        }
    }
}
