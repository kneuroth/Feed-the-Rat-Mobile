using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    
    public TextMeshProUGUI timerText;
    private float startTime;
    // Start is called before the first frame update
 

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("00.00");
        timerText.text = minutes + ":" + seconds;
    }

    public int GetSeconds()
    {
        int t = (int) (Time.time - startTime);
        return (t % 60);
    }
}
