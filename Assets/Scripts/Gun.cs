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
        if (this.IsBeingGrabbed)
        {
            gunShoot.Play();
        }

        else
        {
            gunShoot.Stop();
        }
    }
}
