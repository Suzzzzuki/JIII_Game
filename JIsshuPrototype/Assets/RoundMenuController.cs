using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundMenuController : MonoBehaviour
{
    public GameObject theMenu;
    public Vector2 moveInput;
    public Text[] options;
    public Color normalColor, highlightedColor;
    public int selectedOption;
    public GameObject highlightBlock;
    bool MainMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        theMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Rを入力すると表示/非表示される
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(MainMenu == false)
            {
                theMenu.SetActive(true);
                MainMenu = true;
            }
            else
            {
                theMenu.SetActive(false);
                MainMenu = false;
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


    }

    public void switchObject()
    {
        //objectの動作を書き込む
    }

    public void switchMeasure()
    {
        //measureの動作を書き込む
    }
}
