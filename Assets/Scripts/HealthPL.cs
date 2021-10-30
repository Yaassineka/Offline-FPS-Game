using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPL : MonoBehaviour
{
    [SerializeField] private GameObject PlayerOBJ;
    [SerializeField] private int xPos;
    [SerializeField] private int zPos;

    public static float health = 100f;
    public Text healthText;
 
    void Start()
    {
        xPos = Random.Range(-61, 61);
        zPos = Random.Range(-81, 81);
        Instantiate(PlayerOBJ, new Vector3(xPos, 10f, zPos), Quaternion.identity);
    }
    private void OnEnable()
    {
        
    }

    void Update()
    {

        if (health <= 0f)
        {
            health = 0f;
        }

        if (health >= 100f)
        {
            health = 100f;
        }

        if(health == 0f)
        {
            SceneManager.LoadScene("GameOver");
            health = 100f;
            AK.maxAmmo = 240;
            AK.numAmmo = 33;
            KillCounter.Coins = 0;
            Cursor.lockState = CursorLockMode.None; 
        }

        healthText.text = "" + health;      
    }
    private void OnCollisionEnter(Collision other)
    {
       if(other.gameObject.CompareTag("Enemy"))
        {
            SoundManager.PlaySound("ZombiDrb");

            Debug.Log("hit");
            health -= 10f;
        }
    }
}
