using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomMovement : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    Vector2 targetPosition;

    public float speed;

    public bool waits;
    private bool waiting;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {

            if ((Vector2)transform.position != targetPosition)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = GetRandomPosition();
                StartCoroutine(Wait());
            }
        }
    }

    IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(GetRandomPauseTime());
        waiting = false;
    }

    float GetRandomPauseTime()
    {
        float time = Random.Range(0.5f, 2f);
        return time;
    }


    Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

}
