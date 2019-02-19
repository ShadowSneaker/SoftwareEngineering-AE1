using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {



    private EntityScript NPCEntity;
    

    //nodes for the bottom floor
    public Transform Node1;
    public Transform Node2;
    public Transform Node3;
    public Transform Node4;
    public Transform Node5;
    public Transform Node6;
    public Transform Node7;

    // this should be used to detwemine what node they are at then should have something to determine where to move next
    public bool AtNode1;
    public bool AtNode2;
    public bool AtNode3;
    public bool AtNode4;
    public bool AtNode5;
    public bool AtNode6;
    public bool AtNode7;
    public bool AtHub;
    public bool MoveOn;

    // bools called moveTo to tell the Ai move there

    private NavMeshAgent Navigation;

    private int RandomState;

    enum State {Idle, Navigation, Interaction, Event };

    State MyState;

    public float WaitTimer = 5.0f;

	void Start ()
    {
        MoveOn = false;

        NPCEntity = gameObject.GetComponent<EntityScript>();

        Navigation = FindObjectOfType<NavMeshAgent>();


	}
	
	
	void Update ()
    {
        if(AtHub || MoveOn)
        {
            switch(RandomStatePicker())
            {
                case (0):
                {
                        MyState = State.Idle;
                        MoveOn = false;
                   break;
                        
                }
                case (1):
                {
                        MyState = State.Navigation;
                        MoveOn = false;
                    break;
                }
                
            }
        }


        switch(MyState)
        {
            case State.Idle:
            {
                break;
            }
            case State.Interaction:
            {
                    
                break;
            }
            case State.Navigation:
            {
               

                    // needs to be changed
                    if (!AtNode1 && !AtNode2 && !AtNode3 && !AtNode4  && !AtNode5 && !AtNode2)
                    {
                        int Temp = RandomNodePicker();

                        if (Temp == 0)
                        {
                            AtNode1 = true;
                            AtHub = false;
                        }
                        else if(Temp == 1)
                        {
                            AtNode2 = true;
                            AtHub = false;
                        }
                        else if(Temp == 2)
                        {
                            AtNode3 = true;
                            AtHub = false;
                        }
                        else if (Temp == 3)
                        {
                            AtNode4 = true;
                            AtHub = false;
                        }
                        else if (Temp == 4)
                        {
                            AtNode5 = true;
                            AtHub = false;
                        }
                        else if (Temp == 5)
                        {
                            AtNode6 = true;
                            AtHub = false;
                        }
                        else if (Temp == 6)
                        {
                            AtNode7 = true;
                            AtHub = false;
                        }

                    }

                    if (AtNode1)
                    {
                        Navigation.destination = Node2.position;
                    }
                    else if (AtNode2)
                    {
                        Navigation.destination = Node1.position;
                    }
                    

                    break;
            }
            case State.Event:
            {
                    
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






    private void OnTriggerEnter(Collider other)
    {
      

        if(other.name == "Node1")
        {
            AtHub = false;
            AtNode1 = true;
            AtNode2 = false;
            AtNode3 = false;
            AtNode4 = false;
            AtNode5 = false;
            AtNode6 = false;
            AtNode7 = false;
        }
        else if (other.name == "Node2")
        {
            AtHub = false;
            AtNode1 = false;
            AtNode2 = true;
            AtNode3 = false;
            AtNode4 = false;
            AtNode5 = false;
            AtNode6 = false;
            AtNode7 = false;

        }
        else if (other.name == "Node3")
        {
            AtHub = false;
            AtNode1 = false;
            AtNode2 = false;
            AtNode3 = true;
            AtNode4 = false;
            AtNode5 = false;
            AtNode6 = false;
            AtNode7 = false;

        }
        else if (other.name == "Node4")
        {
            AtHub = false;
            AtNode1 = false;
            AtNode2 = false;
            AtNode3 = false;
            AtNode4 = true;
            AtNode5 = false;
            AtNode6 = false;
            AtNode7 = false;
        }
        else if (other.name == "Node5")
        {
            AtHub = false;
            AtNode1 = false;
            AtNode2 = false;
            AtNode3 = false;
            AtNode4 = true;
            AtNode5 = true;
            AtNode6 = false;
            AtNode7 = false;
        }
     
        else if (other.name == "Node6")
        {
            AtHub = false;
            AtNode1 = false;
            AtNode2 = false;
            AtNode3 = false;
            AtNode4 = false;
            AtNode5 = false;
            AtNode6 = true;
            AtNode7 = false;
        }
        else if (other.name == "Node7")
        {
            AtHub = false;
            AtNode1 = false;
            AtNode2 = false;
            AtNode3 = false;
            AtNode4 = false;
            AtNode5 = false;
            AtNode6 = false;
            AtNode7 = true;
        }
        else if(other.name == "Hub")
        {
            AtHub = true;
            MyState = State.Idle;

        }


    }


    private int RandomStatePicker()
    {
        RandomState = Random.Range(0, 2);
        Debug.Log(RandomState);
        return RandomState;
    }

    private int RandomNodePicker()
    {
        //this will increase later gonna find a way so that you can just tyoe a number and it increase the nodes
        return Random.Range(0, 7);
    }


}
