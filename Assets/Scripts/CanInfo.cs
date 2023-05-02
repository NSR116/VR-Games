using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanInfo : MonoBehaviour
{
    private Vector3 canPosition;
    private Vector3 canRotation;

    // Start is called before the first frame update
    void Start()
    {
        canPosition = transform.position;
        canRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
