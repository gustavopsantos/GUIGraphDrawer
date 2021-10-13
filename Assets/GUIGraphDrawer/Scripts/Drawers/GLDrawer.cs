using UnityEngine;

namespace GUIGraphDrawer.Scripts.Drawers
{
	internal static class GLDrawer
	{
		internal static void DrawQuad(Rect area, Material material)
		{
			material.SetPass(0);
			GL.Begin(GL.QUADS);
			GLVertex(0, area.height, 0, 0);
			GLVertex(0, 0, 0, 1);
			GLVertex(area.width, 0, 1, 1);
			GLVertex(area.width, area.height, 1, 0);
			GL.End();
		}

		internal static void DrawLine(float ax, float ay, float bx, float by, Material material, Color color)
		{
			material.SetPass(0);
			GL.Begin(GL.LINES);
			GL.Color(color);
			GL.Vertex3(ax, ay, 0);
			GL.Vertex3(bx, by, 0);
			GL.End();
		}

		private static void GLVertex(float x, float y, float u, float v)
		{
			GL.TexCoord2(u, v);
			GL.Vertex3(x, y, 0);
		}
	}
}