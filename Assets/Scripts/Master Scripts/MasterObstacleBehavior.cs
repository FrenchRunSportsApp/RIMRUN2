using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterObstacleBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform businessPersonObj;
    public Transform catObj;
    private bool catMoving = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag == "BusinessPerson"&& this.transform.position.z > 0){
            if(this.transform.position.z-70 <= GameObject.Find("PlayerCharacter").transform.position.z){
                StartCoroutine(personMove());
            }
        } else if(this.tag == "Cat"&& this.transform.position.z > 0){
            if(GameObject.Find("PlayerCharacter").transform.position.z+30 >= this.transform.position.z&&!catMoving){
                catMoving = true;
                StartCoroutine(catMove());
            }
        }
    }

    private IEnumerator catMove(){
        if(this.transform.position.x == 7){
        GetComponent<Rigidbody>().velocity = new Vector3(-8*MasterMovementScript.acceleration,0,0);
        yield return new WaitForSeconds(.5f/MasterMovementScript.acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-9*MasterMovementScript.acceleration);
        yield return new WaitForSeconds(.5f/MasterMovementScript.acceleration);
        Destroy(this);
        } else {
        GetComponent<Rigidbody>().velocity = new Vector3(8*MasterMovementScript.acceleration,0,0);
        yield return new WaitForSeconds(.5f/MasterMovementScript.acceleration);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-9*MasterMovementScript.acceleration);
        yield return new WaitForSeconds(.5f/MasterMovementScript.acceleration);
        Destroy(this);
        }
    }

    private IEnumerator personMove(){
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-10*MasterMovementScript.acceleration);
        yield return new WaitForSeconds(5);
        Destroy(this);
    }
}
