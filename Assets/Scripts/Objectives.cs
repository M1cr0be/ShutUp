using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objectives : MonoBehaviour
{
    public int ObjectifsAccomplis;
    private GameObject UIObjectives;
    // Start is called before the first frame update
    private int HowMuchDoIGetDown;
    private bool StopShow;
    public bool CanIGetLower;
    public TextMeshProUGUI scoreUI;
    void Start()
    {
        ObjectifsAccomplis = 22;
        UIObjectives = GameObject.Find("Objectives"); 
        scoreUI.text = "Remaining noice nuisance: " + ObjectifsAccomplis;
        StopShow = false;
        ShowObjectives();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanIGetLower == true && HowMuchDoIGetDown < 285)
        {
            HowMuchDoIGetDown += 4;
            UIObjectives.transform.position = UIObjectives.transform.position + new Vector3 (0,-4,0);
            if (HowMuchDoIGetDown >= 285)
            {
                CanIGetLower = false;
                HowMuchDoIGetDown = 0;
            }
            
            
        }
    }

    private void ShowObjectives()
    {
            CanIGetLower = true;
    }

    private void LastObjectif()
    {
        CanIGetLower = true;
        StopShow = true;
    }

    public void ObjectiveComplete()
    {
        ObjectifsAccomplis -=1;
        scoreUI.text = "Remaining noice nuisance: " + ObjectifsAccomplis;
        if (ObjectifsAccomplis <= 0 && StopShow == false)
        {
            LastObjectif();
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FirstPersonMovement>())
        {
            if (StopShow == true)
            {
                GameObject.Find("Congratulation").GetComponent<RawImage>().enabled = true;
                
            }
            
        }
    }




}
