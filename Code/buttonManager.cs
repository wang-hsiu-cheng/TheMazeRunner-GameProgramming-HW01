using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    [SerializeField] GameObject []GUI;
    [SerializeField] Transform textPannel;
    [SerializeField] GameObject []gra;
    static public bool game_start = false, describePannel = false, GUIchange = false;
    [SerializeField] Text describtion;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            GUI[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GUIchange) {
            for (int i = 0; i < 3; i++)
                GUI[i].SetActive(true);
            GUIchange = false;
        }
    }
    public void OnStartClicked()
    {
        Debug.Log(game_start);
        for (int i = 0; i < 3; i++) {
            GUI[i].SetActive(false);
        }
        game_start = true;
    }
    public void OnSettingClicked()
    {

    }
    public void OnDescribeClick()
    {
        if (describePannel == false) {
            for (int i = 0; i < 3; i++) {
                gra[i].SetActive(true);
            }
            describtion.text = "DESCRIPTION \n\n"+
                                "W: forward \n"+
                                "S: back \n"+
                                "A: turn left \n"+
                                "D: turn right \n"+
                                "------------------------------------------ \n\n"+
                                "              : transportation door \n\n"+
                                "can transform you to a specified place. \n\n\n"+
                                "              : gate \n\n\n"+
                                "can move left and right repeatly. \n\n"+
                                "              : golden cup \n\n"+
                                "get it to complete the game by taking the transportation doors around the map!\n";
            describePannel = true;
        }
        else {
            describtion.text = "\n";
            describePannel = false;
            for (int i = 0; i < 3; i++) {
                gra[i].SetActive(false);
            }
        }
    }
}
