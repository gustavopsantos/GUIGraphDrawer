using System;
using UnityEngine;

namespace GUIGraphDrawer.Scripts.ValueObjects
{
	[Serializable]
	public struct ColumnColor
	{
		public float Min;
		public Color Color;

		public ColumnColor(float min, Color color)
		{
			Min = min;
			Color = color;
		}
	}
}