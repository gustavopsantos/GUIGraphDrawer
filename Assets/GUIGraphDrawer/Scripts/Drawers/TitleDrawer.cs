using UnityEngine;

namespace GUIGraphDrawer.Scripts.Drawers
{
	internal static class TitleDrawer
	{
		internal const float Height = 24;
		private const float TitleTopPadding = 4;
		private const float TitleLeftPadding = 6;
		private const int DropShadowYOffset = 2;

		internal static void Draw(string title)
		{
			var area = GUILayoutUtility.GetRect(Screen.width, Height);
			if (Event.current.type != EventType.Repaint) return;
			area.y += TitleTopPadding;
			area.x += TitleLeftPadding;
			var style = new GUIStyle("Label") { alignment = TextAnchor.UpperLeft };
			DropShadowLabel(area, title, style);
		}

		private static void DropShadowLabel(Rect area, string content, GUIStyle style)
		{
			area.y += DropShadowYOffset;
			GUI.Label(area, content, new GUIStyle(style) { normal = { textColor = Color.black } });
			area.y -= DropShadowYOffset;
			GUI.Label(area, content, new GUIStyle(style) { normal = { textColor = Color.white } });
		}
	}
}