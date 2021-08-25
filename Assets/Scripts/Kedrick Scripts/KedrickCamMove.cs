using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KedrickCamMove : MonoBehaviour
{

    private bool zooming = false;
    void Start()
    {

        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12);
    }

    // Update is called once per frame
    void Update()
    {
        if (KedrickMovementScript.slowed && !zooming)
        {
            zooming = true;
            StartCoroutine(zoomCam());
        }
        if (KedrickMovementScript.descending)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, -8, 12) * KedrickMovementScript.acceleration;
            if (GameObject.Find("PlayerCharacter 1").transform.position.z > KedrickGameFlow.subwayCoord + 10)
            {

                GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
                GetComponent<Camera>().backgroundColor = Color.black;
            }
        }
        else if (KedrickMovementScript.ascending)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 7, 12) * KedrickMovementScript.acceleration;
            GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
            GetComponent<Camera>().backgroundColor = new Color32(0, 49, 77, 121);

        }
        else if (!zooming)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12 * KedrickMovementScript.acceleration);
            if (!KedrickMovementScript.descented && !KedrickMovementScript.ascending)
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, 4.5f, GameObject.Find("PlayerCharacter 1").transform.position.z - 4.5f);
        }
    }
    public IEnumerator Wait(float delayInSecs)
    {
        yield return new WaitForSeconds(delayInSecs);
    }
    private IEnumerator zoomCam()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, -1.3f, 14) * KedrickMovementScript.acceleration;
        yield return new WaitForSecondsRealtime(1.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12) * KedrickMovementScript.acceleration;
        yield return new WaitForSecondsRealtime(5);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 1.3f, 10.32f) * KedrickMovementScript.acceleration;
        yield return new WaitForSecondsRealtime(1.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 12) * KedrickMovementScript.acceleration;
        zooming = false;
    }
}
