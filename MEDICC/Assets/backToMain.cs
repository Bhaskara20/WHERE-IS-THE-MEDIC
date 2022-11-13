using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class backToMain : MonoBehaviour
{
    public CinemachineVirtualCamera mainCam;
    public CinemachineVirtualCamera pharmaCam;
    public GameObject player;
    public bool isReady;
    //public Transform telePoint;
    public Transform homePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady && Input.GetKeyUp("space"))
        {
            //timeManagement.GetComponent<XrayTimer>().enabled = true;
            //holdit();
            //StartCoroutine(showResult());

            Debug.Log("keluar dari lab obat");
            player.transform.position = homePoint.position;
            CinemachineBrain.SoloCamera = null;
            CinemachineBrain.SoloCamera = mainCam;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isReady = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isReady = false;


        }
    }
}
