using Godot;
using System;

public partial class PlayerCamera : Camera2D
{
	[Export]
	public TileMap TileMap;

	/*
	 * Overrides
	 */
	public override void _Ready()
	{
		var worldSizePixels = GetWorldSize();
		LimitRight = worldSizePixels.X;
		LimitBottom = worldSizePixels.Y;
	}

	/*
	 * Custom Methods
	 */
	private Vector2I GetWorldSize()
	{
		var mapRect = TileMap.GetUsedRect();
		var tileSize = TileMap.CellQuadrantSize;
		var worldSizePixels = mapRect.Size * tileSize;
		return worldSizePixels;
	}
}
