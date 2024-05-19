using Godot;
using System.Linq;

public partial class HeartsContainer : HBoxContainer
{
    public PackedScene HeartContainer;
    public override void _Ready()
    {
        HeartContainer = (PackedScene)ResourceLoader.Load("res://UI/HeartPanel.tscn");
    }

    public void SetMaxHearts(int max)
    {
        for (int i = 0; i < max; i++)
        {
            var heart = HeartContainer.Instantiate();
            AddChild(heart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        var hearts = GetChildren().ToList();
        var missingHealth = hearts.Count - currentHealth;

        foreach (HeartPanel? heart in hearts)
        {
            heart.Update(true);
        }

        /*
         * So you can also edit this using the Layout Direction and Anchors Preset in the HeartsContainer control panel...or just use logic
        */
        //for (int i = hearts.Count - 1; i >= currentHealth; i--) //Logic for lefthand side of the screen
        //{
        //    var heartPanel = hearts[i] as HeartPanel;
        //    heartPanel?.Update(false);
        //}

        for (int i = 0; i < missingHealth; i++) //Logic for opposite heart placement
        {
            var heartPanel = hearts[i] as HeartPanel;
            heartPanel?.Update(false);
        }
    }

}
