using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanInfo : MonoBehaviour
{
 
    public Vector3 canPosition;
    public Vector3 canRotation;
    public float timer = 0;
    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        canPosition = transform.position;
        canRotation = transform.eulerAngles;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            flag= true;
        }

        else
        {
            flag = false;
            timer= 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ball" && flag)
        {
            CanManager.instance.resetPosition();
        }
    }

}
