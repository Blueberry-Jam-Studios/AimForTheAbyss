using System;
using UnityEngine;

public class UIElement
{
    public string text;

    public UIElement(string text)
    {
        this.text = text;
    }

    public override string ToString()
    {
        return text;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj is UIElement other)
        {
            return this.text == other.text;
        }

        throw new ArgumentException("A UIElement object is required for comparison.", "obj");
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class ButtonUIElement : UIElement
{
    public string Text { get; set; } = "Placeholder button text";

    public ButtonUIElement(string name) : base(name)
    {
        Text = name;
    }
}