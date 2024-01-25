using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoingMove : MonoBehaviour
{
    float step;
    public float speed;
    public Transform Startpos;
    public Transform EndPos;
    bool IsMovingBack;
    public bool checkbox;
    private MeshRenderer Mesh;

    // Start is called before the first frame update
    void Start()
    {
        step = speed*Time.deltaTime;
        Mesh = GetComponent<MeshRenderer>();
        Mesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMovingBack && checkbox)
        {
            Mesh.enabled = true;
            transform.position = Vector3.MoveTowards(transform.position, EndPos.position, step);
            if (Vector3.Distance(transform.position, EndPos.position) <= 0.1f)
            {
                IsMovingBack = true;
                checkbox = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Startpos.position, step);

            if (Vector3.Distance(transform.position, Startpos.position) <= 0.1f)
            {
                IsMovingBack = false;
                Mesh.enabled = false;
            }
        }
    }
}
