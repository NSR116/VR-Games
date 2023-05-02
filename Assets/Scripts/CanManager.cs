using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanManager : MonoBehaviour
{
    public static CanManager instance;
    [SerializeField] CanInfo[] cansArray = new CanInfo[6];

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }
    }

   public void resetPosition()
    {
        for(int i = 0; i< cansArray.Length; i++)
        {
            cansArray[i].transform.position = cansArray[i].canPosition;
            cansArray[i].transform.eulerAngles = cansArray[i].canRotation;
            cansArray[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
