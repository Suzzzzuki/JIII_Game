using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageOneUI : MonoBehaviour
{
    public Text Find;
    public Image Bag;
    public Image Chair;
    public Image Draw;
    public Image Laptop;
    public GameObject Panel;
    public float startTime;
    Color32 panelColor;
    bool isStart = false;

    // Start is called before the first frame update
    void Start()
    {
        Find.enabled = true;
        Bag.enabled = true;
        Draw.enabled = true;
        Chair.enabled = true;
        Laptop.enabled = true;
        panelColor = Panel.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStart && Time.time - startTime > 3.0f){
            Find.enabled = false;
            Bag.enabled = false;
            Draw.enabled = false;
            Chair.enabled = false;
            Laptop.enabled = false;
            if(panelColor.a >= 5){
                panelColor.a -= 2;
                Panel.GetComponent<Image>().color = panelColor;
            }
        }
    }
}
