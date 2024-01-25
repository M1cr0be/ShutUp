using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillIt", 5f);
    }

    private void KillIt()
    {
        Destroy(this.gameObject);
    }
}
