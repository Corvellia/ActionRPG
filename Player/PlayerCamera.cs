using System;
using ActionRPGTutorial.ExtensionMethods;
using Godot;

namespace ActionRPGTutorial.Player;

public partial class PlayerCamera : Camera2D
{
	[Export]
	private TileMap _tileMap;

	/*
	 * Overrides
	 */
	public override void _Ready()
	{
		var worldSizePixels = _tileMap.GetWorldSize();
		LimitRight = worldSizePixels.X;
		GD.Print($"{worldSizePixels.X.ToString()}");
		LimitBottom = worldSizePixels.Y;
	}
}
