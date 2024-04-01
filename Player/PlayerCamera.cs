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
		var testMapRect = _tileMap.GetUsedRect();
		var worldSizePixels = GetWorldSize();
		LimitRight = worldSizePixels.X;
		LimitBottom = worldSizePixels.Y;
	}

	/*
	 * Custom Methods
	 */
	private Vector2I GetWorldSize()
	{
		var mapRect = _tileMap.GetUsedRect();
		var tileSize = _tileMap.CellQuadrantSize;
		var worldSizePixels = mapRect.Size * tileSize;
		return worldSizePixels;
	}
}
