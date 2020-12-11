using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHolder : MonoBehaviour
{
	//public string dialogue;
    public Dialogue dialogue;

    //private DialogueManager DialogueManager;

	void Start()
	{
		//DialogueManager = FindObjectOfType<DialogueManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
        //Debug.Log("Working");
        //if (other.gameObject.CompareTag("convoTrigger")) 
        //{
        //	DialogueManager.ShowBox(dialogue);
        //}
        if (other.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }
	}

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
