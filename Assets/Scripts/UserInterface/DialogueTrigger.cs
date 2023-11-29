using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogueData;

    void OnTriggerEnter2D()
    {
        DialogueManager.Instance.OpenDialogue(dialogueData);
    }

    void OnTriggerExit2D()
    {
        DialogueManager.Instance.CloseDialogue();
    }
}