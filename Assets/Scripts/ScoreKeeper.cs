using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	private int currentScore = 0;
	private Text myText;
	
	void Start(){
		myText = GetComponent<Text>();
		myText.text = currentScore.ToString();
	}
	
	public void Score(int points){
		currentScore = currentScore + points;
		myText.text = currentScore.ToString();
	}
	
	void Reset(){
		currentScore = 0;
	}
}
