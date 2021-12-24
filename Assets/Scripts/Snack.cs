using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    public int snackBites = 5;
    public float timeToEatBite = 0.25f;
    public int biteValue = 1;
    private int snackMaxBites;

    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    public Rat rat;

    private DragAndDrop dragAndDrop;
    private IMovement movement;

    private bool dragging = false;

    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {

        //rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        snackMaxBites = snackBites;

        dragAndDrop = GetComponent<DragAndDrop>();
        movement = GetComponent<IMovement>();

        

    }

    // Update is called once per frame
    void Update()
    {
       
        movement.Step();

        if(snackBites <= 0)
        {
            Delete(DestroyType.ate);
        }
        //spriteRenderer.sprite = spriteArray[snackBites * spriteArray.Length / snackMaxBites];
        int spriteIndex = (snackBites * spriteArray.Length / snackMaxBites) - 1;
        if(spriteIndex >= 0)
        {
            spriteRenderer.sprite = spriteArray[spriteIndex];
        }

        // if dragAndDrop script detects change in dragAllowed variable update snack variable and disable movement script
        bool dragUpdated = dragAndDrop.GetDragging();
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
            rat.GrabSnack(gameObject);
            DisableMovement();
            elapsed += Time.fixedDeltaTime;
            if (elapsed > timeToEatBite)
            {
                if (rat.FeedRat(biteValue))
                {
                    snackBites--;
                }
                elapsed = 0;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rat")
        {
            EnableMovement();
            elapsed = 0;
        }
    }

    public void Delete(DestroyType destroyType)
    {
        Destroy(gameObject);
    }

    public void DisableMovement()
    {
        movement.canMove = false;
    }

    public void EnableMovement()
    {
        movement.canMove = true;
    }
}
