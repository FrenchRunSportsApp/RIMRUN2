using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] public float baseEdgeSize;
    [SerializeField] public float waveRange;
    [SerializeField] public float waveSpeed;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Create a new edge size value and set it
        //in the shader
        float edgeSize = Mathf.PingPong(Time.time * waveSpeed, waveRange) + baseEdgeSize;
        renderer.material.SetFloat("_EdgeSize", edgeSize);
    }
}
