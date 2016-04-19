﻿using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour
{

	public float rotationPerSecond = 0.1f;
	public int levelShown = 0;
	
	// Update is called once per frame
	void Update ()
	{
		int currLevel = Mathf.FloorToInt (Hero.S.shieldLevel);

		Renderer renderer = GetComponent<Renderer> ();

		if (renderer && levelShown != currLevel) {
			levelShown = currLevel;
			Material mat = renderer.material;
			// change shield
			mat.mainTextureOffset = new Vector2 (0.2f * levelShown, 0);
		}
		// rotate shield

		float rZ = (rotationPerSecond * Time.time * 360) % 360f;
		transform.rotation = Quaternion.Euler (0, 0, rZ);
	}
}
