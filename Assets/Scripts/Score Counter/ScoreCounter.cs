using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text ScoreText;
    [HideInInspector] public int Score;

    // Singletons.
    public static ScoreCounter Instance;

    private void Awake()
    {
        Instance = this;
        if(Instance != this) {
            this.gameObject.name = $"{this.gameObject.name} (Dead Singleton)";
            Destroy(this);
        }
    }

    private void Start() {
        UpdateUI();
    }

    public void ModifyScore(int Value, bool UpdateUI) {
        Score += Value;
        if(UpdateUI && ScoreText != null) ScoreText.text = $"Score: {Score}";

        if(Score > (PlayerPrefs.GetInt("PlayerHighscore", 0))) PlayerPrefs.SetInt("PlayerHighscore", Score);
    }

    public void UpdateUI() {
        if(ScoreText != null) ScoreText.text = $"Score: {Score}";
    }
}
