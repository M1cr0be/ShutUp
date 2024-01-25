using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private GameObject FPC;

    private AudioSource punchSound;
    public AudioClip[] AudioArray;
    public GameObject SpawnSound;

     void Start()
    {
        FPC = GameObject.Find("/First Person Controller");
        SpawnSound = (GameObject)Resources.Load("DoSound", typeof(GameObject));
    }
    
    public void GameOvers (){
        FPC.GetComponentInChildren<PunchUniversal>().enabled = false;
        FPC.GetComponent<Jump>().enabled = false;
        FPC.GetComponent<Crouch>().enabled = false;
        GameObject.Find("GameOver").GetComponent<RawImage>().enabled = true;
        GameObject.Find("GameOver1").GetComponent<RawImage>().enabled = true;


        GameObject newSound = Instantiate(SpawnSound);
        punchSound = newSound.GetComponent<AudioSource>();
        
        punchSound.clip = AudioArray[Random.Range(0, AudioArray.Length)];
        punchSound.Play();
    }
}
