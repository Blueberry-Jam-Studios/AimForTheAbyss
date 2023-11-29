using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CanvasGroup))]
public class MainMenu : MonoBehaviour
{
    // public string[] AvailablePlugins = { "FadeOut" };

    private CanvasGroup canvasGroup;

    public float Opacity { get => canvasGroup.alpha; set => canvasGroup.alpha = value; }

    [SerializeField]
    private MainMenuConfig _menuConfig;
    public MainMenuConfig MenuConfig { get => _menuConfig; set => _menuConfig = value; }

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void DisplayMenu()
    {
        Opacity = 1;
    }

    public void HideMenu()
    {
        Opacity = 0;
    }
}
