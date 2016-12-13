﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;
	
	private Ball ball;
	//public AudioClip boing;
	// Use this for initialization
	void Start ()
	{
		ball = FindObjectOfType<Ball> ();
		
	}
	// Update is called once per frame
	void Update ()
	{	
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}
	void AutoPlay ()
	{
		Vector3 paddlePos = new Vector3 (.5f, this.transform.position.y, 0f);
		Vector3 ballPos = (ball.transform.position);
		paddlePos.x = Mathf.Clamp (ballPos.x, .5f, 15.5f);
		this.transform.position = paddlePos;
	
	}
	
	void MoveWithMouse ()
	{
		Vector3 paddlePos = new Vector3 (.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		paddlePos.x = Mathf.Clamp (mousePosInBlocks, .5f, 15.5f);
		this.transform.position = paddlePos;
	
	}
	
	void oncollisionenter2d (Collision collision)
	{
		//AudioSource.PlayClipAtPoint (boing, transform.position);
	}
		
}
