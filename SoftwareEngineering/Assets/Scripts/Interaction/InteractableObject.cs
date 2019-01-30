using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InteractableObject : MonoBehaviour
{
    // Determines if this object can be interacted with.
    public bool Interactable = true;

    // A list of objects that this object activates.
    public ActivatableObject[] BoundObjects;

    public bool DeactivateOnInteraction;

    // Text that shows up on the screen to inform the player how to interact with the object.
    public string FlavourText = "Press F to interact";

    // Text that shows up on the screen to inform the player about the object.
    public string ObjectInfo;



    // Interacts with this object.
    // @param Interactor - The entity who interacted with this object.
    public void Interact(EntityScript Interactor)
    {
        if (Interactable)
        {
            for (int i = 0; i < BoundObjects.Length; ++i)
            {
                BoundObjects[i].Activate();
            }

            if (DeactivateOnInteraction)
            {
                Interactable = false;
            }
        }

        Interactor.ApplyEffect<Effect>();
    }


    
}
