using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeDisplay;
    float totalTimePassed;
    void Update()
    {
        totalTimePassed += Time.deltaTime;
        if (Mathf.Round(totalTimePassed)== 160)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        timeDisplay.text = "Time:" + Mathf.Round(totalTimePassed);
    }
}
