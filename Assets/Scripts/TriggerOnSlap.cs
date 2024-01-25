using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnSlap : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator WakeEnnemy;
    public int QuestObject;
    private AudioSource SoundToStop;
    private bool BreakingOnce;


    void Start()
    {
        SoundToStop = this.gameObject.GetComponent<AudioSource>();
        BreakingOnce = false;
        if (WakeEnnemy != null)
        {
            Invoke("UglyStart", 0.5f);
        }
        
    }

    private void UglyStart()
    {
        WakeEnnemy.enabled = false;
        WakeEnnemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
    }

    public void SlapObject()
    {
        if (BreakingOnce == false)
        {
            BreakingOnce = true;
            if (WakeEnnemy != null)
            {
                Invoke("SlowReaction", 0.5f);
            }
            if (QuestObject != 0)
            {
                SoundToStop.enabled = false;
                GameObject.Find("GameManager").GetComponent<Objectives>().ObjectiveComplete();
            }
        }

    }
    private void SlowReaction()
    {
        WakeEnnemy.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        WakeEnnemy.enabled = true;
    }
}
