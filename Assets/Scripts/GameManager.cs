using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject ball;
	public GameObject ballPrefab;
	Vector3 ballStartLocation;
	public int player1Score = 0;
	public int player2Score = 0;

	public Text p1ScoreBoard;
	public Text p2ScoreBoard;

	void Start() {
		ballStartLocation = new Vector3(5,0,0);
	}
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space)) {
			ball.GetComponent<Rigidbody2D>().velocity = new Vector2(5f,5f);
		}	
	}


	public void UpdateScores() {
		p1ScoreBoard.text = player1Score.ToString();
		p2ScoreBoard.text = player2Score.ToString();
	}


	// Reset the ball
	public void ResetBall() {
		//Destroy(ball);
		//Instantiate(ballPrefab,ballStartLocation,Quaternion.identity);
		ball.transform.position = ballStartLocation;
		ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
	}
}
