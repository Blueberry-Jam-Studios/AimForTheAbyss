using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueData : ScriptableObject
{
    public Message[] messages;
    public Actor[] actors;
}

[Serializable]
public class Message
{
    public int actorId;
    public string message;
    public string buttonText;
}

[Serializable]
public class Actor
{
    public string actorName;
    public Sprite avatar;
}