using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stomach : MonoBehaviour
{
    private Image image;
    public Sprite[] spriteArray;
    public Hunger ratHunger;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int fullPercent = (int)ratHunger.fullPercent() / 100;
        Debug.Log(((fullPercent - (fullPercent % 10)) / 10));
        //Debug.Log(((fullPercent - (fullPercent % 10)) / 10) - 1);
        image.sprite = spriteArray[((fullPercent - (fullPercent%10)) / 10)];
    }
}
