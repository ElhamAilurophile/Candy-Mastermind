using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinLoseHandler : MonoBehaviour
{
    public Text winLoseText;
    public Text turnsTakenText;
    public Text timeTakenText;
    public Text Score;

    public void UpdateText(bool win,int turns, string time, int score)
    {
        if (win)
        {
            winLoseText.text = "You Won!";
            turnsTakenText.text = "Turns Taken :" + turns;
            timeTakenText.text = "Time Taken :" + time;
            Score.text = "Your Score :" + score;
        }

        if (!win) //Losing
        {
            winLoseText.text = "You Lose :(";
            turnsTakenText.text = "Turns Taken :" + turns;
            timeTakenText.text = "Time Taken :" + time;
            Score.text = "Your Score :" + score;
        }
    }
 
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
