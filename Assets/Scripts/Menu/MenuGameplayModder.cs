using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGameplayModder : MonoBehaviour
{
	public float TriangleX = 1f;

    void Start()
    {
		StartCoroutine(DrawThumbTriangle());
    }

	IEnumerator DrawThumbTriangle()
	{
		yield return new WaitForSeconds(0.2f);
		Player.instance.AddThumb(new Vector3(0, TriangleX, 0));
		Player.instance.AddThumb(new Vector3(TriangleX, 0, 0));
		Player.instance.AddThumb(new Vector3(0, -TriangleX, 0));
		Player.instance.AddThumb(new Vector3(0, 0, 0));
		Player.instance.AddThumb(new Vector3(TriangleX / 3, 0, 0));
	}

    void Update()
    {
        
    }
}
