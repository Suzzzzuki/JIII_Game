using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoThird : MonoBehaviour
{
    private GameObject G1;
    private GameObject G2;
    // Start is called before the first frame update
    void Start()
    {
        G1 = GameObject.Find("G1");
        G2 = GameObject.Find("G2");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F3)){
            Destroy(G1);
            Destroy(G2);
        }
    }
}
