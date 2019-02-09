using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : EntityScript
{

    public float InteractionRange = 2.0f;


    public Text FlavourText;
    public Text ObjectInfo;

    // A refernce to the attached CameraController component.
    CameraController Cam;


    RaycastHit Hit;
    InteractableObject Obj;




    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        Cam = GetComponent<CameraController>();
	}


    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (Cam)
        {
            Physics.Raycast(Cam.Cam.transform.position, Cam.Cam.transform.forward, out Hit, InteractionRange);
            if (Hit.collider)
            {
                Debug.Log("Hit");

                // Interact with objects that trigger on looking.
                Obj = Hit.transform.GetComponent<LookInteractor>();
                if (Obj && Obj.Interactable)
                {
                    Obj.Interact(this);

                    return;
                }


                // Interact with objects that require the user to press a button.
                Obj = Hit.transform.GetComponent<InteractableObject>();
                if (Obj && Obj.Interactable)
                {
                    FlavourText.text = Obj.FlavourText;
                    ObjectInfo.text = Obj.ObjectInfo;
                    FlavourText.enabled = true;
                    ObjectInfo.enabled = true;

                    if (Input.GetKeyDown("f"))
                    {
                        Obj.Interact(this);
                    }
                }
                else
                {
                    FlavourText.enabled = false;
                    ObjectInfo.enabled = false;
                }
            }
            else
            {
                FlavourText.enabled = false;
                ObjectInfo.enabled = false;
            }
        }
    }

}
