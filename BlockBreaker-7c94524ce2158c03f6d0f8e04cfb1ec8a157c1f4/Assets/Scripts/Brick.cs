using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public AudioClip crack;
	private int timesHit;
	private LevelManager levelManager;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	private bool isBreakable;
	// Use this for initialization
	void Start ()
	{
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;

		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}
	
	void HandleHits ()
	{
		timesHit += 1;
		int maxHits = hitSprites.Length + 1;
		print (timesHit);
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}
	void LoadSprites ()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
	//TODO remove this method
	void SimulateWin ()
	{
		levelManager.LoadNextLevel ();
	}
}