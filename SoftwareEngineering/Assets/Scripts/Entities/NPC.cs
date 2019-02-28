using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {



    //private EntityScript NPCEntity;


    //nodes for the bottom floor
    public Transform Node1;
    public Transform Node2;
    public Transform Node3;
    public Transform Node4;
    public Transform Node5;
    public Transform Node6;
    public Transform Node7;
    public Transform TheHub;


    public Transform[] Itemnodes;

    // event nodes will be the ones the Ai will travel to
    [Header("this is the event travel point")]
    public Transform Travelpoint;

    // the navigation mesh the AI will use
    private NavMeshAgent Navigation;
    // the Number that determines the state of the AI
    private int RandomState;
   
    // bools to allow movemnt and notification when the AI is at the Hub
    public bool MoveOn;
    public bool AtHub;
    public bool Once;

    public bool Interacting; // used for when the NPC is interacting with an object

    enum State {Idle, Navigation, Interaction, Event }; // enum to tell the Ai what state it is in to determine what it does
    enum Node {AtNode1, AtNode2, AtNode3, AtNode4, AtNode5, AtNode6, AtNode7, AtHub }; // tell the Ai what part of the room the Ai is in
    enum Movement {Node1, Node2, Node3, Node4, Node5, Node6, Node7, Hub } // to tell the AI where to go next

    private Animator NPCAnim;


    State MyState; // AI's state
    Node CurrentNode; // the Current node the AI is at
    Movement NextNode; // the next node for the AI to move to

    public float WaitTimer; // timer for the idle wait time

    //bools for changing differnt types of interaction
    public bool interactPlayer;
    public bool interactObject;

    //bool for the event
    private bool EventTriggered = false;
    public bool AIOn = false;


	void Start ()
    {
        MoveOn = false;

        //NPCEntity = gameObject.GetComponent<EntityScript>();

        Navigation = FindObjectOfType<NavMeshAgent>();

        CurrentNode = Node.AtHub;

        Once = false;

        NPCAnim = transform.GetComponent<Animator>();

        interactPlayer = false;
        interactObject = false;


        // at the start the NPC is forced into the event and thats the only time the state is entered
        MyState = State.Event;

       if(transform.name == "Clown")
       {
           EventTriggered = true;
       }

       if(transform.name == "mad doctor")
       {
           EventTriggered = false;
       }

	}
	
	
	void Update ()
    {
        

            if (MyState != State.Event)
            {
                if (AtHub || MoveOn)
                {
                    switch (RandomStatePicker())
                    {
                        case (0):
                            {
                                MyState = State.Idle;

                                MoveOn = false;
                                break;

                            }
                        case (1):
                            {
                                Once = false;
                                MyState = State.Navigation;
                                MoveOn = false;
                                break;
                            }
                        case (2):
                            {
                                MyState = State.Interaction;
                                interactObject = true;

                                break;
                            }

                    }
                }
            }


            switch (MyState)
            {
                case State.Idle:
                    {
                        NPCInteractable();
                        break;
                    }
                case State.Interaction:
                    {
                        NPCInteractable();
                        if (interactObject && !interactPlayer)
                        {
                            Debug.Log("sucessfully entered interaction");

                            switch (CurrentNode)
                            {
                                case Node.AtHub:
                                    {


                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomHubItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                            else
                                            {
                                                interactObject = false;
                                            }
                                        }

                                        break;
                                    }
                                case Node.AtNode1:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomAItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Node.AtNode2:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomBItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Node.AtNode3:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomCItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Node.AtNode4:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomDItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Node.AtNode5:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomEItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Node.AtNode6:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomFItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);
                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }
                                case Node.AtNode7:
                                    {
                                        foreach (Transform T in Itemnodes)
                                        {
                                            if (T.gameObject.CompareTag("RoomGItem"))
                                            {
                                                if (T.GetComponent<InteractableObject>().Interactable)
                                                {
                                                    Debug.Log("In the Final if");
                                                    Navigation.SetDestination(T.position);

                                                    NPCAnim.SetBool("InteractItem", true);
                                                    T.transform.SetParent(transform);
                                                    T.GetComponent<InteractableObject>().Interactable = false;

                                                }
                                            }
                                        }
                                        break;
                                    }

                            }
                        }
                        break;
                    }
                case State.Navigation:
                    {
                        GetComponent<InteractableObject>().Interactable = false;

                        if (!interactPlayer && !interactObject)
                        {

                            GetComponent<InteractableObject>().Interactable = false;
                            // decides where to go next
                            RandomNodePicker();

                            Once = false;

                            //acually moves the Ai to that position
                            switch (NextNode)
                            {
                                case Movement.Hub:
                                    {
                                        Debug.Log("Moving to node Hub");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = TheHub.position;
                                   // Navigation.SetDestination(TheHub.position);



                                        break;
                                    }
                                case Movement.Node1:
                                    {
                                        Debug.Log("Moving to node 1");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = Node1.position;
                                   // Navigation.SetDestination(Node1.position);

                                        break;
                                    }
                                case Movement.Node2:
                                    {
                                        Debug.Log("Moving to node 2");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = Node2.position;
                                  //  Navigation.SetDestination(Node2.position);

                                        break;
                                    }
                                case Movement.Node3:
                                    {
                                        Debug.Log("Moving to node 3");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = Node3.position;
                                   // Navigation.SetDestination(Node3.position);

                                        break;
                                    }
                                case Movement.Node4:
                                    {
                                        Debug.Log("Moving to node 4");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = Node4.position;
                                   // Navigation.SetDestination(Node4.position);

                                        break;
                                    }
                                case Movement.Node5:
                                    {
                                        Debug.Log("Moving to node 5");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = Node5.position;
                                   // Navigation.SetDestination(Node5.position);

                                        break;
                                    }
                                case Movement.Node6:
                                    {
                                        Debug.Log("Moving to node 6");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                    transform.GetComponent<NavMeshAgent>().destination = Node6.position;
                                   // Navigation.SetDestination(Node6.position);

                                        break;
                                    }
                                case Movement.Node7:
                                    {
                                        Debug.Log("Moving to node 7");
                                        Once = true;
                                        NPCAnim.SetBool("Walking", true);
                                        transform.GetComponent<NavMeshAgent>().destination = Node7.position;
                                        // Navigation.SetDestination(Node7.position);

                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case State.Event:
                    {
                        // the NPC should be forced into the EVent state at the begining.
                        if (EventTriggered)
                        {
                            Debug.Log(transform.tag);
                            NPCAnim.SetBool("Walking", true);
                            transform.GetComponent<NavMeshAgent>().destination = Travelpoint.position;
                        }

                        break;
                    }
            }

        
		
	}


    private void FixedUpdate()
    {
        if (MyState == State.Idle)
        {
            WaitTimer -= Time.deltaTime;
        }

        if (WaitTimer <= 0)
        {
            MoveOn = true;
            WaitTimer = 5.0f;
        }
    }

    //function that sets the NPCs interaction to true
    public void NPCInteractable()
    {
        GetComponent<InteractableObject>().Interactable = true;
    }

    public void InteractionStop()
    {
        Debug.Log("The interaction Has stopped");
        interactObject = false;
        transform.Find("ItemNode").SetParent(null);
        NPCAnim.SetBool("InteractItem", false);
    }


    private void OnTriggerEnter(Collider other)
    {

        
            if (other.name == "RoomA")
            {
            Debug.Log("Yes");
                MyState = State.Idle;
                CurrentNode = Node.AtNode1;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "RoomB")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtNode2;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "RoomC")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtNode3;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "RoomD")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtNode4;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "RoomE")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtNode5;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "RoomF")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtNode6;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "RoomG")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtNode7;
                NPCAnim.SetBool("Walking", false);
                Once = false;
            }
            else if (other.name == "Hub")
            {
            Debug.Log("Yes");
            MyState = State.Idle;
                CurrentNode = Node.AtHub;
                NPCAnim.SetBool("Walking", false);
            }
            
        

        if (other.tag == "EndPoint")
        {
            MyState = State.Idle;
            Debug.Log("Are you running");
            EventTriggered = false;
            NPCAnim.SetBool("Walking", false);
        }

    }


    

    private int RandomStatePicker()
    {
        RandomState = Random.Range(0, 3);
        Debug.Log(RandomState);
        return RandomState;
    }




    private void RandomNodePicker()
    {
        int temp;
        if (!Once)
        {
            switch (CurrentNode)
            {
                case Node.AtHub:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }

                        }

                        break;
                    }
                case Node.AtNode1:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }

                        break;
                    }
                case Node.AtNode2:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }
                        break;
                    }
                case Node.AtNode3:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }
                        break;
                    }
                case Node.AtNode4:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }
                        break;
                    }
                case Node.AtNode5:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }
                        break;
                    }
                case Node.AtNode6:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node7;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }
                        break;
                    }
                case Node.AtNode7:
                    {
                        temp = Random.Range(0, 7);
                        switch (temp)
                        {
                            case (0):
                                {
                                    NextNode = Movement.Node1;
                                    break;
                                }
                            case (1):
                                {
                                    NextNode = Movement.Node2;
                                    break;
                                }
                            case (2):
                                {
                                    NextNode = Movement.Node3;
                                    break;
                                }
                            case (3):
                                {
                                    NextNode = Movement.Node4;
                                    break;
                                }
                            case (4):
                                {
                                    NextNode = Movement.Node5;
                                    break;
                                }
                            case (5):
                                {
                                    NextNode = Movement.Node6;
                                    break;
                                }
                            case (6):
                                {
                                    NextNode = Movement.Hub;
                                    break;
                                }

                        }
                        break;
                    }
            }

        }

    }


    public void SetEventTriggered(bool Triggered)
    {
        EventTriggered = Triggered;
    }

    public void SetTravelPoint(Transform Point)
    {
        Travelpoint = Point;
    }
}
