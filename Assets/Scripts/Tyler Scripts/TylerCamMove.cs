using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TylerCamMove : MonoBehaviour
{
   
   private bool zooming = false;
    void Start()
    {
        
       GetComponent<Rigidbody>().velocity = new Vector3(0,0,12); 
    }

    // Update is called once per frame
    void Update()
    {
        if(TylerMovementScript.slowed&&!zooming){
          zooming = true;
          StartCoroutine(zoomCam());
        }
        if(TylerMovementScript.descending){
        GetComponent<Rigidbody>().velocity = new Vector3(0,-8,12)*TylerMovementScript.acceleration; 
        if(GameObject.Find("PlayerCharacter").transform.position.z > TylerGameFlow.subwayCoord+10){

        GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
        GetComponent<Camera>().backgroundColor = Color.black;
        }
        }else if(TylerMovementScript.ascending){
        GetComponent<Rigidbody>().velocity = new Vector3(0,7,12)*TylerMovementScript.acceleration; 
         GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
        GetComponent<Camera>().backgroundColor = new Color32(0,49,77,121);
        
        } else if(!zooming) {
         GetComponent<Rigidbody>().velocity = new Vector3(0,0,12*TylerMovementScript.acceleration); 
         if(!TylerMovementScript.descented&&!TylerMovementScript.ascending)
         this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 4.5f, GameObject.Find("PlayerCharacter").transform.position.z -4.5f );
        }
    }
public IEnumerator Wait(float delayInSecs)
 {
   yield return new WaitForSeconds(delayInSecs);
 }
private IEnumerator zoomCam(){
     GetComponent<Rigidbody>().velocity = new Vector3(0,-1.6f,14)*TylerMovementScript.acceleration;
     yield return new WaitForSecondsRealtime(1.5f);
     GetComponent<Rigidbody>().velocity = new Vector3(0,0,12)*TylerMovementScript.acceleration;
     yield return new WaitForSecondsRealtime(5);
     GetComponent<Rigidbody>().velocity = new Vector3(0,1.6f,10.32f)*TylerMovementScript.acceleration;
     yield return new WaitForSecondsRealtime(1.5f);
     GetComponent<Rigidbody>().velocity = new Vector3(0,0,12)*TylerMovementScript.acceleration;
     zooming = false;
}
}
