using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private GameObject Object01;
    private GameObject Object02;
    private GameObject Object03;
    private GameObject Object04;
    // Start is called before the first frame update
    void Start()
    {
        Object01 = GameObject.Find("Object01");
        Object02 = GameObject.Find("Object02");
        Object03 = GameObject.Find("Object03");
        Object04 = GameObject.Find("Object04");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F1)){
            Object01.transform.position = new Vector3(-1.5f, 0.5f, 2f);
            Object02.transform.position = new Vector3(-3.5f, 0.5f, 2f);
            Object03.transform.position = new Vector3(1.5f, 0.5f, 2f);
            Object04.transform.position = new Vector3(3.5f, 0.5f, 2f);
        }
    }
}
