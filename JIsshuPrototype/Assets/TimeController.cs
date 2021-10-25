using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    private TextMeshProUGUI Timetxt;
    private float sec;
    private float min;
    float LoadTime;
    float StartTime;
    // Start is called before the first frame update
    void Start()
    {
        Timetxt = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();

        LoadTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LoadTime += Time.deltaTime;
        //Stage01の説明時間分タイマーの開始時間をずらす
        if(LoadTime - StartTime > 5.0){
            
            sec += Time.deltaTime; //TimerCount

            //以下秒数と分で表示を分ける処理
            if (sec > 60){
                min += 1;
                sec = 0;
            }

            Timetxt.text = min.ToString("00") + ":" + sec.ToString("00");
        }
    }
}
