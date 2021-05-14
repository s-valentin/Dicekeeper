using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{

    public Dialogue dialogue;
    public Canvas canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canvas.enabled = true;
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvas.enabled = false;
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.startDialogue(dialogue);
    }
}
