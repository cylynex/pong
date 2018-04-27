using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour {

	public float speed = 5f;
	public AudioSource hitNoise;
	void Update () {
		GetMovement();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		hitNoise.Play();
	}
	void GetMovement() {
		if (Input.GetKey("o")) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey("l")) {
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
	}
}
