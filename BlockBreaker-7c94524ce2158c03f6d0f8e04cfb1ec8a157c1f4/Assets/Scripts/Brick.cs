using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public GameObject smoke;
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
		//AudioSource.PlayClipAtPoint (crack, transform.position);
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
			print (breakableCount);
			levelManager.BrickDestroyed ();
			//The smoke code for some reason does not work -> should generate smoke on destroy of color of brick
			GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer> ().color;
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