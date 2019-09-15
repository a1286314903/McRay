using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }

    public int money = 1000;

    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$ " + money;
    }
}
