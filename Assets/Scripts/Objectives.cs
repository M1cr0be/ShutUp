using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives : MonoBehaviour
{
    public int ObjectifsAccomplis;
    private GameObject UIObjectives;
    // Start is called before the first frame update
    private int HowMuchDoIGetDown;
    public bool CanIGetLower;
    void Start()
    {
        ObjectifsAccomplis = 0;
        UIObjectives = GameObject.Find("Objectives"); 
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

        //if (ObjectifsAccomplis => 12)
        //{
            //LastObjectif();
        //}
    }

    private void ShowObjectives()
    {
            //915
    }

    private void LastObjectif()
    {
        
    }
}
