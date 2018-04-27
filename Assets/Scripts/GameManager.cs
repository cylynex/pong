using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject ball;

	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			ball.GetComponent<Rigidbody2D>().velocity = new Vector2(5f,5f);
		}	
	}
}
