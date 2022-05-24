using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Transforms object by 3 vectors (x,y,z) in relation to the object
        // Rotates based on frames
        transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.Self);
    }
}
