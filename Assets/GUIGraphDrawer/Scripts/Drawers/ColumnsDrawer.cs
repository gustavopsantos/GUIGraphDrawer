using GUIGraphDrawer.Scripts.Shaders;
using GUIGraphDrawer.Scripts.ValueObjects;
using UnityEngine;

namespace GUIGraphDrawer.Scripts.Drawers
{
	internal static class ColumnsDrawer
	{
		internal static void Draw(Rect area, float amplitude, float[] columns, ColumnColor[] colors)
		{
			GUI.BeginClip(area);
			GL.PushMatrix();
			DrawColumns(area, amplitude, columns, colors);
			GL.PopMatrix();
			GUI.EndClip();
		}

		private static void DrawColumns(Rect area, float amplitude, float[] columns, ColumnColor[] colors)
		{
			var mat = new Material(Shader.Find("Unlit/InspectorGraphDrawer/Graph"));
			GraphShader.SetProperties(mat, columns, amplitude, colors);
			GLDrawer.DrawQuad(area, mat);
			Object.DestroyImmediate(mat);
		}
	}
}