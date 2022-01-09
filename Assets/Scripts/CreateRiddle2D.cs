using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRiddle2D : MonoBehaviour
{
    public List<GameObject> candyList = new List<GameObject>();

    public int candyAmount = 4;

    List<GameObject> riddleList = new List<GameObject>();

    public List<GameObject> slotList = new List<GameObject>();
    //Hide Solution Box
    Animator anim;
    public GameObject hideImage;


    //public Transform parent;
    void Start()
    {
        CreateTheRiddle();
        anim = hideImage.GetComponent<Animator>();
    }

    void CreateTheRiddle()
    {
        for (int i = 0; i < candyAmount; i++)
        {
            int num = Random.Range(0, candyList.Count);
            riddleList.Add(candyList[num]);
            GameObject candy = Instantiate(candyList[num] , slotList[i].transform , false);
            candy.transform.position = candy.transform.parent.position;
            candy.GetComponent<Drag2D>().enabled = false;

        }


    }

    public void CheckRiddle(int[] ids, DraggingBox sender)
    {
        int[] places1 = new int[4] {-1,-1,-1,-1};
        int[] places2 = new int[4] { -1, -1, -1, -1 };

        int exactMatches =0;
        int halfMatches = 0;

        //Black Check
        for (int i = 0; i < 4; i++)
        {
            if (ids[i] == riddleList[i].GetComponent<Drag2D>().candyId)
            {
                exactMatches++;
                sender.CreateHint(2);
                places1[i] = 1;
                places2[i] = 1;

            }
        }

        if (exactMatches == 4)
        {
            //Win Condition
            anim.SetTrigger("open");
            GameManager.instance.WinCondtion();
            return;
        }

        //White Check
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i !=j && (places1[i] !=1 ) && (places2[j] !=1) )
                {
                    if (ids[i] == riddleList[j].GetComponent<Drag2D>().candyId )
                    {
                        halfMatches++;
                        sender.CreateHint(1);
                        places1[i] = 1;
                        places2[j] = 1;
                        break;
                    }
                }
            }
        }

        //Update Trys
        GameManager.instance.SetTrys();
        if (!GameManager.instance.TrysLeft())
        {
            anim.SetTrigger("open");
        }

    }
}
