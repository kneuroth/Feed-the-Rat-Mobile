using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour
{

    public int snackProgress = 100;
    private int snackMaxProgress;

    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        snackMaxProgress = snackProgress;
    }

    // Update is called once per frame
    void Update()
    {

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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Rat")
        {
            Debug.Log("colllide");
            snackProgress--;
        }
    }
}
