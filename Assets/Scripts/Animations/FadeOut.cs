using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// A class handling the FadeOut and FadeIn animations.
/// </summary>
public class FadeOut : IAnimation
{
    private CanvasGroup canvasGroup;

    /// <summary>
    /// The desired opacity of the component.
    /// Whenever the Opacity changes the Fade animation is played automatically.
    /// </summary>
    public float Opacity { get; set; } = 1f;

    public float fadeSpeed = 4;

    private float CurrentAlpha
    {
        get => canvasGroup.alpha;
        set => canvasGroup.alpha = value;
    }

    public FadeOut(CanvasGroup canvasGroup) : base()
    {
        this.canvasGroup = canvasGroup;
    }

    public void UpdateAnimation()
    {
        CurrentAlpha = Mathf.MoveTowards(CurrentAlpha, Opacity, fadeSpeed * Time.deltaTime);
    }

    public IAnimation PlayAnimation()
    {
        Debug.Log("Playing the Fade In animation");
        Opacity = 1;
        return this;
    }

    public IAnimation PlayReversed()
    {
        Debug.Log("Playing the Fade Out animation");
        Opacity = 0;
        return this;
    }

    public IAnimation Pause()
    {
        return this;
    }
}