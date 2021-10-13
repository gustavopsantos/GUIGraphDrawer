using System.Linq;
using GUIGraphDrawer.Scripts.ValueObjects;
using UnityEngine;

namespace GUIGraphDrawer.Scripts.Shaders
{
	internal static class GraphShader
	{
		private static readonly int GraphValues = Shader.PropertyToID("GraphValues");
		private static readonly int GraphValuesLength = Shader.PropertyToID("GraphValuesLength");
		private static readonly int GraphMaxValue = Shader.PropertyToID("GraphMaxValue");
		private static readonly int GraphColorsLength = Shader.PropertyToID("GraphColorsLength");
		private static readonly int GraphColorsThresholds = Shader.PropertyToID("GraphColorsThresholds");
		private static readonly int GraphColors = Shader.PropertyToID("GraphColors");

		internal static void SetProperties(Material mat, float[] columns, float amplitude, ColumnColor[] colors)
		{
			mat.SetFloat(GraphMaxValue, amplitude);
			mat.SetFloatArray(GraphValues, columns);
			mat.SetInt(GraphValuesLength, columns.Length);
			mat.SetInt(GraphColorsLength, colors.Length);
			mat.SetFloatArray(GraphColorsThresholds, colors.Select(c => c.Min).ToArray());
			mat.SetColorArray(GraphColors, colors.Select(c => c.Color).ToArray());
		}
	}
}