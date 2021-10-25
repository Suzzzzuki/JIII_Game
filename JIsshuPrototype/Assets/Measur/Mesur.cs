using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesur : MonoBehaviour
{
    private GameObject M1;
    private GameObject M2;
    private float d = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        M1 = GameObject.Find("MeasurePoint01");
        M2 = GameObject.Find("MeasurePoint02");

        Vector3 pos1 = M1.transform.position;
        Vector3 pos2 = M2.transform.position;
        d = Vector3.Distance(pos1, pos2);

        Debug.Log("Distance: "+ d + "m");

        if(M1 == null || M2 == null){
            Debug.Log("null");
        }

    }
}
