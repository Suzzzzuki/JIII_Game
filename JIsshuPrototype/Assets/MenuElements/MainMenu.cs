using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject theMenu;
    public Vector2 moveInput;
    public Text[] options;
    public Color normalColor, highlightedColor;
    public int selectedOption;
    public GameObject highlightBlock;
    bool mainMenu = false;
    public GameObject ObjMenu;

    //for measure
    public GameObject P1prefab;
    public GameObject P2prefab;
    GameObject P1;
    GameObject P2;
    bool pointer = false;
    bool M1 = false;
    bool M2 = false;
    bool measure = false;
    private float d = 0;
    private Text MeasureText;
    // Start is called before the first frame update
    void Start()
    {
        theMenu.SetActive(false);
        ObjMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Rを入力すると表示/非表示される
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(mainMenu == false)
            {
                theMenu.SetActive(true);
                mainMenu = true;
            }
            else
            {
                theMenu.SetActive(false);
                mainMenu = false;
            }
        }

        //マウスの位置と中心からの角度特定
        if(theMenu.activeInHierarchy)
        {
            moveInput.x = Input.mousePosition.x - (Screen.width / 2f);
            moveInput.y = Input.mousePosition.y - (Screen.height / 2f);
            moveInput.Normalize();

            if(moveInput != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveInput.y, -moveInput.x) / Mathf.PI;
                angle *= 180;
                if(angle < 0)
                {
                    angle += 360;
                }

                //メニューの項目割り当て
                for(int i = 0; i < options.Length; i++){
                    if(angle > i * 180 && angle < (i + 1) * 180)
                    {
                        options[i].color = highlightedColor;
                        selectedOption = i;

                        highlightBlock.transform.rotation = Quaternion.Euler(0, 0, i * 180);
                    }
                    else
                    {
                        options[i].color = normalColor;
                    }
                }
            }
            
            //クリックしたとき
            if(Input.GetMouseButton(0))
            {
                theMenu.SetActive(false);

                switch(selectedOption)
                {
                    case 0:
                        switchObject();
                        break;

                    case 1:
                        switchMeasure();
                        break;
                }
            }
        }

        //for measure
        if(pointer == true){
            if(Input.GetKeyDown(KeyCode.P)){
                if(M1 == true && M2 == true)
                {
                    //ポイント１配置位置
                    Vector3 position = new Vector3(GameObject.Find("Player").transform.position.x*1.1f, 1, GameObject.Find("Player").transform.position.z*1.1f);
                    //ポイント１回転
                    Quaternion rot = GameObject.Find("Player").transform.rotation;
                    P1 = (GameObject)Instantiate(P1prefab, position, rot);
                    M1 = false;
                }
                else if(M1 == false && M2 == true)
                {
                    //ポイント２配置位置
                    Vector3 position = new Vector3(GameObject.Find("Player").transform.position.x*1.1f, 1, GameObject.Find("Player").transform.position.z*1.1f);
                    //ポイント２回転
                    Quaternion rot = GameObject.Find("Player").transform.rotation;
                    P2 = (GameObject)Instantiate(P2prefab, position, rot);
                    M2 = false;
                    measure = true;
                } 
                else
                {
                    measure = false;
                    Destroy(P1);
                    Destroy(P2);
                    pointer = false;
                }
            }
        }

        //measure code
        if(measure == true){
            Vector3 pos1 = P1.transform.position;
            Vector3 pos2 = P2.transform.position;
            d = Vector3.Distance(pos1, pos2);
            MeasureText = GameObject.Find("measure").GetComponent<Text>();
            MeasureText.text = d.ToString("N2") + "m";
            
        }
        else
        {
            MeasureText = GameObject.Find("measure").GetComponent<Text>();
            MeasureText.text = "";
        }
    }

    public void switchObject()
    {
        //subメニューを出す
        //SubMenu.csにてオブジェクトを出すスクリプトを書く
        ObjMenu.SetActive(true);
    }

    public void switchMeasure()
    {
        //measureの動作を書き込む
        pointer = true;
        M1 = true;
        M2 = true;
    }
}
