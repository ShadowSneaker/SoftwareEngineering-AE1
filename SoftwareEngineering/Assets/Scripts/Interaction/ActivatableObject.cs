using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatableObject : MonoBehaviour
{
    public enum EActivationBehaviour
    {
        // Will toggle this object On/Off.
        Toggle,

        // Will only allow activation when this object is Deactivated.
        ActivateOnly,

        // Will only allow activation when this object is Activated.
        DeactivateOnly,

        // Runs the activation script every time the object is interacted with.
        Reset
    }


    public EActivationBehaviour Behaviour;

    public bool Activated;

    public UnityEvent[] Events;



    public virtual void Activate()
    {
        switch (Behaviour)
        {
            case EActivationBehaviour.Toggle:
                Activated = !Activated;
                for (int i = 0; i < Events.Length; ++i)
                {
                    if (Events[i] != null)
                    {
                        Events[i].Invoke();
                    }
                }
                break;


            case EActivationBehaviour.ActivateOnly:
                if (!Activated)
                {
                    Activated = true;
                    for (int i = 0; i < Events.Length; ++i)
                    {
                        if (Events[i] != null)
                        {
                            Events[i].Invoke();
                        }
                    }
                }
                break;


            case EActivationBehaviour.DeactivateOnly:
                if (Activated)
                {
                    Activated = false;
                    for (int i = 0; i < Events.Length; ++i)
                    {
                        if (Events[i] != null)
                        {
                            Events[i].Invoke();
                        }
                    }
                }
                break;


            case EActivationBehaviour.Reset:
                Activated = true;
                for (int i = 0; i < Events.Length; ++i)
                {
                    if (Events[i] != null)
                    {
                        Events[i].Invoke();
                    }
                }
                break;
        }
        
    }
}
