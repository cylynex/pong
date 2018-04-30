using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Score : MonoBehaviour {

	public GameManager scorekeeper;

	void OnCollisionEnter2D(Collision2D collision) {
		Destroy(collision.gameObject);
		scorekeeper.player2Score++;
		scorekeeper.UpdateScores();
		scorekeeper.ResetBall(2);
	}
}
