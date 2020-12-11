using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    //public bool dialogueActive = true;
    //public string[] dialogueLines;
    //public int currentLine;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (dialogueActive && Input.GetKeyDown(KeyCode.Return)) 
        //{
        //    currentLine++;
        //}

        //if (currentLine >= dialogueLines.Length) 
        //{
        //    dialogueBox.SetActive(false);
        //    dialogueActive = false;

        //    currentLine = 0;   
        //}

        //dialogueText.text = dialogueLines[currentLine];

        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    //public void ShowBox(string dialogue) 
    //{
        //Debug.Log("working");
        //dialogueActive = true;
        //dialogueBox.SetActive(true);
        //dialogueText.text = dialogue;
    //}

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(true);
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
    }
}
