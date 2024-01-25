using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchUniversal : MonoBehaviour
{
    public bool PlayerPunch;
    public bool IsActive;
    public List<GameObject> ObjectsInCollision = new List<GameObject>();
    private Transform whereImLooking;
    private AudioSource punchSound;
    public AudioClip[] AudioArray;
    private PoingMove poingMove;
    private JambeMove jambeMove;

    void Start()
    {
        whereImLooking = this.gameObject.transform.parent.transform;
        punchSound = GetComponentInChildren<AudioSource>();

        if (PlayerPunch == true)
        {
            poingMove =  this.transform.parent.GetComponentInChildren<PoingMove>();
            jambeMove =  this.transform.parent.GetComponentInChildren<JambeMove>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent == null)
        {
            ObjectsInCollision.Add(other.gameObject);
        }
        
    }

    void OnTriggerExit(Collider others)
    {
        if (others.gameObject.transform.parent == null)
        {
        ObjectsInCollision.Remove(others.gameObject);
        }
    }

    void Update()
    {
        if (PlayerPunch == false && IsActive == true)
        {
            Slapping();
        }


        else if (Input.GetMouseButtonDown(0) && PlayerPunch == true)
        {
            poingMove.checkbox = true;
            Slapping();
        }

        else if (Input.GetMouseButtonDown(1) && PlayerPunch == true)
        {
            jambeMove.checkBox = true;
            Slapping();
        }
    }



    private void Slapping()
    {
        ObjectsInCollision.RemoveAll(s => s == null);
        foreach (GameObject ObjectInColl in ObjectsInCollision)
            {
                if(ObjectInColl.GetComponent<Rigidbody>() != null)
                {
                    punchSound.Play();


                    Rigidbody RB = ObjectInColl.GetComponent<Rigidbody>();
                    Vector3 direction = RB.transform.position - transform.position;
                    RB.AddForceAtPosition(direction.normalized * 25, whereImLooking.position, ForceMode.VelocityChange );

                    if(ObjectInColl.GetComponent<Health>() != null)
                    {
                        Health Health = ObjectInColl.GetComponent<Health>();
                        Health.Damaged(15);
                    }

                    if(ObjectInColl.GetComponent<TriggerOnSlap>() != null)
                    {
                        ObjectInColl.GetComponent<TriggerOnSlap>().SlapObject();
                    }
                }
            }
    }
    

}


