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
    private List<IAnimation> animationsPlayed = new();

    private IAnimation fadeAnim;

    [SerializeField]
    private MainMenuConfig _menuConfig;
    public MainMenuConfig MenuConfig { get => _menuConfig; set => _menuConfig = value; }

    // Start is called before the first frame update
    void Start()
    {
        // If there is the animation plugin create the CanvasGroup on the child
        canvasGroup = GetComponent<CanvasGroup>();

        fadeAnim = new FadeOut(canvasGroup);
        animationsPlayed.Add(fadeAnim);
        ResetUI();
        SetupPlugins(MenuConfig.Plugins);
    }

    void Update()
    {
        fadeAnim.UpdateAnimation();
    }

    /// <summary>
    /// Reset the UI of the Main Menu
    /// </summary>
    void ResetUI()
    {
        // play the animation of fade in 
        fadeAnim.PlayAnimation();
        CreateUI();

        // create the menu items based on the config
        // for example rescale elements after updating their content, 
        // setup timers for animation,
        MatchBoxToText();
    }

    /// <summary>
    /// Create the Title and the Buttons of the Menu based on the configuration.
    /// </summary>
    void CreateUI()
    {
        Debug.Log("Creating the Menu UI of the Game: " + MenuConfig.GameTitle);

        // Create the main panel with the image
        GameObject menuPanel;
        if (transform.childCount == 0)
        {
            menuPanel = new();
            menuPanel.transform.parent = this.transform;
        }

        menuPanel = transform.GetChild(0).gameObject;
        Image menuPanelImage = menuPanel.GetOrAddComponent<Image>();

        ChangeBackgroundImage(menuPanelImage, 1);

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

    public void DisplayMenu()
    {
        gameObject.SetActive(true);
        fadeAnim.PlayAnimation();
        animationsPlayed.Add(fadeAnim);
    }

    public void HideMenu()
    {
        fadeAnim.PlayReversed();
        animationsPlayed.Add(fadeAnim);
        // gameObject.SetActive(false);
    }

    public float Opacity { get => canvasGroup.alpha; }

    /// <summary>
    /// Resize a Rect Transform to match the Text
    /// </summary>
    void MatchBoxToText()
    {

    }
}
