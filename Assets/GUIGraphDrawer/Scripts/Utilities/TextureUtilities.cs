using UnityEngine;

namespace GUIGraphDrawer.Scripts.Utilities
{
	internal static class TextureUtilities
	{
		internal static Texture2D CreateTexture(Color color)
		{
			var texture = new Texture2D(1, 1);
			texture.SetPixel(0, 0, color);
			texture.Apply();
			return texture;
		}
	}
}