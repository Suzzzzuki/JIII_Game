using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //UI
    public Text Find;
    public Image Bag;
    public Image Chair;
    public Image Draw;
    public Image Laptop;
    public GameObject Panel;
    public Image BagS;
    public Image ChairS;
    public Image DrawS;
    public Image LaptopS;
    public GameObject PanelS;
    public float startTime;
    float LoadTime;
    Color32 panelColor;
    Color32 panelColorS;
    bool isStart = false;
    // Game
    bool Obj01 = false;
    bool Obj02 = false;
    bool Obj03 = false;
    bool Obj04 = false;

    private GameObject Object01;
    private GameObject Object02;
    private GameObject Object03;
    private GameObject Object04;
    private GameObject Gate;
    // Start is called before the first frame update
    void Start()
    {
        // For UI elements
        Find.enabled = true;
        Bag.enabled = true;
        Draw.enabled = true;
        Chair.enabled = true;
        Laptop.enabled = true;
        BagS.enabled = false;
        DrawS.enabled = false;
        ChairS.enabled = false;
        LaptopS.enabled = false;
        
        panelColor = Panel.GetComponent<Image>().color;
        LoadTime = 0;
        // For Game elements
        Object01 = GameObject.Find("Object01");
        Object02 = GameObject.Find("Object02");
        Object03 = GameObject.Find("Object03");
        Object04 = GameObject.Find("Object04");
        Gate = GameObject.Find("Gate");
    }

    // Update is called once per frame
    void Update()
    {
        //for UI
        LoadTime += Time.deltaTime;
        if(!isStart && LoadTime - startTime > 3.0f){
            Find.enabled = false;
            Bag.enabled = false;
            Draw.enabled = false;
            Chair.enabled = false;
            Laptop.enabled = false;
            BagS.enabled = true;
            DrawS.enabled = true;
            ChairS.enabled = true;
            LaptopS.enabled = true;
            if(panelColor.a >= 5){
                panelColor.a -= 2;
                Panel.GetComponent<Image>().color = panelColor;
            }
        }
    }

    public void OnCollisionEnter(Collision colinfo){
        if (colinfo.gameObject.name.Equals("Object01")){
            Obj01 = true;
            Destroy(Object01);
            Destroy(LaptopS);
        }
        if (colinfo.gameObject.name.Equals("Object02")){
            Obj02 = true;
            Destroy(Object02);
            Destroy(DrawS);
        }
        if (colinfo.gameObject.name.Equals("Object03")){
            Obj03 = true;
            Destroy(Object03);
            Destroy(BagS);
        }
        if (colinfo.gameObject.name.Equals("Object04")){
            Obj04 = true;
            Destroy(Object04);
            Destroy(ChairS);
        }

        if (Obj01 == true && Obj02 == true && Obj03 == true && Obj04 == true){
            Destroy(Gate);
            Debug.Log("Congrats");
        }
    }
}
