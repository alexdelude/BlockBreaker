using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject Smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) { //keeps track of breakable bricks
			breakableCount++;  
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col){

		AudioSource audio = GetComponent<AudioSource> ();
		AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;

		if (timesHit >= maxHits) { //in case we go over max hits in the future with power ups etc
			breakableCount--;
			levelManager.BrickDestroyed ();
	
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void SimulateWin (){
		levelManager.LoadNextLevel ();
	}

	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
		

}
