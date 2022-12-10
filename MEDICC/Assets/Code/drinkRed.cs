using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkRed : MonoBehaviour
{
    public bool isReady;
    public GameObject redBottle;
    public GameObject bottle;
    public Transform bottlePort;
    // Start is called before the first frame update
    void Start()
    {
        //redBottle = GameObject.FindWithTag("redBottle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //holdit();
            Debug.Log("PASIEN MINUM OBAT MERAH");
            redBottle.SetActive(false);
            bottle.GetComponent<pickBottle>().dropIt();
            //redIngridient.transform.position = redPort.position;
            //redIngridient.transform.rotation = redPort.rotation;

            bottle.transform.position = bottlePort.position;
            bottle.transform.rotation = bottlePort.rotation;
            Debug.Log("Pasien Sembuh");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "redBottle")
        {
            isReady = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "redBottle")
        {
            isReady = false;
        }
    }
}
