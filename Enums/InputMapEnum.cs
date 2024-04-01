using System;
using Godot;

namespace ActionRPGTutorial.Enums
{
    public static class CustomInputMaps
    {
        public static string InputMap(CustomInputMapEnum customInputMap)
        {
            return customInputMap switch
            {
                CustomInputMapEnum.SPRINT => "Sprint",
                _ => throw new ArgumentException("Could not find value in InputMapEnum")
            };
        }
    }

    public enum CustomInputMapEnum
    {
        SPRINT
    }
}
