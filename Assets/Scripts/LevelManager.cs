using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelTimer levelTimer;
    public Rat rat;



    public float timeScale = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rat.isFull())
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        Time.timeScale = timeScale;
    }

    
    public void Pause()
    {
        // Toggle timescale
        timeScale = timeScale > 0 ? 0 : 1;
    }
}
