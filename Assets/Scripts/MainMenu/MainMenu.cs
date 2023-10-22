using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class MainMenu : MonoBehaviour
{

    public string[] AvailablePlugins = { "FadeAnimation" };

    private CanvasGroup canvasGroup;
    private List<IAnimation> animationsPlayed = new();

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        IAnimation fadeOut = new FadeAnimation(canvasGroup).PlayReversed();
        animationsPlayed.Add(fadeOut);
        ResetUI();
    }

    /// <summary>
    /// Reset the UI of the Main Menu
    /// </summary>
    void ResetUI()
    {
        // play the animation of fade in 


        // create the menu items based on the config

        // for example rescale elements after updating their content, 
        // setup timers for animation,
        MatchBoxToText();
    }

    public void DisplayMenu()
    {
        gameObject.SetActive(true);
        IAnimation fadeIn = new FadeAnimation(canvasGroup).PlayAnimation();
        animationsPlayed.Add(fadeIn);
    }

    public void HideMenu()
    {
        IAnimation fadeOut = new FadeAnimation(canvasGroup).PlayReversed();
        animationsPlayed.Add(fadeOut);
        gameObject.SetActive(false);
    }

    [SerializeField]
    public float Opacity { get => canvasGroup.alpha; }

    /// <summary>
    /// Resize a Rect Transform to match the Text
    /// </summary>
    void MatchBoxToText()
    {

    }
}
