using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public float dashSpeed;
    public float dashTime;

    public float isDashing;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        speed = PlayerPrefs.GetFloat("PlayerSpeeds");
        GameObject bottle = GameObject.FindWithTag("bottle");
        Transform bottlePort = GameObject.FindWithTag("bottlePort").transform;
        GameObject blueBottle = GameObject.FindWithTag("blueBottle");
        GameObject redBottle = GameObject.FindWithTag("redBottle");
        GameObject yellowBottle = GameObject.FindWithTag("yellowBottle");

        GameObject stetoskop = GameObject.FindWithTag("stetoscope");
        GameObject tensimeter = GameObject.FindWithTag("tensimeter");
        GameObject thermometer = GameObject.FindWithTag("thermometer");

        Transform tensiPort = GameObject.FindWithTag("tensiport").transform;
        Transform thermoPort = GameObject.FindWithTag("thermoport").transform;
        Transform stetoPort = GameObject.FindWithTag("stetoport").transform;

        GameObject red = GameObject.FindWithTag("red");
        GameObject blue = GameObject.FindWithTag("blue");

        Transform redPort = GameObject.FindWithTag("redPort").transform;
        Transform bluePort = GameObject.FindWithTag("bluePort").transform;


        //GameObject
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);


        //animator.SetFloat("Speed", movementDirection.magnitude);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        //PlayerPrefs.SetFloat("PlayerSpeeds", speed);

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //Debug.Log("Dashing..");
            StartCoroutine(DASH());
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            //drop bottle
            if (bottle.GetComponent<pickBottle>().isHoldingAlter == true)
            {
                //Debug.Log("Drop");
                bottle.GetComponent<pickBottle>().dropIt();
                bottle.transform.position = bottlePort.position;
                bottle.transform.rotation = bottlePort.rotation;
                blueBottle.SetActive(false);
                redBottle.SetActive(false);
                yellowBottle.SetActive(false);
            }


            //drop tool

            if (stetoskop.GetComponent<pickTool>().isHolding == true)
            {
                //Debug.Log("Drop");
                stetoskop.GetComponent<pickTool>().dropIt();
                stetoskop.transform.position = stetoPort.position;
                stetoskop.transform.rotation = stetoPort.rotation;
            }

            if (tensimeter.GetComponent<pickTool>().isHolding == true)
            {
                tensimeter.GetComponent<pickTool>().dropIt();
                tensimeter.transform.position = tensiPort.position;
                tensimeter.transform.rotation = tensiPort.rotation;
            }

            if (thermometer.GetComponent<pickTool>().isHolding == true)
            {
                thermometer.GetComponent<pickTool>().dropIt();
                thermometer.transform.position = thermoPort.position;
                thermometer.transform.rotation = thermoPort.rotation;
            }



            //drop ingridient
            if (red.GetComponent<pickIngridient>().isHolding == true)
            {
                red.GetComponent<pickIngridient>().dropIt();
                red.transform.position = redPort.position;
                red.transform.rotation = redPort.rotation;
            }

            if (blue.GetComponent<pickIngridient>().isHolding == true)
            {
                blue.GetComponent<pickIngridient>().dropIt();
                blue.transform.position = bluePort.position;
                blue.transform.rotation = bluePort.rotation;
            }


            //drop crushed ingridient
            
        }
    }

    

    IEnumerator DASH()
    {
        speed = 15f;
        yield return new WaitForSeconds(0.5f);
        speed = 5f;
    }

 

 


}
