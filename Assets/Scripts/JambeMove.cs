using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JambeMove : MonoBehaviour
{
    float step;
    public float speed;
    public Transform StartPos;
    public Transform EndPos;
    bool IsMovingBack;
    public bool checkBox;
    private MeshRenderer Mesh;

    // Start is called before the first frame update
    void Start()
    {
        step = speed * Time.deltaTime;
        Mesh = this.gameObject.GetComponentInChildren<MeshRenderer>();
        Mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMovingBack && checkBox)
        {
            Mesh.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, EndPos.position, step);
            //Vector3 rotationDirection = EndPos.position - transform.position;
            //Quaternion targetRotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 6f);

            if (Vector3.Distance(transform.position, EndPos.position) <= 0.1f)
            {
                IsMovingBack = true;
                checkBox = false;
            }
        }
        else if (IsMovingBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position, step);
            //Vector3 rotationDirection = StartPos.position - transform.position;
            //Quaternion targetRotation = Quaternion.LookRotation(rotationDirection, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 6f);


            if (Vector3.Distance(transform.position, StartPos.position) <= 0.1f)
            {
                IsMovingBack = false;
                Mesh.enabled = false;
            }
        }
    }
}
