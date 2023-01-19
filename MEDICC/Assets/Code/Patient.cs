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

    public GameObject Player;

    public GameObject tensiIcon;
    public GameObject thermoIcon;
    public GameObject stetosIcon;

    public GameObject redPot;
    public GameObject bluePot;
    public GameObject yellowPot;

    public GameObject pcrIcon;
    public GameObject bloodLabIcon;
    public GameObject xrayIcon;

    public AudioSource thermoBeep;
    public AudioSource tensiPump;
    public AudioSource heartBeat;

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

        //Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        if (readyTensi && Input.GetKeyUp("space"))
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
                bluePot.SetActive(true);
            }
        }

        //day 3 & 4
        if (scene.name == "Day2")
        {
            if (tensiChecked && thermoChecked && stetosChecked)
            {
                diagnozeResult2(2);
                tensiChecked = false;
                thermoChecked = false;
                stetosChecked = false;
                redPot.SetActive(true);
                bluePot.SetActive(true);
            }
        }

        if (scene.name == "Day3")
        {
            if (tensiChecked && thermoChecked && stetosChecked)
            {
                diagnozeResult3(3);
                tensiChecked = false;
                thermoChecked = false;
                stetosChecked = false;
                redPot.SetActive(true);
                bluePot.SetActive(true);
                yellowPot.SetActive(true);
            }
        }

        if (scene.name == "Day4" || scene.name == "Day5" || scene.name == "Day6" || scene.name == "Day7" || scene.name == "Day8" || scene.name == "Day9" || scene.name == "Day10")
        {
            if (tensiChecked && thermoChecked && stetosChecked)
            {
                diagnozeResult(3);
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
        Player.GetComponent<PlayerMovement>().enabled = false;
        tensiPump.Play();
        yield return new WaitForSeconds(checkingTime);
        tensiPump.Stop();
        Player.GetComponent<PlayerMovement>().enabled = true;
        //tensibar.SetActive(true);
        tensiChecked = true;
        Debug.Log("Ukur Tensi");
        tensiIcon.SetActive(false);

    }

    private IEnumerator delayThermo()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(checkingTime);
        thermoBeep.Play();
        Player.GetComponent<PlayerMovement>().enabled = true;
        thermoChecked = true;
        Debug.Log("Ukur Suhu");
        thermoIcon.SetActive(false);
    }

    private IEnumerator delayStetos()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        heartBeat.Play();
        yield return new WaitForSeconds(checkingTime);
        heartBeat.Stop();
        Player.GetComponent<PlayerMovement>().enabled = true;
        stetosChecked = true;
        Debug.Log("Periksa Fisik");
        stetosIcon.SetActive(false);
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
            bloodLabIcon.SetActive(true);
            
        }else if(randomNum == 2)
        {
            Debug.Log("Test PCR");
            result.text = "Harus Test PCR";
            this.GetComponent<pickPatient>().enabled = true;
            this.GetComponent<PCR>().enabled = true;
            pcrIcon.SetActive(true);
        }
        else if(randomNum == 3)
        {
            Debug.Log("Harus X-RAY");
            result.text = "Harus X-RAY";
            this.GetComponent<pickPatient>().enabled = true;
            this.GetComponent<XRAY>().enabled = true;
            xrayIcon.SetActive(true);
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

    void diagnozeResult2(int Maxint)
    {
        int randomNum = Random.Range(1, Maxint + 1);
        if (randomNum == 1)
        {
            Debug.Log("Butuh obat biru");
            this.GetComponent<drinkBlue>().enabled = true;
            //result.text = "Harus Cek Darah";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<bloodTest>().enabled = true;

        }else if (randomNum == 2)
        {
            Debug.Log("Butuh obat merah");
            this.GetComponent<drinkRed>().enabled = true;
            //result.text = "Harus Test PCR";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<PCR>().enabled = true;
        }
    }

    void diagnozeResult3(int Maxint)
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
        else if (randomNum == 2)
        {
            Debug.Log("Butuh obat merah");
            this.GetComponent<drinkRed>().enabled = true;
            //result.text = "Harus Test PCR";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<PCR>().enabled = true;
        }
        else if (randomNum == 3)
        {
            Debug.Log("Butuh obat kuning");
            this.GetComponent<drinkYellow>().enabled = true;
            //result.text = "Harus X-RAY";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<XRAY>().enabled = true;
        }
    }


}
