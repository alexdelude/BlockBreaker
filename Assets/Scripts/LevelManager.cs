using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {



	public void LoadLevel(string name){
		Debug.Log ("Level load requested for: " + name);
		Block.breakableCount = 0;
		Application.LoadLevel (name);
	}

	public void QuitRequest(){
		
		Application.Quit();
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
		Block.breakableCount = 0;
	}

	public void BrickDestroyed () {
		
		if(Block.breakableCount <= 0 ){
			LoadNextLevel ();
		}
	}
}
