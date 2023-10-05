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
                                "W: forward     S: back \n"+ 
                                "A: turn left    D: turn right \n"+
                                "space: jump \n"+
                                "left arrow: lower light \n"+
                                "right arrow: higher light \n"+
                                "up arrow: light rotate up \n"+
                                "down arrow: light rotate down \n"+
                                "-------------------------------------------------------------------- \n\n"+
                                "              : transportation door \n\n"+
                                "Can transform you to a specified place. You have to go into the next transportation door that is nearest to you. \n\n\n"+
                                "              : gate \n\n\n"+
                                "Move left and right or up and down repeatly. If you colloid them, you'll get hurt.\n\n"+
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
