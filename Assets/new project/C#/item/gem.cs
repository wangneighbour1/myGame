using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gem : MonoBehaviour
{
    public int startCoin;
    public TextMeshProUGUI coinnum;
    public static int currentCoin;
    // Start is called before the first frame update
    void Start()
    {
        currentCoin = startCoin;
    }

    // Update is called once per frame
    void Update()
    {
        coinnum.text = currentCoin.ToString();       
    }
}
