using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateXR.Manipulation;
using UltimateXR.Core.Components.Composite;

public class Gun : UxrGrabbableObjectComponent<Gun>
{
    [SerializeField] ParticleSystem gunShoot;

    // Update is called once per frame
    void Update()
    {
        if(UxrGrabManager.Instance.IsBeingGrabbed(GrabbableObject))
        {
            gunShoot.Play();
            print("!!!!!");
        }

        else
        {
            gunShoot.Stop();
            print("in else");
        }
    }
}
