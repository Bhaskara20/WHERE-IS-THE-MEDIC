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
   

    void Update()
    {
        GameObject bottle = GameObject.FindWithTag("bottle");
        Transform bottlePort = GameObject.FindWithTag("bottlePort").transform;
        GameObject blueBottle = GameObject.FindWithTag("blueBottle");
        GameObject redBottle = GameObject.FindWithTag("redBottle");
        GameObject yellowBottle = GameObject.FindWithTag("yellowBottle");


        //GameObject
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

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
                Debug.Log("Drop");
                bottle.GetComponent<pickBottle>().dropIt();
                bottle.transform.position = bottlePort.position;
                bottle.transform.rotation = bottlePort.rotation;
                blueBottle.SetActive(false);
                redBottle.SetActive(false);
                yellowBottle.SetActive(false);
            }

            //drop tool
            if ()
            {

            }


            //drop ingridient



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
