using GUIGraphDrawer.Scripts.Drawers;
using GUIGraphDrawer.Scripts.ValueObjects;

namespace GUIGraphDrawer.Scripts.Utilities
{
	public static partial class GUILayoutUtilities
	{
		public static void Graph(string title, float height, float amplitude, float[] columns, float[] bars, ColumnColor[] colors)
		{
			GraphDrawer.Draw(title, height, amplitude, columns, bars, colors);
		}
	}
}