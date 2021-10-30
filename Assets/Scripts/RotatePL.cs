using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatePL : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float rotation = 0f;

    [SerializeField] Transform player;
    [SerializeField] float sensitivity;
    [SerializeField] Slider sliderSens;


    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume" ,0.851f);
            Load();
            
        }
        else
        {
            Load();
        }
    }
    void FixedUpdate()
    {
        mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
    }
    public void ChangeSens()
    {
        AudioListener.volume = sliderSens.value;
        Save();
    }
    public void Load()
    {
        sliderSens.value = PlayerPrefs.GetFloat("musicVolume");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("musicVolume" ,sliderSens.value);
    }
}
