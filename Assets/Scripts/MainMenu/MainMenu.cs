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
        // If there is the animation plugin create the CanvasGroup on the child
        CreateUI();
        SetupPlugins(MenuConfig.Plugins);
    }

    public void DisplayMenu()
    {
        Opacity = 1;
        // gameObject.SetActive(true);
    }

    public void HideMenu()
    {
        Opacity = 0;
        // gameObject.SetActive(value: false);
    }

    /// <summary>
    /// Create the Title and the Buttons of the Menu based on the configuration.
    /// </summary>
    void CreateUI()
    {
        Debug.Log("Creating the Menu UI from the config: " + MenuConfig.GameTitle);

        // Create the main panel with the image
        GameObject menuPanel;
        if (transform.childCount == 0)
        {
            menuPanel = new();
            menuPanel.transform.parent = this.transform;
        }

        menuPanel = transform.GetChild(0).gameObject;
        Image menuPanelImage = menuPanel.GetOrAddComponent<Image>();

        ChangeBackgroundImage(menuPanelImage, 0);

        Transform title = transform;

        // Create the buttons

        // Add the functionality to the buttons
        MapControlsToActions();
    }

    void ChangeBackgroundImage(Image panelImage, int chosenImage)
    {
        panelImage.sprite = MenuConfig.BackgroundImage[chosenImage];
    }

    void MapControlsToActions()
    {

    }

    /// <summary>
    /// Setup the extra functionality from the plugins to the UI elements.
    /// </summary>
    /// <param name="plugins"> The array of the activated plugins. </param>
    void SetupPlugins(string[] plugins)
    {
        // TODO: Add the functionality to the UI based on the Plugins enabled
    }

    /// <summary>
    /// Resize a Rect Transform to match the Text
    /// </summary>
    void MatchBoxToText()
    {

    }
}
