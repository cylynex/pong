using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject ball;
	public GameObject ballPrefab;
	Vector3 ballStartPlayer1;
	Vector3 ballStartPlayer2;
	public int player1Score = 0;
	public int player2Score = 0;

	public Text p1ScoreBoard;
	public Text p2ScoreBoard;

	Vector2 ballStartDirection;

	void Start() {
		ballStartPlayer2 = new Vector3(-5,0,0);
		ballStartPlayer1 = new Vector3(5,0,0);
		ballStartDirection = new Vector2(5f,5f);
	}
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			ball.GetComponent<Rigidbody2D>().velocity = ballStartDirection;
		}	
	}


	public void UpdateScores() {
		p1ScoreBoard.text = player1Score.ToString();
		p2ScoreBoard.text = player2Score.ToString();
	}


	// Reset the ball and put on the side of whoever just got scored on.
	public void ResetBall(int side) {
		//Destroy(ball);
		//Instantiate(ballPrefab,ballStartLocation,Quaternion.identity);
		Vector3 ballSpot;
		float randSpin = Random.Range(1f,10f);
		if (side == 1) {
			ballSpot = ballStartPlayer2;
			ballStartDirection = new Vector2(5f,randSpin);
		} else {
			ballSpot = ballStartPlayer1;
			ballStartDirection = new Vector2(-5f,randSpin);
		}

		ball.transform.position = ballSpot;
		ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}
}
