using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrawLines : MonoBehaviour
{
	private List<Vector3> _positions;

	private void OnPostRender()
	{
		if (Player.instance.IsGameOver()) return;

		_positions = Player.instance.GetPositions();

		GL.PushMatrix();
		Player.instance.LineMaterial.SetPass(0);

		DrawLines(Vector3.zero);
		DrawLines(Vector3.up * 0.01f);
		DrawLines(Vector3.down * 0.01f);
		DrawLines(Vector3.left * 0.01f);
		DrawLines(Vector3.right * 0.01f);
		DrawLines((Vector3.up + Vector3.left) * 0.01f);
		DrawLines((Vector3.up + Vector3.right) * 0.01f);
		DrawLines((Vector3.down + Vector3.left) * 0.01f);
		DrawLines((Vector3.down + Vector3.right) * 0.01f);

		GL.PopMatrix();
	}

	private void DrawLines(Vector3 offset)
	{
		for (int i = 0; i < _positions.Count - 1; i++)
		{
			GL.Begin(GL.LINES);
			GL.Color(Player.instance.LineColor);
			GL.Vertex(_positions[i] + offset);
			GL.Vertex(_positions[i + 1] + offset);
			GL.End();
		}
	}
}
