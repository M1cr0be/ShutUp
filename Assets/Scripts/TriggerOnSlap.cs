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

    private AudioSource punchSound;
    public AudioClip[] AudioArray;
    public GameObject SpawnSound;


    void Start()
    {
        SoundToStop = this.gameObject.GetComponent<AudioSource>();
        SpawnSound = (GameObject)Resources.Load("DoSound", typeof(GameObject));
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
            Invoke("EndMePlease", 1f);
            if (WakeEnnemy != null)
            {
                Invoke("SlowReaction", 0.5f);
                GameObject newSound = Instantiate(SpawnSound);
                punchSound = newSound.GetComponent<AudioSource>();
                
                punchSound.clip = AudioArray[Random.Range(0, AudioArray.Length)];
                punchSound.Play();

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

    private void EndMePlease()
    {
        if(this.gameObject.GetComponent<MeshCollider>() != null)
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
        if(this.gameObject.GetComponent<BoxCollider>() != null)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
