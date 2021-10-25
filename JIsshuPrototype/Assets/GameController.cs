using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
    // Stage03
    bool W01 = false;
    bool W02 = false;
    bool W04 = false;

    private GameObject Wood01;
    private GameObject Wood02;
    private GameObject Wood04;
    private GameObject Gate03;
    //UI03
    public GameObject Panel3;
    private GameObject Center03F;
    public Image Wood1;
    public Image Wood2;
    public Image Wood4;
    public GameObject PanelS3;
    bool isThird;
    float ThirdCount;

    //Timecontroller
    private TextMeshProUGUI Timetxt;
    public static float sec;
    public static float min;
    float LoadingTime;
    private GameObject ClearF;
    bool Stop =false;
    
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

        // For UI03
        Panel3.SetActive(false);
        PanelS3.SetActive(false);
        Wood1.enabled = false;
        Wood2.enabled = false;
        Wood4.enabled = false;
        isStart = true;
        ThirdCount = 0;
        Center03F = GameObject.Find("Center03F");

        // For Stage03
        Wood01 = GameObject.Find("Bingo01");
        Wood02 = GameObject.Find("Bingo02");
        Wood04 = GameObject.Find("Bingo04");
        Gate03 = GameObject.Find("Gate3");

        //Timecontroller
        Timetxt = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
        ClearF = GameObject.Find("ClearF");
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

        //for UI03
        if(isThird == true && LoadTime - startTime > 5.0f){
            Panel3.SetActive(false);
            if(Wood1 != null){
                Wood1.enabled = true;
            }
            if(Wood2 != null){
                Wood2.enabled = true;
            }
            if(Wood4 != null){
                Wood4.enabled = true;
            }
            PanelS3.SetActive(true);
            isThird = false;
            ThirdCount = 1;

        }

        //Timecontroller
        LoadTime += Time.deltaTime;
        //Stage01の説明時間分タイマーの開始時間をずらす
        if(LoadTime - startTime > 5.0){

            if(Stop == false){
                sec += Time.deltaTime; //TimerCount
            }

            //以下秒数と分で表示を分ける処理
            if (sec > 60){
                min += 1;
                sec = 0;
            }

            Timetxt.text = min.ToString("00") + ":" + sec.ToString("00");
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

        //for UI3
        if (colinfo.gameObject.name.Equals("Center03F")){
            if(ThirdCount == 0){
                Panel3.SetActive(true);
                LoadTime = 0;
                isThird = true;
            }
        }

        //for UI3 & Stage3
        if(colinfo.gameObject.tag == "Wrong"){
            sec +=30;
            Destroy(colinfo.gameObject);
        }
        if(colinfo.gameObject.tag == "Bingo1"){
            W01 = true;
            Destroy(Wood01);
            Destroy(Wood1);
        }
        if(colinfo.gameObject.tag == "Bingo2"){
            W02 = true;
            Destroy(Wood02);
            Destroy(Wood2);
        }
        if(colinfo.gameObject.tag == "Bingo3"){
            W04 = true;
            Destroy(Wood04);
            Destroy(Wood4);
        }
        if (W01 == true && W02 == true && W04 == true){
            Destroy(Gate03);
            PanelS3.SetActive(false);
        }

        //TimeController
        if(colinfo.gameObject.name.Equals("ClearF")){
            Stop = true;
            SceneManager.LoadScene("EndScene");
        }
    }
}
