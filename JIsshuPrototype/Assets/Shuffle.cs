using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    ArrayList StageList = new ArrayList();
    ArrayList StagePosList = new ArrayList();
    ArrayList StageRotList = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        //Add stage to arrayList
        StageList.Add(GameObject.Find("Side01"));
        StageList.Add(GameObject.Find("Side02"));
        StageList.Add(GameObject.Find("Side03"));
        StageList.Add(GameObject.Find("Side04"));
        StagePosList.Add(new Vector3(10, 0 ,0));
        StagePosList.Add(new Vector3(20, 0 ,0));
        StagePosList.Add(new Vector3(-10, 0 ,0));
        StagePosList.Add(new Vector3(-20, 0 ,0));
        StageRotList.Add(Quaternion.Euler(0,0,0));
        StageRotList.Add(Quaternion.Euler(0,180,0));

        for(int i = 0; i < 4; i++){
            GameObject targetObj = (GameObject)StageList[0];
            int selectPosNum = Random.Range(0,StageList.Count);
            int selectRotNum = Random.Range(0,2);

            targetObj.transform.SetPositionAndRotation(
                (Vector3)StagePosList[selectPosNum], (Quaternion)StageRotList[selectRotNum]
            );
            
            StageList.RemoveAt(0);
            StagePosList.RemoveAt(selectPosNum);
        }
    }
}
