using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWall : MonoBehaviour {

	public AudioSource hitNoise;

	void OnCollisionEnter2D(Collision2D collision) {
		hitNoise.Play();

		// Slightly randomize vector

	}
}
