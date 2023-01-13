using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class upgrade : MonoBehaviour
{
    public float speedLevel;
    public float efficiencyLevel;
    public float medicalLevel;
    public float pharmacyLevel;
    public float chemistryLevel;
    public int coins;

    public TextMeshProUGUI speeds;
    public TextMeshProUGUI efficiens;
    public TextMeshProUGUI medicals;
    public TextMeshProUGUI pharmas;
    public TextMeshProUGUI chemistt;
    public TextMeshProUGUI currency;

    public float playerSpeed;
    public float playerEfficiency;
    public float playerMedical;
    public float playerPharmacy;
    public float playerChemistry;
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

        //Store speed data
        speedLevel = PlayerPrefs.GetFloat("speedLevel");
        playerSpeed = PlayerPrefs.GetFloat("PlayerSpeeds");

        //Store efficiency data
        efficiencyLevel = PlayerPrefs.GetFloat("efficiencyLevel");
        playerEfficiency = PlayerPrefs.GetFloat("PlayerEfficiencys");

        //Store medical knowledge data
        medicalLevel = PlayerPrefs.GetFloat("medicalLevel");
        playerMedical = PlayerPrefs.GetFloat("PlayerMedicals");

        //Store Pharmacy knowledge data
        pharmacyLevel = PlayerPrefs.GetFloat("pharmacyLevel");
        playerPharmacy = PlayerPrefs.GetFloat("PlayerPharmacys");

        //Store chemistry knowledge data
        chemistryLevel = PlayerPrefs.GetFloat("chemistryLevel");
        playerChemistry = PlayerPrefs.GetFloat("PlayerChemistrys");

        //Store coin data
        coins = PlayerPrefs.GetInt("coin");

        currency.text = coins.ToString();

        //set speed default
        if (speedLevel == 0)
        {
            playerSpeed = 5;
            PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
        }

        //set efficiency default
        if (efficiencyLevel == 0)
        {
            playerEfficiency = 5;
            PlayerPrefs.SetFloat("PlayerEfficiencys", playerEfficiency);
        }

        //set medical default
        if (medicalLevel == 0)
        {
            playerMedical = 5;
            PlayerPrefs.SetFloat("PlayerMedicals", playerMedical);

        }

        //set pharmacy default
        if (pharmacyLevel == 0)
        {
            playerPharmacy = 5;
            PlayerPrefs.SetFloat("PlayerPharmacys", playerPharmacy);
        }

        //set chemistry default
        if (chemistryLevel == 0)
        {
            playerChemistry = 5;
            PlayerPrefs.SetFloat("PlayerChemistrys", playerChemistry);
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
        playerSpeed += 0.2f;
        PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
        PlayerPrefs.SetFloat("speedLevel", speedLevel);

    }

    public void efficiencyUpgrade()
    {
        efficiencyLevel += 1;
        playerEfficiency -= 0.2f;
        PlayerPrefs.SetFloat("PlayerEfficiencys", playerEfficiency);
        PlayerPrefs.SetFloat("efficiencyLevel", efficiencyLevel);
    }

    public void medical()
    {
        medicalLevel += 1;
        playerMedical -= 0.2f;
        PlayerPrefs.SetFloat("PlayerMedicals", playerMedical);
        PlayerPrefs.SetFloat("medicalLevel", medicalLevel);
    }

    public void pharmacy()
    {
        pharmacyLevel += 1;
        playerPharmacy -= 0.2f;
        PlayerPrefs.SetFloat("PlayerPharmacys", playerPharmacy);
        PlayerPrefs.SetFloat("pharmacyLevel", pharmacyLevel);
    }

    public void chemistry()
    {
        chemistryLevel += 1;
        playerChemistry -= 0.2f;
        PlayerPrefs.SetFloat("PlayerChemistrys", playerChemistry);
        PlayerPrefs.SetFloat("chemistryLevel", chemistryLevel);
    }

    public void backk()
    {
        gameObject.SetActive(false);
    }
}
