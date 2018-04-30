using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[Header("Ball Stuff")]
	public GameObject ball;
	public GameObject ballPrefab;
	Vector3 ballStartPlayer1;
	Vector3 ballStartPlayer2;
	Vector2 ballStartDirection;
	public static int ballCount;
	
	[Header("Score Stuff")]
	public int player1Score = 0;
	public int player2Score = 0;
	public Text p1ScoreBoard;
	public Text p2ScoreBoard;

	[Header("Sounds")]
	public AudioSource pointScoredNoise;
	public AudioSource hitWallNoise;
	public AudioSource laugh;

	[Header("Paddles")]
	public GameObject paddle1;
	public GameObject paddle2;
	
	[Header("UI Misc")]
	public Text haha;
	public Text player1title;
	public Text player2title;

	[Header("Mode")] // 1: evil 2: lightning
	public static int gameMode = 2;
	
	void Start() {
		ballStartPlayer2 = new Vector3(-5,0,0);
		ballStartPlayer1 = new Vector3(5,0,0);
		ballStartDirection = new Vector2(5f,5f);
		ballCount = 1;

		// Evil mode setup
		if (gameMode == 1) { 
			InvokeRepeating("EvilMode", 0f, 10f);
		}
	}
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			ball.GetComponent<Rigidbody2D>().velocity = ballStartDirection;
		}	

		// Test mode only - makes p2 automated
		MatchBall();
	}


	// Fuck with player
	void EvilMode() {
		int hahaRoll = Random.Range(1,3);
		if (hahaRoll < 3) {
			if (hahaRoll == 1) {
				laugh.Play();
				player1title.color = Color.red;
				player2title.color = Color.white;
				paddle1.transform.localScale -= new Vector3(0,2f,0);
				haha.text = "Fucking with Player 1...";
			} else if (hahaRoll == 2) {
				laugh.Play();
				player2title.color = Color.red;
				player1title.color = Color.white;
				paddle2.transform.localScale -= new Vector3(0,2f,0);
				haha.text = "Fucking with Player 2...";
			}
		}
	}

	// Test Script to autoplay
	void MatchBall() {
		float ySpot = ball.transform.position.y;
		Vector3 paddle1Spot = new Vector3(paddle1.transform.position.x, ySpot,paddle1.transform.position.z);
		Vector3 paddle2Spot = new Vector3(paddle2.transform.position.x, ySpot,paddle2.transform.position.z);
		//paddle1.transform.position = paddle1Spot;
		paddle2.transform.position = paddle2Spot;
	}

	// Update the scoreboard
	public void UpdateScores() {
		p1ScoreBoard.text = player1Score.ToString();
		p2ScoreBoard.text = player2Score.ToString();
	}

	// Sound for when scoring
	public void ScoreSound() {
		pointScoredNoise.Play();
	}

	// Sound for when hitting the top and bottom wall
	public void HitWall() {
		hitWallNoise.Play();
	}

	// Reset the ball and put on the side of whoever just got scored on.
	public void ResetBall(int side) {
		pointScoredNoise.Play();
		//Destroy(ball);
		ballCount--;
		if (ballCount == 0) {
			Vector3 ballSpot;
			float randSpin = Random.Range(1f,10f);
			if (side == 1) {
				ballSpot = ballStartPlayer2;
				ballStartDirection = new Vector2(5f,randSpin);
			} else {
				ballSpot = ballStartPlayer1;
				ballStartDirection = new Vector2(-5f,randSpin);
			}

			ballCount++;
			ball = (GameObject)Instantiate(ballPrefab,ballSpot,Quaternion.identity);
			//ball.transform.position = ballSpot;
			ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
	}


	// Lightning Mode - Split the ball
	public void LightningSplit(Transform splitSpot) {
		int splitChance = Random.Range(1,10);
		if (splitChance > 8) {
			// Ball has split, figure out into how many
			//int numBalls = Random.Range(1,3);
			//for(int i=0; i <= numBalls; i++) {
				// Make the ball
				GameObject thisball = (GameObject)Instantiate(ballPrefab,splitSpot.position,Quaternion.identity);
				Renderer ballRend = thisball.GetComponent<Renderer>();

				// Give it a thrust
				int rand1 = Random.Range(-5,5);
				int rand2 = Random.Range(-5,5);
				thisball.GetComponent<Rigidbody2D>().velocity = new Vector2(rand1,rand2);
				ballCount++;
			//}
		}
	}
}
