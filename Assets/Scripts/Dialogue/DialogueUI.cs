using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI
{
    private Image actorImage;
    private TextMeshProUGUI actorName;
    private TextMeshProUGUI messageText;
    private TextMeshProUGUI buttonText;
    private Image background;

    private readonly GameObject gameObject;

    public DialogueUI(GameObject gameObject)
    {
        this.gameObject = gameObject;
        actorImage = gameObject.transform.Find("Avatar").GetComponent<Image>();
        actorName = gameObject.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        messageText = gameObject.transform.Find("Message").GetComponent<TextMeshProUGUI>();
        buttonText = gameObject.transform.Find("Button").GetComponentInChildren<TextMeshProUGUI>();
        background = gameObject.transform.Find("Background").GetComponent<Image>();
    }

    public void Update(Message message, Actor actorSpeaking)
    { 
        messageText.text = message.message;
        buttonText.text = message.buttonText == "" ? "Next" : message.buttonText;

        actorName.text = actorSpeaking.actorName;
        actorImage.sprite = actorSpeaking.avatar;
    }

    public void Display()
    { 
        gameObject.SetActive(true);
    }

    public void Hide()
    { 
        gameObject.SetActive(false);
        
    }
}
