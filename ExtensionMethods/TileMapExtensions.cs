using Godot;

namespace ActionRPGTutorial.ExtensionMethods;

public static class TileMapExtensions
{
	public static Vector2I GetWorldSize(this TileMap tileMap)
	{
		var mapRect = tileMap.GetUsedRect();
		var tileSize = tileMap.CellQuadrantSize;
		var worldSizePixels = mapRect.Size * tileSize;
		return worldSizePixels;
	}
}
