using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class counter : MonoBehaviour
{
    public TextMeshProUGUI counts;
    public float nums;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //addCount();
        counts.text = nums.ToString();
    }

    public void addCount()
    {
        nums += 1;
    }
}
