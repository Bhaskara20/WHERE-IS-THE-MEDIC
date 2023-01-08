using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasController : MonoBehaviour
{
    public GameObject pause;
    public bool isPause;
    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPause == false && Input.GetKeyUp("p"))
        {
            pause.SetActive(true);
            isPause = true;
        }

        /*if (isPause == true && Input.GetKeyUp("p"))
        {
            pause.SetActive(false);
            isPause=false;
        }*/
    }
}
