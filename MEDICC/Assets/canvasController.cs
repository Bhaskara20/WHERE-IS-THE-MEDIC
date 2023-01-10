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
        if(Input.GetKeyUp("p"))
        {
            pause.SetActive(true);
            PauseGame();
            //isPause = true;
        }

        /*if (isPause == true && Input.GetKeyUp("p"))
        {
            pause.SetActive(false);
            isPause=false;
        }*/
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
