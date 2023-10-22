using System.Collections;
using UnityEngine;

public class FadeAnimation : IAnimation
{
    private CanvasGroup canvasGroup;

    public FadeAnimation(CanvasGroup canvasGroup)
    {
        this.canvasGroup = canvasGroup;
    }

    public IAnimation PlayAnimation()
    {
        Debug.Log("Playing the Fade In animation");
        canvasGroup.alpha = 1;
        return this;
    }

    public IAnimation PlayReversed()
    {
        Debug.Log("Playing the Fade Out animation");
        canvasGroup.alpha = 0;
        return this;
    }

    public IAnimation Pause()
    {
        return this;
    }
}

public class FadeInOut : MonoBehaviour
{
    public Animator animator;
    public Canvas canvas;
    public float fadingSpeed;

    private bool stopFading = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OverAllTime(5f));
    }

    IEnumerator CanvasAlphaChangeOverTime(Canvas canvas, float duration)
    {
        var alphaColor = canvas.GetComponent<CanvasGroup>().alpha;

        while (true)
        {
            alphaColor = (Mathf.Sin(Time.time * duration) + 1.0f) / 2.0f;
            canvas.GetComponent<CanvasGroup>().alpha = alphaColor;

            if (stopFading == true)
            {
                break;
            }

            yield return null;
        }
    }

    IEnumerator OverAllTime(float time)
    {
        StartCoroutine(CanvasAlphaChangeOverTime(canvas, fadingSpeed));

        yield return new WaitForSeconds(time);

        stopFading = true;
        StopCoroutine("CanvasAlphaChangeOverTime");
    }
}