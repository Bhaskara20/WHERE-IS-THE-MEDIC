using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Patient : MonoBehaviour
{
    public GameObject tensi;
    public GameObject thermo;
    public GameObject stetos;

    public Transform tensiPort;
    public Transform thermoPort;
    public Transform stetoPort;

    public bool readyTensi;
    public bool readyThermo;
    public bool readySteto;

    public bool tensiChecked;
    public bool thermoChecked;
    public bool stetosChecked;

    public GameObject tensibar;
    public GameObject thermobar;
    public GameObject stetosbar;

    public TextMeshProUGUI result;
    //public GameObject text;

    //public GameObject holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(readyTensi && Input.GetKeyUp("space"))
        {
            tensi.GetComponent<pickTool>().dropIt();
            tensi.transform.position = tensiPort.position;
            tensi.transform.rotation = tensiPort.rotation;
            //tensibar.SetActive(true);
            tensiChecked = true;
            Debug.Log("Ukur Tensi");
        }else if (readyThermo && Input.GetKeyUp("space"))
        {
            thermo.GetComponent<pickTool>().dropIt();
            thermo.transform.position = thermoPort.position;
            thermo.transform.rotation = thermoPort.rotation;
            thermoChecked = true;
            Debug.Log("Ukur Suhu");
        }else if (readySteto && Input.GetKeyUp("space"))
        {
            stetos.GetComponent<pickTool>().dropIt();
            stetos.transform.position = stetoPort.position;
            stetos.transform.rotation = stetoPort.rotation;
            stetosChecked = true;
            Debug.Log("Periksa Fisik");
        }


        if (tensiChecked && thermoChecked && stetosChecked)
        {
            diagnozeResult(3);
            tensiChecked = false;
            thermoChecked = false;
            stetosChecked = false;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "tensimeter")
        {
            readyTensi = true;
            
            
        }else if (other.gameObject.tag == "thermometer")
        {
            readyThermo = true;
            
      
        }else if (other.gameObject.tag == "stetoscope")
        {
            readySteto = true;
            
     

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tensimeter")
        {
            readyTensi = false;


        }
        else if (other.gameObject.tag == "thermometer")
        {
            readyThermo = false;

        }
        else if (other.gameObject.tag == "stetoscope")
        {
            readySteto = false;

        }
    }


    void diagnozeResult(int Maxint)
    {
        int randomNum = Random.Range(1, Maxint+1);
        if (randomNum == 1)
        {
            Debug.Log("Cek darah");
            result.text = "Harus Cek Darah";
            this.GetComponent<pickPatient>().enabled = true;
            this.GetComponent<bloodTest>().enabled = true;
            
        }else if(randomNum == 2)
        {
            Debug.Log("Test PCR");
            result.text = "Harus Test PCR";
            this.GetComponent<pickPatient>().enabled = true;
            this.GetComponent<PCR>().enabled = true;
        }
        else if(randomNum == 3)
        {
            Debug.Log("Harus X-RAY");
            result.text = "Harus X-RAY";
            this.GetComponent<pickPatient>().enabled = true;
            this.GetComponent<XRAY>().enabled = true;
        }
    }
}
