using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour
{  
    [SerializeField] string Url;
    [SerializeField] GameObject g1;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        KillCounter.kills = 0;
        KillCounter.Coins = 0;
        HealthPL.health = 100f;
        AK.maxAmmo = 240;
        AK.numAmmo = 33; 
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
        KillCounter.kills = 0;
        KillCounter.Coins = 0;
        HealthPL.health = 100f;
        AK.maxAmmo = 240;
        AK.numAmmo = 33;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
        KillCounter.kills = 0;
        KillCounter.Coins = 0;
        Time.timeScale = 1f;
        HealthPL.health = 100f;
        AK.maxAmmo = 240;
        AK.numAmmo = 33;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Destroy(GameObject.FindWithTag("Music"));
        KillCounter.kills = 0;
        KillCounter.Coins = 0;
        Time.timeScale = 1f;
        HealthPL.health = 100f;
        AK.maxAmmo = 240;
        AK.numAmmo = 33;

    }
    public void OpenUrl()
    {
        Application.OpenURL(Url);
    }
    public void ActiveSelf()
    {
        g1.SetActive(!g1.activeSelf);
    }
    public void PauseMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Destroy(GameObject.FindWithTag("Music"));
        KillCounter.kills = 0;
        KillCounter.Coins = 0;
        Time.timeScale = 1f;
        HealthPL.health = 100f;
        AK.maxAmmo = 240;
        AK.numAmmo = 33;
    }
}
