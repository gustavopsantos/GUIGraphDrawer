using GUIGraphDrawer.Scripts.Drawers;
using GUIGraphDrawer.Scripts.ValueObjects;
using UnityEngine;

namespace GUIGraphDrawer.Scripts.Utilities
{
	public static partial class GUIUtilities
	{
		public static void Graph(Rect rect, string title, float amplitude, float[] columns, float[] bars, ColumnColor[] colors)
		{
			using (new GUILayout.AreaScope(rect))
			{
				GraphDrawer.Draw(title, rect.height, amplitude, columns, bars, colors);
			}
		}
	}
}