using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] GameObject resultText;
    [SerializeField] GameObject resultWindow;
    [SerializeField] GameObject retry;
    Text text;
    int score = 0;
    public bool result;
    void Start()
    {
        text = resultText.GetComponent<Text>();
        resultText.SetActive(false);
        resultWindow.SetActive(false);
        retry.SetActive(false);
        result = false;
    }
    void Update()
    {

    }

    public void PlayScore()
    {
        resultText.SetActive (true);
        text .text = "your score \n"+ score.ToString()+" point";
        retry.SetActive (true); 
        resultWindow.SetActive(true);
    }
    public void PulsScore()
    {
        score++;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
    }
}
