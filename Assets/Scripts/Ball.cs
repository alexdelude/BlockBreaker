using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle; 
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	

	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			//locks the ball to the paddle until launch
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//launches the ball when mouse is clicked
			if (Input.GetMouseButtonDown (0)) {
				print ("mouse clicked, launch ball");
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		AudioSource audio = GetComponent<AudioSource> ();

		Vector2 variance = new Vector2 (Random.Range(0f,0.2f), Random.Range(0f,0.2f));

		if (hasStarted == true) {
			audio.Play ();
			GetComponent<Rigidbody2D> ().velocity += variance;
		}
	
	}

}
