using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBuilder
{
    Transform _parentRef;

    public MainMenuBuilder(Transform parentRef)
    {
        this._parentRef = parentRef;
    }

    /// <summary>
    /// Create the Menu Text based on the configuration of the Menu
    /// </summary>
    // public List<MenuItem> CreateMenuItems(MainMenuConfig menuConfig)
    // {
    //     List<MenuItem> menuItems = new();
    //     foreach (var menuText in menuConfig.availableMenuItems)
    //     {
    //         Debug.Log("Creating the item: " + menuText);
    //         menuItems.Add(new MenuItem(menuText));
    //     }

    //     return menuItems;

    // }

    // public GameObject CreateMenuItem(MenuItem item)
    // {
    //     GameObject gameObject = Instantiate<TextMesh>();
    // }
}
