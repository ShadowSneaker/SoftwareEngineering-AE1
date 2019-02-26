using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideInteraction : ActivatableObject
{
    private void OnCollisionEnter(Collision collision)
    {
        //Activate();
        if (collision.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Activate();
        }
    }
}
