using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class stageSelect : MonoBehaviour
{
    public bool isClear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stage1()
    {
        SceneManager.LoadScene("Day1");
    }

    public void stage2()
    {
        SceneManager.LoadScene("Day2");
    }

    public void stage3()
    {
        SceneManager.LoadScene("Day3");
    }

    public void stage4()
    {
        SceneManager.LoadScene("Day4");
    }

    public void stage5()
    {
        SceneManager.LoadScene("Day5");
    }

    public void stage6()
    {
        SceneManager.LoadScene("Day6");
    }

    public void stage7()
    {
        SceneManager.LoadScene("Day7");
    }

    public void stage8()
    {
        SceneManager.LoadScene("Day8");
    }

    public void stage9()
    {
        SceneManager.LoadScene("Day9");
    }

    public void stage10()
    {
        SceneManager.LoadScene("Day10");
    }
}
