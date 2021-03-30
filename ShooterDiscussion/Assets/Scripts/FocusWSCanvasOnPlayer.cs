using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusWSCanvasOnPlayer : MonoBehaviour
{
    Transform camTransform;

    void Start()
    {
        camTransform = Camera.main.transform;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camTransform);
    }
}
