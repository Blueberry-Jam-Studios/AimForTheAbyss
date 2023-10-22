using System;
using UnityEngine;

public class MenuItem
{
    public string text;

    public MenuItem(string text)
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

        if (obj is MenuItem other)
        {
            return this.text == other.text;
        }

        throw new ArgumentException("A MenuItem object is required for comparison.", "obj");
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class ButtonMenuItem : MenuItem
{
    public string Text { get; set; } = "Placeholder button text";

    public ButtonMenuItem(string name) : base(name)
    {
        Text = name;
    }
}