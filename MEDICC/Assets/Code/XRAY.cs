using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XRAY : MonoBehaviour
{
    public GameObject player;
    public Transform telePoint;
    public Transform homePoint;
    public bool isReady;
    public GameObject BED;
    public GameObject timeManagement;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isReady && Input.GetKeyUp("space"))
        {
            //timeManagement.GetComponent<XrayTimer>().enabled = true;
            //holdit();
            StartCoroutine(showResult());



        }
    }

    void xrayTest()
    {
        Debug.Log("Sedang dilakukan test Rontgen");
        player.transform.position = telePoint.position;
        //player.transform.rotation = telePoint.rotation;

        
    }

    private IEnumerator showResult()
    {
        xrayTest();
        yield return new WaitForSeconds(2);
        player.transform.position = homePoint.position;
        diagnozeResult(3);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "x-ray")
        {
            isReady = true;
            //Debug.Log("Sedang dilakukan test Rontgen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "x-ray")
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
            //result.text = "Harus Cek Darah";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<bloodTest>().enabled = true;

        }
        else if (randomNum == 2)
        {
            Debug.Log("Butuh obat merah");
            //result.text = "Harus Test PCR";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<PCR>().enabled = true;
        }
        else if (randomNum == 3)
        {
            Debug.Log("Butuh obat kuning");
            //result.text = "Harus X-RAY";
            //this.GetComponent<pickPatient>().enabled = true;
            //this.GetComponent<XRAY>().enabled = true;
        }
    }
}
