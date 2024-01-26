using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anykey : MonoBehaviour
{
    public bool started;
    private GameObject FPC;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        Cursor.lockState = CursorLockMode.Confined;
        FPC = GameObject.Find("First Person Controller");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && started == false)
        {
            started = true;
            Debug.Log("A key or mouse click has been detected");
            Cursor.lockState = CursorLockMode.Locked;
            GameObject.Find("Title").GetComponent<RawImage>().enabled = false;
            GameObject.Find("Mouse").GetComponent<RawImage>().enabled = false;
            GameObject.Find("MOVE").GetComponent<RawImage>().enabled = false;
            GameObject.Find("Rage").GetComponent<RawImage>().enabled = false;
            GameObject.Find("Retry").GetComponent<RawImage>().enabled = false;
            GameObject.Find("Press").GetComponent<RawImage>().enabled = false;
            
            this.gameObject.GetComponent<Objectives>().ShowObjectives();
        }
    }
}
