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
    // Start is called before the first frame update
    void Start()
    {
        Timetxt = GameObject.Find("Time").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        sec += Time.deltaTime;
        if (sec > 60){
            min += 1;
            sec = 0;
        }

        Timetxt.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
