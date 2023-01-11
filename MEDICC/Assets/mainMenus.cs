using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenus : MonoBehaviour
{
    public GameObject upgradeShop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        //Debug.Log("Play");
        SceneManager.LoadScene("StageSelection");
    }

    public void shop()
    {
        //Debug.Log("Shop");
        upgradeShop.SetActive(true);

    }

    public void endProgram()
    {
        //Debug.Log("Exit");
    }
}
