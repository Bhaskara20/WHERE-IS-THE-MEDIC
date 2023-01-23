using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class naikKasur : MonoBehaviour
{
    public Transform sleepPos;
    public GameObject patient;
    public bool naik;
    public bool harusNempel;

    public NavMeshAgent scriptAgent;

    public GameObject tensiIcon;
    public GameObject thermoIcon;
    public GameObject stetosIcon;

    public GameObject AnimasiJalan;
    public GameObject AnimasiTidur;

    public bool gone;

    public bool once;
    //public GameObject sleepposs;

    // Start is called before the first frame update
    void Start()
    {
        //sleepPos = GameObject.FindWithTag("sleepPos").transform;
        //patient = GameObject.FindWithTag("Patient");

        referenceVariable();
        harusNempel = true;

        scriptAgent = GetComponent<NavMeshAgent>();
        //sleepposs = GameObject.FindWithTag("sleepPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (naik)
        {
            this.transform.position = sleepPos.position;
            this.transform.rotation = sleepPos.rotation;

            if (gone == false)
            {
                AnimasiJalan.SetActive(false);
                AnimasiTidur.SetActive(true);
            }else if(gone == true)
            {
                AnimasiJalan.SetActive(false);
                AnimasiTidur.SetActive(false);
            }
            
            this.GetComponent<PatientAI>().enabled = false;

            if (once == false)
            {
                tensiIcon.SetActive(true);
                thermoIcon.SetActive(true);
                stetosIcon.SetActive(true);
            }
            
            once = true;
            //this.GetComponent<naikKasur>().enabled = false;
            //StartCoroutine(penyelamat());

        }
       
    }

    private IEnumerator penyelamat()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<naikKasur>().enabled = false;
    }

    public void juruSelamat()
    {
        this.GetComponent<naikKasur>().enabled = false;
        scriptAgent.enabled = false;
    }

    public void referenceVariable()
    {
        if (gameObject.tag.Equals("Patient"))
        {
            sleepPos = GameObject.FindWithTag("sleepPos").transform;
            patient = GameObject.FindWithTag("Patient");
        }else if (gameObject.tag.Equals("patient2"))
        {
            sleepPos = GameObject.FindWithTag("sleepPos2").transform;
            patient = GameObject.FindWithTag("patient2");
        }
        else if (gameObject.tag.Equals("patient3"))
        {
            sleepPos = GameObject.FindWithTag("sleepPos3").transform;
            patient = GameObject.FindWithTag("patient3");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bed" && gameObject.tag.Equals("Patient"))
        {
            Debug.Log("Seharusnya naik");
            naik = true;
            //this.transform.position = sleepPos.position;
            //this.transform.rotation = sleepPos.rotation;
            //sleepposs.GetComponent<occupy>().spawnPatient();
            //patient.SetActive(true);
           // gameObject.SetActive(false);
            //this.transform.parent = null;
            
            //gameObject.GetComponent<pickPatient>().dropIt();
        }else if (other.gameObject.tag == "bed2" && gameObject.tag.Equals("patient2"))
        {
            Debug.Log("Seharusnya naik");
            naik = true;
        }else if (other.gameObject.tag == "bed3" && gameObject.tag.Equals("patient3"))
        {
            Debug.Log("Seharusnya naik");
            naik = true;
        }
    }
}
