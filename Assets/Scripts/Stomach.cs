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
        int fullPercent = ratHunger.fullPercent();
        int fullLevel = fullPercent / 10 > 0 ? fullPercent / 10 - 1 : 0;

        image.sprite =  spriteArray[fullLevel];
    }
}
