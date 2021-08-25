using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
    public void VibratePhone()
    { Handheld.Vibrate();
        Debug.Log("VIBRATE");
    }
}
