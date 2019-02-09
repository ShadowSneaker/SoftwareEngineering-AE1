using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideInteraction : ActivatableObject
{

    private void OnCollisionEnter(Collision collision)
    {
        Activate();
    }


    private void OnTriggerEnter(Collider other)
    {
        Activate();
    }
}
