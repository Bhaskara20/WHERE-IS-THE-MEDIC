using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PCR : MonoBehaviour
{
    public GameObject player;
    public Transform telePoint;
    public Transform homePoint;
    public bool isReady;

    public GameObject timeManagement;

    public float checkingTime;

    public GameObject patient;

    public GameObject pcrUIDelay;


    private void Start()
    {
        pcrUIDelay = GameObject.FindWithTag("pcrLab");
        checkingTime = PlayerPrefs.GetFloat("PlayerMedicals");
        player = GameObject.FindWithTag("Player");
        homePoint = GameObject.FindWithTag("pcrHomePoint").transform;
        telePoint = GameObject.FindWithTag("telePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {


        if (isReady && Input.GetKeyUp("space"))
        {
            //timeManagement.GetComponent<PcrTimer>().enabled = true;
            //holdit();
            //pcrTest();
            gameObject.GetComponent<Patient>().pcrIcon.SetActive(false);
            StartCoroutine(showResult());
            //gameObject.GetComponent<Patient>().pcrIcon.SetActive(false);




        }



    }

    void pcrTest()
    {
        Debug.Log("Sedang dilakukan test PCR");
        player.transform.position = telePoint.position;

        
        //player.transform.rotation = telePoint.rotation;

    }

    private IEnumerator showResult()
    {
        pcrTest();
        player.GetComponent<PlayerMovement>().enabled = false;
        pcrUIDelay.GetComponent<pcrDelayUi>().turnON();
        yield return new WaitForSeconds(checkingTime);
        pcrUIDelay.GetComponent<pcrDelayUi>().turnOFF();
        player.GetComponent<PlayerMovement>().enabled = true;
        player.transform.position = homePoint.position;
        diagnozeResult(3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "pcrLab")
        {
            isReady = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "pcrLab")
        {
            isReady = false;
            //Debug.Log("Sedang dilakukan test Rontgen");
        }
    }

    void diagnozeResult(int Maxint)
    {
        int randomNum = Random.Range(1, Maxint + 1);
        if (randomNum == 1)
        {
            Debug.Log("Butuh obat biru");
            this.GetComponent<drinkBlue>().enabled = true;
            gameObject.GetComponent<Patient>().bluePot.SetActive(true);
            //result.text = "Harus Cek Darah";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<bloodTest>().enabled = true;

        }
        else if (randomNum == 2)
        {
            Debug.Log("Butuh obat merah");
            this.GetComponent<drinkRed>().enabled = true;
            gameObject.GetComponent<Patient>().redPot.SetActive(true);
            //result.text = "Harus Test PCR";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<PCR>().enabled = true;
        }
        else if (randomNum == 3)
        {
            Debug.Log("Butuh obat kuning");
            this.GetComponent<drinkYellow>().enabled = true;
            gameObject.GetComponent<Patient>().yellowPot.SetActive(true);
            //result.text = "Harus X-RAY";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<XRAY>().enabled = true;
        }
    }
}
