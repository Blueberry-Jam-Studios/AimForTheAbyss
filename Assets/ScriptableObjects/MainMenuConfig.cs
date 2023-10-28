using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu]
public class MainMenuConfig : ScriptableObject
{

    public string GameTitle = "Aim for the Abyss";

    public string[] Buttons = { "Start Game", "Options", "Exit" };

    public string[] Plugins = { "Animation" };

    public Sprite[] BackgroundImage;
}