using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class upgrade : MonoBehaviour
{
    public float speedLevel;
    public float efficiencyLevel;
    public float medicalLevel;
    public float pharmacyLevel;
    public float chemistryLevel;

    public TextMeshProUGUI speeds;
    public TextMeshProUGUI efficiens;
    public TextMeshProUGUI medicals;
    public TextMeshProUGUI pharmas;
    public TextMeshProUGUI chemistt;

    public float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * if(speedLevel == 0)
        {
            playerSpeed = 5;
            PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
        }*/
        speedLevel = PlayerPrefs.GetFloat("speedLevel");
        playerSpeed = PlayerPrefs.GetFloat("PlayerSpeeds");

        if (speedLevel == 0)
        {
            playerSpeed = 5;
            PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
        }
        speeds.text = "Lvl " + speedLevel.ToString();
        efficiens.text = "Lvl " + efficiencyLevel.ToString();
        medicals.text = "Lvl " + medicalLevel.ToString();
        pharmas.text = "Lvl " + pharmacyLevel.ToString();
        chemistt.text = "Lvl " + chemistryLevel.ToString();
    }

    public void speedUpgrade()
    {
        speedLevel += 1;
        playerSpeed += 1;
        PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
        PlayerPrefs.SetFloat("speedLevel", speedLevel);

    }

    public void efficiencyUpgrade()
    {
        efficiencyLevel += 1;
    }

    public void medical()
    {
        medicalLevel += 1;
    }

    public void pharmacy()
    {
        pharmacyLevel += 1;
    }

    public void chemistry()
    {
        chemistryLevel += 1;
    }

    public void backk()
    {
        gameObject.SetActive(false);
    }
}
