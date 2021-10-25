using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //UI01
    public GameObject Panel;
    public Image BagS;
    public Image ChairS;
    public Image DrawS;
    public Image LaptopS;
    public GameObject PanelS;
    public float startTime;
    float LoadTime;
    Color32 panelColor;
    bool isStart = false;
    // Stage01
    bool Obj01 = false;
    bool Obj02 = false;
    bool Obj03 = false;
    bool Obj04 = false;

    private GameObject Object01;
    private GameObject Object02;
    private GameObject Object03;
    private GameObject Object04;
    private GameObject Gate;
    //UI02
    public GameObject PanelS2;
    private GameObject Center02F;
    bool isSecond = false;
    float SecondCount;
    // Start is called before the first frame update
    void Start()
    {
        // For UI01
        Panel.SetActive(true);
        BagS.enabled = false;
        DrawS.enabled = false;
        ChairS.enabled = false;
        LaptopS.enabled = false;
        isStart = true;
        
        panelColor = Panel.GetComponent<Image>().color;
        LoadTime = 0;
        // For Stage01
        Object01 = GameObject.Find("Object01");
        Object02 = GameObject.Find("Object02");
        Object03 = GameObject.Find("Object03");
        Object04 = GameObject.Find("Object04");
        Gate = GameObject.Find("Gate");

        // For UI02
        PanelS2.SetActive(false);
        SecondCount = 0;
        Center02F = GameObject.Find("Center02F");
    }

    // Update is called once per frame
    void Update()
    {
        //for UI01
        LoadTime += Time.deltaTime;
        if(isStart == true && LoadTime - startTime > 5.0f){
            if(BagS != null){
                BagS.enabled = true;
            }
            if(DrawS != null){
                DrawS.enabled = true;
            }
            if(ChairS != null){
                ChairS.enabled = true;
            }
            if(LaptopS != null){
                LaptopS.enabled = true;
            }
            Panel.SetActive(false);
            isStart = false;
        }

        //for UI02
        if(isSecond == true && LoadTime - startTime > 5.0f){
            PanelS2.SetActive(false);
            isSecond = false;
            SecondCount = 1;
        }
    }

    public void OnCollisionEnter(Collision colinfo){

        //for Stage01 & UI01

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
            PanelS.SetActive(false);
        }

        //for UI2
        if (colinfo.gameObject.name.Equals("Center02F")){
            if(SecondCount == 0){
                PanelS2.SetActive(true);
                LoadTime = 0;
                isSecond = true;
            }
        }
    }
}
