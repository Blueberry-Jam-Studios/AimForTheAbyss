using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePrefab;

    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI buttonText;
    public GameObject background;


    private Message[] currentMessages;
    private Actor[] currentActors;
    private int activeMessage;

    private GameObject dialogueUI;
    public static DialogueManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        dialogueUI = transform.GetChild(0).gameObject;
    }

    public void OpenDialogue(DialogueData dialogueData)
    {
        GameManager.Instance.CurrentState.HandleEvent(Action.ToggleDialogue);
        dialogueUI.SetActive(true);
        currentMessages = dialogueData.messages;
        currentActors = dialogueData.actors;
        activeMessage = 0;

        Debug.Log("Started the dialogue.. Number of messages: " + currentMessages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
        buttonText.text = messageToDisplay.buttonText == "" ? "Next" : messageToDisplay.buttonText;

        Actor actorSpeaking = currentActors[messageToDisplay.actorId];
        actorName.text = actorSpeaking.actorName;
        actorImage.sprite = actorSpeaking.avatar;
    }

    void NextMessage()
    {
        if (activeMessage == currentMessages.Length - 1)
        {
            CloseDialogue();
            return;
        }

        activeMessage++;
        DisplayMessage();
    }

    public void CloseDialogue()
    {
        dialogueUI.SetActive(false);
        GameManager.Instance.CurrentState.HandleEvent(Action.ToggleDialogue);
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState.Name != States.AvailableGameState.Dialogue.ToString())
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            NextMessage();
    }
}
