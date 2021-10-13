using GUIGraphDrawer.Scripts.Utilities;
using GUIGraphDrawer.Scripts.ValueObjects;
using UnityEngine;

namespace GUIGraphDrawer.Scripts.Drawers
{
	internal static class GraphDrawer
	{
		internal static void Draw(string title, float height, float amplitude, float[] columns, float[] bars, ColumnColor[] colors)
		{
			var background = new GUIStyle { normal = { background = TextureUtilities.CreateTexture(new Color(0f, 0f, 0f, 0.25f)) } };
			using (new GUILayout.VerticalScope(background))
			{
				TitleDrawer.Draw(title);
				ChartDrawer.Draw(height - TitleDrawer.Height, amplitude, columns, bars, colors);
			}
		}
	}
}