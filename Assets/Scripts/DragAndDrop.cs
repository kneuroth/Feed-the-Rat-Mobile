using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool active;
    bool dragAllowed;
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                    if (col == touchedCollider)
                    {
                        SetDragAllowed(true);
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    if (GetDragAllowed() == true)
                    {
                        transform.position = new Vector2(touchPosition.x, touchPosition.y);
                    }
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    SetDragAllowed(false);
                }
            }
        }

    }


    void SetDragAllowed(bool allow)
    {
        dragAllowed = allow;
    }
     
    // True if finger is on the game object, false if not
    public bool GetDragAllowed()
    {
        return dragAllowed;
    }
}
