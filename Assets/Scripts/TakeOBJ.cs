using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOBJ : MonoBehaviour
{
    TakeOBJ takeOBJkScript;

    [SerializeField] private GameObject boxHealth, boxAmmo;
    [SerializeField] private int xPos;
    [SerializeField] private int zPos;
    [SerializeField] private int ammoCount;
    [SerializeField] private int healthCount;

    private void Start()
    {
        takeOBJkScript = GameObject.FindGameObjectWithTag("BoxSpawner").GetComponent<TakeOBJ>();
    }
    private void Update()
    {
        StartCoroutine(AmmoDrop());
        StartCoroutine(HealthDrop());

        

        IEnumerator AmmoDrop()
        {
            yield return new WaitForSeconds(1f);

            while (ammoCount < 5)
            {
                xPos = Random.Range(-3, 20);
                zPos = Random.Range(-9, 8);
                Instantiate(boxAmmo, new Vector3(xPos, 1.37f, zPos), Quaternion.identity);
                ammoCount++;
            }
        }
        IEnumerator HealthDrop()
        {
            yield return new WaitForSeconds(1f);

            while (healthCount < 5)
            {
                xPos = Random.Range(-3, 20);
                zPos = Random.Range(-9, 8);
                Instantiate(boxHealth, new Vector3(xPos, 1.37f, zPos), Quaternion.identity);
                healthCount++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)           
    { 
        if (other.gameObject.CompareTag("TakeRange") && HealthPL.health < 100f && KillCounter.Coins >= 100)
        {
            if (this.gameObject.CompareTag("Health"))
            {
                HealthPL.health += 50f;
                Destroy(this.gameObject);
                KillCounter.Coins -= 100;
                Debug.Log("+++Health+++");
                takeOBJkScript.MinceHealth();
                MinceHealth();
            }
            if (this.gameObject.CompareTag("Ammo") && AK.maxAmmo < 200 && KillCounter.Coins >= 100)
            {
                AK.maxAmmo += 80;
                Destroy(this.gameObject);
                KillCounter.Coins -= 100;
                Debug.Log("+++ammo+++");
                takeOBJkScript.MinceAmmo();
                MinceAmmo();
            }
        }
    }
    public void MinceAmmo()
    {
        ammoCount--;
    }
    public void MinceHealth()
    {
        healthCount--;
    }
}
