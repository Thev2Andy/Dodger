using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject DeathUIObject;
	public GameObject GameUIObject;
	public Text DeathScoreText;

	// Singletons.
	public static UIController Instance;

	private void Awake()
	{
	   if(Instance != this) {
		   Destroy(this);
	   }

	   Instance = this;
	}
	
	public void DeathUI()
	{
		DeathUIObject.SetActive(true);
		GameUIObject.SetActive(false);
		DeathScoreText.text = $"{((ScoreCounter.Instance.Score > (PlayerPrefs.GetInt("PlayerHighscore", 0))) ? "New Highscore" : "Score")}: {ScoreCounter.Instance.Score}";
	}
}
