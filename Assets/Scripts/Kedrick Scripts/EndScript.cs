using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    public KedrickGameFlow gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            gameManager.CompleteLevel();
        }
    }
}
