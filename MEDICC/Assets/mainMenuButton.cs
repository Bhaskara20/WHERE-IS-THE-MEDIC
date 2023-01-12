using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuButton : MonoBehaviour
{

    public GameObject timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void back2main()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void next()
    {
        SceneManager.LoadScene(timer.GetComponent<Timer>().nextLevel);
    }
}
