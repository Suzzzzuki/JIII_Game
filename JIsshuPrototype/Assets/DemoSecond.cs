using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoSecond : MonoBehaviour
{
    private GameObject ObjectL;
    private GameObject ObjectM;
    private GameObject ObjectS;
    private GameObject ObjectSS;
    // Start is called before the first frame update
    void Start()
    {
        ObjectL = GameObject.Find("ObjectL");
        ObjectM = GameObject.Find("ObjectM");
        ObjectS = GameObject.Find("ObjectS");
        ObjectSS = GameObject.Find("ObjectSS");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F2)){
            ObjectL.transform.position = new Vector3(0f, 2f, 30f);
            ObjectM.transform.position = new Vector3(0f, 2f, 27.8f);
            ObjectS.transform.position = new Vector3(0f, 2f, 26.3f);
            ObjectSS.transform.position = new Vector3(0f, 2f, 25.3f);
        }
    }
}
