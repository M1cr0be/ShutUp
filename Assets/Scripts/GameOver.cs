using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameObject FPC;

     void Start()
    {
        FPC = GameObject.Find("/First Person Controller");
    }
    
    public void GameOvers (){
        FPC.GetComponentInChildren<PunchUniversal>().enabled = false;
        FPC.GetComponent<Jump>().enabled = false;
        FPC.GetComponent<Crouch>().enabled = false;
        GameObject.Find("GameOver").GetComponent<RawImage>().enabled = true;
        GameObject.Find("GameOver1").GetComponent<RawImage>().enabled = true;
    }
}
