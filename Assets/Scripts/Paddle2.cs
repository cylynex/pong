using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour {

	public float speed = 5f;
	public AudioSource hitNoise;
	public GameManager scoreKeeper;

	private float upperLimit = 2.4f;
	private float lowerLimit = -3f;

	void Update () {
		GetMovement();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		hitNoise.Play();
		if (GameManager.gameMode == 2) { 
			scoreKeeper.LightningSplit(transform);
		}
	}
	void GetMovement() {
		if (Input.GetKey("o")) {
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey("l")) {
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}

		Vector3 pos = transform.position;
		pos.y = Mathf.Clamp(pos.y, lowerLimit, upperLimit);
		transform.position = pos;

	}
}
