using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public Paddle paddle;
	private bool hasStarted = false; 
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start ()
	{
		paddleToBallVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			// lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//Wait for a mouse press to launch
			if (Input.GetMouseButtonDown (0)) {
				print ("Mouse Clicked, Ball Launched");
				this.rigidbody2D.velocity = new Vector2 (2f, 13f);
				hasStarted = true;
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{	
		Vector2 tweak = new Vector2 (Random.Range (0f, .2f), Random.Range (0f, .2f));
		if (hasStarted) {
			//audio.Play ();
			rigidbody2D.velocity += tweak;
		}
		
		
	}
}

