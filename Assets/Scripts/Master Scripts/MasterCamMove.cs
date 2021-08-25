using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterCamMove : MonoBehaviour
{
   private bool zooming = false;
    void Start()
    {
        
       GetComponent<Rigidbody>().velocity = new Vector3(0,0,12); 
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterMovementScript.slowed&&!zooming){
          zooming = true;
          StartCoroutine(zoomCam());
        }
        if(MasterMovementScript.descending){
        GetComponent<Rigidbody>().velocity = new Vector3(0,-8,12)*MasterMovementScript.acceleration; 
        } else if(!zooming) {
         GetComponent<Rigidbody>().velocity = new Vector3(0,0,12*MasterMovementScript.acceleration); 
        }
    }

private IEnumerator zoomCam(){
     GetComponent<Rigidbody>().velocity = new Vector3(0,-1.5f,14)*MasterMovementScript.acceleration;
     yield return new WaitForSecondsRealtime(1.5f);
     GetComponent<Rigidbody>().velocity = new Vector3(0,0,12)*MasterMovementScript.acceleration;
     yield return new WaitForSecondsRealtime(3);
     GetComponent<Rigidbody>().velocity = new Vector3(0,1.5f,10.32f)*MasterMovementScript.acceleration;
     yield return new WaitForSecondsRealtime(1.5f);
     GetComponent<Rigidbody>().velocity = new Vector3(0,0,12)*MasterMovementScript.acceleration;
     zooming = false;
}
}
