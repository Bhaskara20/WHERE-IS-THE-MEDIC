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

    public int Speedcost;
    public int efficiencycost;
    public int medicalcost;
    public int pharmacycost;
    public int chemistrycost;

    public int coinCount;
    public int currCoin;
    public int coinSetter;

    public TextMeshProUGUI biayaSpeed;
    public TextMeshProUGUI biayaEfficiency;
    public TextMeshProUGUI biayaMedical;
    public TextMeshProUGUI biayaPharmacy;
    public TextMeshProUGUI biayaChemistry;
    // Start is called before the first frame update
    void Start()
    {
        currCoin = PlayerPrefs.GetInt("coin");
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

        currCoin = PlayerPrefs.GetInt("coin");
        coinSetter = PlayerPrefs.GetInt("coin");

        Speedcost = PlayerPrefs.GetInt("speedCost");
        efficiencycost = PlayerPrefs.GetInt("efficiencycost");
        medicalcost = PlayerPrefs.GetInt("medicalcost");
        pharmacycost = PlayerPrefs.GetInt("pharmacycost");
        chemistrycost = PlayerPrefs.GetInt("chemistrycost");


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
        biayaSpeed.text = "Cost : " + Speedcost.ToString() + "c";
        biayaEfficiency.text = "Cost : " + efficiencycost.ToString() + "c";
        biayaMedical.text = "Cost : " + medicalcost.ToString() + "c";
        biayaPharmacy.text = "Cost : " + pharmacycost.ToString() + "c";
        biayaChemistry.text = "Cost : " + chemistrycost.ToString() + "c";

        //set speed default
        if (speedLevel == 0)
        {
            playerSpeed = 5;
            Speedcost = 5;
            PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
            PlayerPrefs.SetInt("speedCost", Speedcost);
        }

        //set efficiency default
        if (efficiencyLevel == 0)
        {
            playerEfficiency = 5;
            efficiencycost = 5;
            PlayerPrefs.SetFloat("PlayerEfficiencys", playerEfficiency);
            PlayerPrefs.SetInt("efficiencycost", efficiencycost);
        }

        //set medical default
        if (medicalLevel == 0)
        {
            playerMedical = 5;
            medicalcost = 5;
            PlayerPrefs.SetFloat("PlayerMedicals", playerMedical);
            PlayerPrefs.SetInt("medicalcost", medicalcost);

        }

        //set pharmacy default
        if (pharmacyLevel == 0)
        {
            playerPharmacy = 5;
            pharmacycost = 5;
            PlayerPrefs.SetFloat("PlayerPharmacys", playerPharmacy);
            PlayerPrefs.SetInt("pharmacycost", pharmacycost);
        }

        //set chemistry default
        if (chemistryLevel == 0)
        {
            playerChemistry = 5;
            chemistrycost = 5;
            PlayerPrefs.SetFloat("PlayerChemistrys", playerChemistry);
            PlayerPrefs.SetInt("chemistrycost", chemistrycost);
        }
        speeds.text = "Lvl " + speedLevel.ToString();
        efficiens.text = "Lvl " + efficiencyLevel.ToString();
        medicals.text = "Lvl " + medicalLevel.ToString();
        pharmas.text = "Lvl " + pharmacyLevel.ToString();
        chemistt.text = "Lvl " + chemistryLevel.ToString();

        if (coinSetter < 0)
        {
            coinSetter = 0;
            PlayerPrefs.SetInt("coin", coinSetter);
        }

    }

    public void speedUpgrade()
    {
        if (currCoin >= Speedcost)
        {
            speedLevel += 1;
            playerSpeed += 0.2f;
            //coinCount = currCoin - Speedcost;
            currCoin -= Speedcost;
            PlayerPrefs.SetInt("coin", currCoin);
            Speedcost += 5;
            PlayerPrefs.SetFloat("PlayerSpeeds", playerSpeed);
            PlayerPrefs.SetFloat("speedLevel", speedLevel);
            PlayerPrefs.SetInt("speedCost", Speedcost);
        }else if (currCoin < Speedcost)
        {
            Debug.Log("Uang tidak cukup, kamu terlalu miskin");
        }
        

    }

    public void efficiencyUpgrade()
    {
        if (currCoin >= efficiencycost)
        {
            efficiencyLevel += 1;
            playerEfficiency -= 0.2f;
            currCoin -= efficiencycost;
            PlayerPrefs.SetInt("coin", currCoin);
            efficiencycost += 5;
            PlayerPrefs.SetFloat("PlayerEfficiencys", playerEfficiency);
            PlayerPrefs.SetFloat("efficiencyLevel", efficiencyLevel);
            PlayerPrefs.SetInt("efficiencycost", efficiencycost);
        }else if (currCoin < efficiencycost)
        {
            Debug.Log("Uang tidak cukup, kamu terlalu miskin");
        }
    }

    public void medical()
    {

        if (currCoin >= medicalcost)
        {
            medicalLevel += 1;
            playerMedical -= 0.2f;
            currCoin -= medicalcost;
            PlayerPrefs.SetInt("coin", currCoin);
            medicalcost += 5;
            PlayerPrefs.SetFloat("PlayerMedicals", playerMedical);
            PlayerPrefs.SetFloat("medicalLevel", medicalLevel);
            PlayerPrefs.SetInt("medicalcost", medicalcost);
        }else if (currCoin < medicalcost)
        {
            Debug.Log("Uang tidak cukup, kamu terlalu miskin");
        }
    }

    public void pharmacy()
    {
        
        if (currCoin >= pharmacycost)
        {
            pharmacyLevel += 1;
            playerPharmacy -= 0.2f;
            currCoin -= pharmacycost;
            PlayerPrefs.SetInt("coin", currCoin);
            pharmacycost += 5;
            PlayerPrefs.SetFloat("PlayerPharmacys", playerPharmacy);
            PlayerPrefs.SetFloat("pharmacyLevel", pharmacyLevel);
            PlayerPrefs.SetInt("pharmacycost", pharmacycost);
        }else if (currCoin < pharmacycost)
        {
            Debug.Log("Uang tidak cukup, kamu terlalu miskin");
        }

    }

    public void chemistry()
    {
        if (currCoin >= chemistrycost)
        {
            chemistryLevel += 1;
            playerChemistry -= 0.2f;
            currCoin -= chemistrycost;
            PlayerPrefs.SetInt("coin", currCoin);
            chemistrycost += 5;
            PlayerPrefs.SetFloat("PlayerChemistrys", playerChemistry);
            PlayerPrefs.SetFloat("chemistryLevel", chemistryLevel);
            PlayerPrefs.SetInt("chemistrycost", chemistrycost);
        }else if (currCoin < chemistrycost)
        {
            Debug.Log("Uang tidak cukup, kamu terlalu miskin");
        }
    }

    public void backk()
    {
        gameObject.SetActive(false);
    }
}
