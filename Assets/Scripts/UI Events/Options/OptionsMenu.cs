using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Text PPFXText;
    public Text GFXText;

    private void Start()
    {
        PPFXText.text = ($"Post Processing: {((PlayerPrefs.GetInt("PostProcessing", 1) == 1) ? "On" : "Off")}");
        GFXText.text = ($"Graphics: {QualitySettings.names[QualitySettings.GetQualityLevel()]}");
    }

    public void TogglePostProcessing()
    {
        bool CurrentStatus = ((PlayerPrefs.GetInt("PostProcessing", 1) == 1) ? true : false);
        PlayerPrefs.SetInt("PostProcessing", ((!CurrentStatus) ? 1 : 0));

        PPFXText.text = ($"Post Processing: {((!CurrentStatus) ? "On" : "Off")}");
    }

    public void ToggleGFX()
    {
        int OldQualityIndex = QualitySettings.GetQualityLevel();
        QualitySettings.IncreaseLevel(true);

        if(OldQualityIndex == QualitySettings.GetQualityLevel())
        {
            QualitySettings.SetQualityLevel(0, true);
        }

        PlayerPrefs.SetInt("GFXLevel", QualitySettings.GetQualityLevel());

        GFXText.text = ($"Graphics: {QualitySettings.names[QualitySettings.GetQualityLevel()]}");
    }

    public void ResetGameData()
    {
        PlayerPrefs.DeleteAll();
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
