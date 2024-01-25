using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float Vie;
    public bool IsEnnemy;
    private Transform MyAnim;
    private Objectives Quest;
    private bool EnVie;
    
    void Start()
    {               //FOR RAGDOLL *troll*
        EnVie = true;
        Rigidbody[] RigidBodyKino = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody RB in RigidBodyKino)
        {
        RB.isKinematic = true;
        //RB.angularDrag = ;
        //RB.mass = RB.mass * 10;
        }
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;

        if (IsEnnemy == true)
        {
        MyAnim = GetComponentInChildren<AnimObject>().gameObject.transform;
        Quest = GameObject.Find("GameManager").GetComponent<Objectives>(); 
        
        }

        RagDoll();
        UnDoll();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damaged (int RecivedDamage)
    {
        if (EnVie == true){
        Vie = Vie - RecivedDamage;
        print (Vie);
        
        RagDoll();
        Invoke("ReBrain", 1f);

        if (Vie <= 0)
        {
            //this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            EnVie = false;
            if (IsEnnemy == true)
            {
                Quest.ObjectiveComplete();
                Invoke("Kill", 8);
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<GameOver>().GameOvers();
            }
            
        }
        }
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

    public void ReBrain()
    {
        if (Vie >= 0)
        {
            UnDoll();
        }
        
    }

    public void RagDoll()
    {
        Rigidbody[] RigidBodyKino = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody RB in RigidBodyKino)
        {
            RB.isKinematic = false;
        }

        if (IsEnnemy == true)
        {
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            Animator[] AnimKino = GetComponentsInChildren<Animator>();
            foreach (Animator Anim in AnimKino)
            {
                Anim.enabled = false;
            }
            
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;    
        }

        else {
            this.gameObject.GetComponent<FirstPersonMovement>().enabled = false;    
        }

        
        
    }

    public void UnDoll()
    {
        //print(MyAnim.position);
         if (IsEnnemy == true)
        {
            transform.position = MyAnim.position;
        }

        Rigidbody[] RigidBodyKino = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody RB in RigidBodyKino)
        {
            RB.isKinematic = true;
        }

        if (IsEnnemy == true)
        {
            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            Animator[] AnimKino = GetComponentsInChildren<Animator>();
            foreach (Animator Anim in AnimKino)
            {
                Anim.enabled = true;
            }

            this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        }

        else {
            this.gameObject.GetComponent<FirstPersonMovement>().enabled = true; 
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;   
        }
        
    }
}
