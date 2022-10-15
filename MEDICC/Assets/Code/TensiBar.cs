using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DentedPixel;

public class TensiBar : MonoBehaviour
{
    public GameObject bar;
    public int time;
    public GameObject player;

    //public float barScale;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        //diagnozing();

    }

    // Update is called once per frame
    void Update()
    {
        diagnozing();
        Debug.Log(time);
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

        if (bar.transform.localScale.x == 1f)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            gameObject.SetActive(false);
            bar.transform.localScale = new Vector3(0f, 1f, 1f);
        }
        
    }

    public void diagnozing()
    {
        player.GetComponent<PlayerMovement>().enabled = false; 
        LeanTween.scaleX(bar, 1, time);
        
    }

    
}
