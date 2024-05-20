using System;

namespace ActionRPGTutorial.Enums
{
    public static class CustomInputMaps
    {
        public static string InputMap(CustomInputMapEnum customInputMap)
        {
            return customInputMap switch
            {
                CustomInputMapEnum.SPRINT => "Sprint",
                CustomInputMapEnum.ATTACK => "Attack",
                _ => throw new ArgumentException("Could not find value in InputMapEnum")
            };
        }
    }

    public enum CustomInputMapEnum
    {
        SPRINT,
        ATTACK
    }
}
