using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F5)){
            cam.transform.position = new Vector3(0, 1.5f, -0.8f);
        }
        if (Input.GetKey(KeyCode.F6)){
            cam.transform.position = new Vector3(0, 1.5f, 0.24f);
        }
    }
}
