using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    public Text killText;
    public static int kills = 0;

    public Text coinText;
    public static float Coins = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        killText.text = "Kills:" + kills ;
        coinText.text = Coins + " $";

        if(Coins < 0f)
        {
            Coins = 0f;
        }
        if(Coins > 9999f)
        {
            Coins = 9999f;
        }
    }
    public void AddKill()
    {
        Coins += 25f;
        kills++;
    }
}
