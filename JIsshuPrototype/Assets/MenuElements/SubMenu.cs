using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour
{
    public GameObject theSub;
    public Vector2 moveInput;
    public Text[] options;
    public Color normalColor, highlightedColor;
    public int selectedOption;
    public GameObject highlightBlock;
    float Interval = 0;
    public GameObject BoxL;
    public GameObject BoxM;
    public GameObject BoxS;
    public GameObject BoxSS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(theSub.activeInHierarchy == true){
            Interval += Time.deltaTime;
        }
        //マウスの位置と中心からの角度特定
        if(theSub.activeInHierarchy)
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
                Debug.Log(angle);

                //メニューの項目割り当て
                for(int i = 0; i < options.Length; i++){
                    if(angle > i * 90 && angle < (i + 1) * 90)
                    {
                        options[i].color = highlightedColor;
                        selectedOption = i;

                        highlightBlock.transform.rotation = Quaternion.Euler(0, 0, i * -90);
                        //Debug.Log("section" + i);
                    }
                    else
                    {
                        options[i].color = normalColor;
                    }
                }
            }
            
            //クリックしたとき
            if(Interval >= 1 && Input.GetMouseButton(0))
            {
                theSub.SetActive(false);
                Interval = 0;

                switch(selectedOption)
                {
                    case 0:
                        switchL();
                        break;

                    case 1:
                        switchM();
                        break;
                    
                    case 2:
                        switchS();
                        break;

                    case 3:
                        switchSS();
                        break;
                }
            }
        }
    }

    public void switchL()
    {
        //BoxLを出す動作
        
    }

    public void switchM()
    {
        //BoxMを出す動作
    }

    public void switchS()
    {
        //BoxSを出す動作
    }

    public void switchSS()
    {
        //BoxSSを出す動作
    }
}
