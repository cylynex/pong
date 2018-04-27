using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Score : MonoBehaviour {

	public GameManager scorekeeper;

	void OnCollisionEnter2D(Collision2D collision) {
		scorekeeper.player1Score++;
		scorekeeper.UpdateScores();
		scorekeeper.ResetBall();
	}
}
