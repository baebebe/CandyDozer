using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour {

	public CandyHolder candyHolder;
	public int reward;
	public GameObject effectPrefab;
	public Vector3 effectRotation;
	int score = 0;
	public int scoreNum;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Candy") {
			candyHolder.AddCandy (reward);
			if(reward != 0)
				score += scoreNum;
			Destroy (other.gameObject);

			if (effectPrefab != null) {
				Instantiate (effectPrefab, other.transform.position, Quaternion.Euler (effectRotation));
			}
		}
	}

	void OnGUI(){
		if (reward != 0) {
			GUI.color = Color.black;
			string label = "Score: " + score;
			GUI.Label (new Rect (0, 30, 100, 30), label);
		}
	}
}
