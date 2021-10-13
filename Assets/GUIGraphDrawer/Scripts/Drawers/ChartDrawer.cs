using GUIGraphDrawer.Scripts.ValueObjects;
using UnityEngine;

namespace GUIGraphDrawer.Scripts.Drawers
{
	internal static class ChartDrawer
	{
		internal static void Draw(float guiHeight, float amplitude, float[] columns, float[] bars, ColumnColor[] colors)
		{
			var area = GUILayoutUtility.GetRect(Screen.width, guiHeight);
			if (Event.current.type != EventType.Repaint) return;
			ColumnsDrawer.Draw(area, amplitude, columns, colors);
			BarsDrawer.Draw(area, bars, amplitude);
		}
	}
}