using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public static DialogueManager instance { get; private set; }

    private Queue<string> sentences;

    void Start()
    {
        instance = this;
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {

        nameText.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        displayNextSentence();
    }

    public void displayNextSentence()
    {
        if(sentences.Count == 0)
        {
            endDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }


    private void endDialogue()
    {
        Debug.Log("End of convo");
    }
}
