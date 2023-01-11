using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Patient : MonoBehaviour
{
    public GameObject tensi;
    public GameObject thermo;
    public GameObject stetos;
    //public GameObject player;

    public Transform tensiPort;
    public Transform thermoPort;
    public Transform stetoPort;
    //public Transform hidepoint;

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

    public float checkingTime;

    private Scene scene;

    //public GameObject text;

    //public GameObject holder;
    // Start is called before the first frame update
    void Start()
    {

        scene = SceneManager.GetActiveScene();

        checkingTime = PlayerPrefs.GetFloat("PlayerEfficiencys"); ;
        tensi = GameObject.FindWithTag("tensimeter");
        thermo = GameObject.FindWithTag("thermometer");
        stetos = GameObject.FindWithTag("stetoscope");

        tensiPort = GameObject.FindWithTag("tensiport").transform;
        thermoPort = GameObject.FindWithTag("thermoport").transform;
        stetoPort = GameObject.FindWithTag("stetoport").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyTensi && Input.GetKeyUp("space"))
        {
            tensi.GetComponent<pickTool>().dropIt();
            tensi.transform.position = tensiPort.position;
            tensi.transform.rotation = tensiPort.rotation;
            StartCoroutine(delayTensi());
        }
        else if (readyThermo && Input.GetKeyUp("space"))
        {
            //StartCoroutine(delay());
            thermo.GetComponent<pickTool>().dropIt();
            thermo.transform.position = thermoPort.position;
            thermo.transform.rotation = thermoPort.rotation;
            StartCoroutine(delayThermo());
           
        }else if (readySteto && Input.GetKeyUp("space"))
        {
           // StartCoroutine(delay());
            stetos.GetComponent<pickTool>().dropIt();
            stetos.transform.position = stetoPort.position;
            stetos.transform.rotation = stetoPort.rotation;
            StartCoroutine(delayStetos());
           
        }

        //day 1
        if(scene.name == "Day1")
        {
            if (tensiChecked && thermoChecked && stetosChecked)
            {
                diagnozeResult1(1);
                tensiChecked = false;
                thermoChecked = false;
                stetosChecked = false;
            }
        }

        /*if (tensiChecked && thermoChecked && stetosChecked)
        {
            diagnozeResult(3);
            tensiChecked = false;
            thermoChecked = false;
            stetosChecked = false;
        }*/
    }

    private IEnumerator delayTensi()
    {
        yield return new WaitForSeconds(checkingTime);
        //tensibar.SetActive(true);
        tensiChecked = true;
        Debug.Log("Ukur Tensi");
    }

    private IEnumerator delayThermo()
    {
        yield return new WaitForSeconds(checkingTime);
        thermoChecked = true;
        Debug.Log("Ukur Suhu");
    }

    private IEnumerator delayStetos()
    {
        yield return new WaitForSeconds(checkingTime);
        stetosChecked = true;
        Debug.Log("Periksa Fisik");
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

    void diagnozeResult1(int Maxint)
    {
        int randomNum = Random.Range(1, Maxint + 1);
        if (randomNum == 1)
        {
            Debug.Log("Butuh obat biru");
            this.GetComponent<drinkBlue>().enabled = true;
            //result.text = "Harus Cek Darah";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<bloodTest>().enabled = true;

        }
    }
}
