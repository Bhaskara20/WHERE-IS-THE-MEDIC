using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class counter : MonoBehaviour
{
    public TextMeshProUGUI counts;
    public int nums;
    public int coinCount;

    public TextMeshProUGUI resultCoin;
    public TextMeshProUGUI resultCoinLose;

    // Start is called before the first frame update
    void Start()
    {
        //coinCount = PlayerPrefs.GetInt("coin");
    }

    // Update is called once per frame
    void Update()
    {
        //addCount();
        counts.text = nums.ToString();
        resultCoin.text = nums.ToString();
        resultCoinLose.text = nums.ToString();



    }

    public void addCount()
    {
        nums += 1;
        //coinCount += (int)nums;
        //coinCount += 1;
        //PlayerPrefs.SetInt("coin", coinCount);
    }
}
