using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class stageSelect2 : MonoBehaviour
{

    public Button[] dayButtons;
    // Start is called before the first frame update
    void Start()
    {
        int currLevel = PlayerPrefs.GetInt("currLevel", 2);

        for (int i = 0; i < dayButtons.Length; i++)
        {
            if (i + 2 > currLevel)
            {
                dayButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < dayButtons.Length; i++)
        {
            if (dayButtons[i].interactable == false)
            {
                dayButtons[i].enabled = false;
                dayButtons[i].GetComponent<Image>().enabled = false;
            }
        }
    }
}
