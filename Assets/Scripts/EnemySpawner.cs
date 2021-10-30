using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    EnemyController enemyControllerScript;

    [SerializeField] private GameObject enemyOBJ, bossOBJ;
    [SerializeField] private int xPos;
    [SerializeField] private int zPos;
    [SerializeField] private int enemyCount;

    void Start()
    {
        

        enemyControllerScript = GameObject.Find("EnemySpawner").GetComponent<EnemyController>();

    }
    void Update()
    {
        StartCoroutine(EnemyDrop());
        
        IEnumerator EnemyDrop()
        {
            yield return new WaitForSeconds(10f);

            while (enemyCount < 3)
            {
                xPos = Random.Range(-61, 61);
                zPos = Random.Range(-81, 81);
                Instantiate(enemyOBJ, new Vector3(xPos, 10f, zPos), Quaternion.identity);
                enemyCount++;
            } 
        }       
    } 
    public void EnemyCounter()
    {
        enemyCount--;
  
    }
}
