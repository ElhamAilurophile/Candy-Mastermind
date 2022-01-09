using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public List<DraggingBox> tryList = new List<DraggingBox> ();

    public GameObject Spacer; //Holder Spacer Parent

    int currentTurn =0;
    public int maxTurn;

    public WinLoseHandler handler;

    //Time
    int playTime;
    int seconds;
    int minutes;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GetDraggingBoxChilds();
        UpdateTrys ();
        handler.gameObject.SetActive (false);
        StartCoroutine("PlayTime");
    }

    void UpdateTrys()
    {
        tryList[currentTurn].SetActive(true);
    }

    void GetDraggingBoxChilds()
    {
        DraggingBox[] allChildren = Spacer.GetComponentsInChildren<DraggingBox>();
        tryList.AddRange(allChildren);
        tryList.Reverse ();
        maxTurn = tryList.Count;
    }

    public void SetTrys()
    {
        currentTurn++;
        if (currentTurn < maxTurn)
        {
            UpdateTrys();
            tryList[currentTurn-1].SetActive(false);
        }

        else
        {
            LoseCondition();
        }
    }

    void LoseCondition()
    {
        tryList[currentTurn - 1].SetActive(false);
        UpdateWinHandler(false);
    }

    public void WinCondtion()
    {
        tryList[currentTurn].SetActive(false);
        currentTurn++;
        UpdateWinHandler(true);

    }

    public bool TrysLeft()
    {
        return (currentTurn < maxTurn) ? true : false;
    }

    void UpdateWinHandler(bool win)
    {
        string showPlayTime = minutes.ToString("D2") + ":" + seconds.ToString("D2");

        handler.UpdateText(win, currentTurn,showPlayTime , CalculateScore());
        handler.gameObject.SetActive(true);
        StopCoroutine("PlayTime");
    }

    int CalculateScore()
    {
        int currentScore = 0;
        currentScore = 50000 - (currentTurn*1000) - (playTime*100);
        if (currentScore < 1000)
        {
            currentScore = 1000;
        }
        return currentScore;
    }
    IEnumerator PlayTime()
    {
        while (true) 
        {
            playTime++;
            seconds = playTime % 60;
            minutes = playTime / 60 % 60;    
            
            yield return new WaitForSeconds(1);

        }
    }


}
