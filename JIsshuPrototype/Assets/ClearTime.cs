using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    private Text Timetxt;
    // Start is called before the first frame update
    void Start()
    {
        Timetxt = GameObject.Find("clearTime").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Timetxt.text = GameController.min.ToString("00") +":"+ GameController.sec.ToString("00");
    }
}
