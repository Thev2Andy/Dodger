using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPFXObject : MonoBehaviour
{
    public GameObject PPObject;

    private void Update() {
        PPObject.SetActive(((PlayerPrefs.GetInt("PostProcessing", 1) == 1) ? true : false));
    }
}
