using UnityEngine;

namespace GUIGraphDrawer.Scripts.Drawers
{
	internal static class BarsDrawer
	{
		internal static void Draw(Rect area, float[] bars, float amplitude)
		{
			if (bars == null) return;

			GUI.BeginClip(area);
			GL.PushMatrix();
			DrawBars(area, bars, amplitude);
			GL.PopMatrix();
			GUI.EndClip();
		}

		private static void DrawBars(Rect area, float[] bars, float amplitude)
		{
			foreach (var bar in bars) DrawBar(area, bar, amplitude);
		}

		private static void DrawBar(Rect area, float bar, float amplitude)
		{
			var normalizedHeight = Mathf.InverseLerp(0, amplitude, bar);
			var height = area.height - area.height * normalizedHeight;
			var mat = new Material(Shader.Find("Unlit/InspectorGraphDrawer/VertexColor"));
			GLDrawer.DrawLine(0, height, area.width, height, mat, new Color(1f, 1f, 1f, 0.25f));
			Object.DestroyImmediate(mat);
		}
	}
}