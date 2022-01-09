using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.UI;

public class DraggingBox : MonoBehaviour
{
    public GameObject protector;

    public bool isActive;

    public Button checkButton;

    public int[] candyIds = new int[4];

    public CreateRiddle2D riddle;

    //Hint
    public GameObject hintBox;
    public GameObject blueHintBear;
    public GameObject whiteHintBear;

    void Start()
    {
        checkButton.interactable = false;
    }

    public void SetID(int slot, int ID)
    {
        candyIds[slot] = ID;
        checkButton.interactable = (!candyIds.Contains(0) ? true : false) ;

    }

    //Pressing Check Buttom

    public void CheckSolution()
    {
        riddle.CheckRiddle(candyIds, this);

        checkButton.interactable = false;
    }

    public void CreateHint(int hint)
    {
        //Create A Blue Hint Bear
        if(hint == 2)
        {
            Instantiate(blueHintBear, hintBox.transform, false);
        }

        //Create A White Hint Bear
        if (hint == 1)
        {
            Instantiate(whiteHintBear, hintBox.transform, false);
        }
    }

    public void SetActive(bool active)
    {
        isActive = (active== true) ? true : false;
        protector.SetActive(!active);
    }
}
