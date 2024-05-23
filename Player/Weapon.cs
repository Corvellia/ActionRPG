using Godot;
using System;
using Microsoft.VisualBasic;

public partial class Weapon : Node2D
{
    public Area2D? WeaponArea { get; set; }

    public override void _Ready()
    {
        var childrenList = GetChildren();

        if (childrenList is { Count: > 0 })
        {
            WeaponArea = childrenList[0] as Area2D;
        }
    }

    public void Enable()
    {
        Visible = true;
        if (WeaponArea is not null && WeaponArea.HasMethod("Enable"))
        {
            WeaponArea.Call("Enable");
        }
    }

    public void Disable()
    {
        Visible = false;
        if (WeaponArea is not null && WeaponArea.HasMethod("Disable"))
        {
            WeaponArea.Call("Disable");
        }
    }
}
