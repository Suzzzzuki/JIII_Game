using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Rigidbody rb;
    bool isPosSet = false;
    Quaternion startQur;
    public int a;
    // Start is called before the first frame update
    void Start()
    {
        startQur = this.transform.rotation;
        rb = this.transform.GetComponent<Rigidbody>();
        a = Random.Range(0,2);
        if (a == 0){
            this.transform.position = new Vector3(Random.Range(-25,-5), 5, Random.Range(-5,5));
        }
        else{
            this.transform.position = new Vector3(Random.Range(5,25), 5, Random.Range(-5,5));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPosSet && rb.IsSleeping() || this.transform.position.y<0){
            if(this.transform.position.y < 2 && this.transform.position.y > 0 ){
                this.transform.rotation = startQur;
            }
            else{
                a = Random.Range(0,2);
                if (a == 0){
                    this.transform.position = new Vector3(Random.Range(-25,-5), 5, Random.Range(-5,5));
                }
                else{
                    this.transform.position = new Vector3(Random.Range(5,25), 5, Random.Range(-5,5));
                }
            }
        }
    }
}
