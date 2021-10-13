using GUIGraphDrawer.Scripts.Utilities;
using GUIGraphDrawer.Scripts.ValueObjects;
using UnityEngine;

namespace GUIGraphDrawer.Sample.Scripts
{
#if UNITY_EDITOR
	[UnityEditor.CustomEditor(typeof(PerlinNoise))]
	public class PerlinNoiseInspector : UnityEditor.Editor
	{
		private PerlinNoise _target;

		private void OnEnable()
		{
			_target = (PerlinNoise)target;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			GUILayoutUtilities.Graph("Perlin Noise", 128, _target.GraphAmplitude, _target.Columns, _target.Bars, _target.Colors);
		}
	}
#endif

	[ExecuteAlways]
	public class PerlinNoise : MonoBehaviour
	{
		[SerializeField, Range(1, 1023)] private int _perlinNoiseSamples = 256;
		[SerializeField] private float _perlinNoiseFrequency = 0.8f;
		[SerializeField] private float _perlinNoiseAmplitude = 0.86f;
		[field: SerializeField] public float GraphAmplitude { get; private set; } = 1f;
		[field: SerializeField] public float[] Bars { get; private set; } = { 0.33f, 0.66f };

		[field: SerializeField] public ColumnColor[] Colors { get; private set; } =
		{
			new ColumnColor(0.00f, new Color(0.16f, 0.67f, 0.73f)),
			new ColumnColor(0.33f, new Color(0.18f, 0.38f, 0.53f)),
			new ColumnColor(0.66f, new Color(0.94f, 0.98f, 0.83f)),
		};

		[field: SerializeField] public float[] Columns { get; private set; }

		private void Reset()
		{
			CalculateValues();
		}

		private void OnValidate()
		{
			CalculateValues();
		}

		private void OnGUI()
		{
			var area = new Rect(4, 4, 360, 64);
			GUIUtilities.Graph(area, "Perlin Noise", GraphAmplitude, Columns, Bars, Colors);
		}

		private void CalculateValues()
		{
			Columns = new float[_perlinNoiseSamples];

			for (int i = 0; i < _perlinNoiseSamples; i++)
			{
				Columns[i] = Mathf.Clamp01(Mathf.PerlinNoise(i * _perlinNoiseFrequency, 0)) * _perlinNoiseAmplitude;
			}
		}
	}
}