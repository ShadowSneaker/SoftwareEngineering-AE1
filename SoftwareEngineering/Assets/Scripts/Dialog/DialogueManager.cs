using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    // a queue of sentences that the NPC will iterate through
    private Queue<string> Sentences;

    // public buttons
    //public Button SkipText;
    //public Button EndText;

    // text used for the dialog
    public Text CharecterText;
    public Dialogue NPCDialogue;


    // bool to tell when the corutine is running
    private bool CR_Running;

    //timer
    //private float Timer = 1;

    //
    public bool beginingDialog;
    // finsih the dialog
    public bool EndDialog;
   


	void Start ()
    {
        Sentences = new Queue<string>();
        CharecterText.gameObject.SetActive(false);
        beginingDialog = true;
	}


     void Update()
     {
        if (!EndDialog)
        {
            if (!beginingDialog)
            {
                if (CR_Running)
                {

                }
                else
                {
                    if (Sentences.Count == 0)
                    {
                        Debug.Log("Entering last line ");
                        StartCoroutine(TypeWriter(NPCDialogue.FinalLine));
                       
                        EndDialog = true;
                        //CharecterText.gameObject.SetActive(false);
                    }
                    else
                    {
                        StartCoroutine(TypeWriter(Sentences.Dequeue()));
                        
                    }
                }
            }
        }
    }


    public void Dialog()
    {
        beginingDialog = true;
        gameObject.GetComponent<NPC>().interactPlayer = true;
        if (beginingDialog)
        {
            CharecterText.gameObject.SetActive(true);

            foreach(string sentence in NPCDialogue.sentences)
            {
                Sentences.Enqueue(sentence);
            }

            StartCoroutine(TypeWriter(NPCDialogue.StartLine));
        }

        EndDialog = false;
        
    }

    IEnumerator TypeWriter(string line)
    {
        

        CR_Running = true;

        CharecterText.text = "";

        foreach(char letter in line.ToCharArray())
        {
            CharecterText.text += letter;
            
            yield return new WaitForSeconds(0.2f);
        }

        CR_Running = false;

        if (beginingDialog)
        {
            beginingDialog = false;
        }


        if(EndDialog)
        {
            CharecterText.gameObject.SetActive(false);
            gameObject.GetComponent<NPC>().interactPlayer = false;
        }
    }

  

}
