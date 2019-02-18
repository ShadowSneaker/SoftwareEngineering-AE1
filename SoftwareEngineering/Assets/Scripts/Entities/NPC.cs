using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {

    //the entity has four states in which it can change to at random times (interaction, idle, Event, moving)
    public bool MoveState; // state that allows the AI to move around the house
    public bool InteractionState; // state that allows the AI to Interact with objects and player
    public bool IdleState; // Idle state for idle
    public bool EventState; // event state that allows the AI to trigger room events

    private EntityScript NPCEntity;
    
    public Transform Node1;
    public Transform Node2;

    private bool AtNode1;
    private bool AtNode2;

    private NavMeshAgent Navigation;

	void Start ()
    {
        IdleState = false;
        MoveState = true;
        InteractionState = false;
        EventState = false;

        AtNode1 = true;

        NPCEntity = gameObject.GetComponent<EntityScript>();


        Navigation = FindObjectOfType<NavMeshAgent>();
	}
	
	
	void Update ()
    {
		if(MoveState)
        {
          if(AtNode1)
          {
                Navigation.destination = Node2.position;
          }
          else if (AtNode2)
          {
                Navigation.destination = Node1.position;
          }
        
        
        }
	}



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");

        if(other.name == "Node1")
        {
            AtNode1 = true;
            AtNode2 = false;
        }
        else if (other.name == "Node2")
        {
            AtNode2 = true;
            AtNode1 = false;
        }

    }

}
