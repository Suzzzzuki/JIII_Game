using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    bool Obj01 = false;
    bool Obj02 = false;
    bool Obj03 = false;
    bool Obj04 = false;

    private GameObject Object01;
    private GameObject Object02;
    private GameObject Object03;
    private GameObject Object04;
    private GameObject Gate;
    // Start is called before the first frame update
    void Start()
    {
        Object01 = GameObject.Find("Object01");
        Object02 = GameObject.Find("Object02");
        Object03 = GameObject.Find("Object03");
        Object04 = GameObject.Find("Object04");
        Gate = GameObject.Find("Gate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision colinfo){
        if (colinfo.gameObject.name.Equals("Object01")){
            Obj01 = true;
            Destroy(Object01);
            Debug.Log("OBJ01");
        }
        if (colinfo.gameObject.name.Equals("Object02")){
            Obj02 = true;
            Destroy(Object02);
            Debug.Log("OBJ02");
        }
        if (colinfo.gameObject.name.Equals("Object03")){
            Obj03 = true;
            Destroy(Object03);
            Debug.Log("OBJ03");
        }
        if (colinfo.gameObject.name.Equals("Object04")){
            Obj04 = true;
            Destroy(Object04);
            Debug.Log("OBJ04");
        }

        if (Obj01 == true && Obj02 == true && Obj03 == true && Obj04 == true){
            Destroy(Gate);
            Debug.Log("Congrats");
        }
    }
}
