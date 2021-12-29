using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    public int snackBites = 5;
    public float timeToEatBite = 0.25f;
    public int biteValue = 1;
    private int snackMaxBites;

    public int animationFrames = 5;
    public Animator animator;

    private DragAndDrop dragAndDrop;
    private IMovement movement;

    private bool dragging = false;

    private float elapsed;

    private bool resetDragAndDrop = false;


    // Start is called before the first frame update
    void Start()
    {

        snackMaxBites = snackBites;

        dragAndDrop = GetComponent<DragAndDrop>();
        movement = GetComponent<IMovement>();

        

    }

    // Update is called once per frame
    void Update()
    {
       
        //if(movement != null)
        //{
        //    movement.Step();
        //}

        if(snackBites <= 0)
        {
            Delete(DestroyType.ate);
        }
        //spriteRenderer.sprite = spriteArray[snackBites * spriteArray.Length / snackMaxBites];
        int snackProgress = (snackBites * animationFrames / snackMaxBites) - 1;
        if(snackProgress >= 0)
        {
            //spriteRenderer.sprite = spriteArray[spriteIndex];
            animator.SetInteger("snackProgress", snackProgress);
        }

        // if dragAndDrop script detects change in dragAllowed variable update snack variable and disable movement script
        bool dragUpdated = dragAndDrop.GetDragging();
        if (dragging != dragUpdated)
        {
            dragging = dragUpdated;
            if(movement != null)
            {


                movement.canMove = !dragging;
            }
        }

        // if it was just released
        if (dragAndDrop.GetLetGo())
        {
            dragAndDrop.SetLetGo(false);
        }

        if (resetDragAndDrop)
        {
            resetDragAndDrop = false;
        }
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rat")
        {
            Rat rat = collision.GetComponent<Rat>();
            if (rat.GrabSnack(gameObject))
            {
                dragAndDrop.active = false;
            }
        }
        if (collision.tag == "Grater")
        {
            Delete(DestroyType.grater);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Rat")
        {
            Rat rat = collision.GetComponent<Rat>();
            if (rat.IsHolding(gameObject))
            {

                DisableMovement();
                Teleport(rat.eatingTransform);
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
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Rat")
        {
            Rat rat = collision.GetComponent<Rat>();
            rat.LetGoSnack(gameObject);
            EnableMovement();
            elapsed = 0;
        }
    }

    public void Delete(DestroyType destroyType)
    {
        float waitTime = 0f;
        if(destroyType == DestroyType.grater)
        {
            waitTime = .5f;
            animator.SetBool("isShredding", true);
        }

        StartCoroutine(WaitForDeathAnimation(waitTime));

    }

    public void DisableMovement()
    {
        if (movement != null)
        {
            movement.canMove = false;
        }
    }

    public void EnableMovement()
    {
        if(movement != null)
        {
            movement.canMove = true;
        }
    }

    public void Teleport(Transform trans)
    {
        transform.position = trans.position;
        transform.parent = trans;
    }

    IEnumerator WaitForDeathAnimation(float ms)
    {
        yield return new WaitForSeconds(ms);
        Destroy(gameObject);
    }
}
