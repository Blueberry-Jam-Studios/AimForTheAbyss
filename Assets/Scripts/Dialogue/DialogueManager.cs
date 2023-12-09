using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using GameStates;

public class DialogueManager : Singleton<DialogueManager>
{
    private DialogueUI dialogueUI;

    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage;

    new void Awake()
    {
        base.Awake();
        dialogueUI = new DialogueUI(transform.GetChild(0).gameObject);
    }

    public void OpenDialogue(DialogueData newDialogueData)
    {
        GameManager.Instance.SetState(GameState.Dialogue);
        dialogueUI.Display();

        ResetDialogueData(newDialogueData);

        DisplayMessage();
    }

    void ResetDialogueData(DialogueData dialogueData)
    { 
        currentMessages = dialogueData.messages;
        currentActors = dialogueData.actors;
        activeMessage = 0;
        Debug.Log("Resetted the dialogue.. Number of messages: " + currentMessages.Length);
    }

    void DisplayMessage()
    {
        Message message = currentMessages[activeMessage];
        Actor actorSpeaking = currentActors[message.actorId];

        dialogueUI.Update(message, actorSpeaking);
    }

    public void NextMessage()
    {
        if (IsLastMessage())
        {
            CloseDialogue();
            return;
        }

        activeMessage++;
        DisplayMessage();
    }

    public void CloseDialogue()
    {
        dialogueUI.Hide();
        GameManager.Instance.fsm.SetCurrentState(GameState.Playing);
    }

    bool IsLastMessage()
    {
        return activeMessage == currentMessages.Length - 1;
    }

    bool IsDialogueActive()
    {
        return GameManager.Instance.IsInState(GameState.Dialogue);
    }
}
