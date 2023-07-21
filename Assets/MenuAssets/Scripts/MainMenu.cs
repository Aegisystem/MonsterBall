using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private float tiempoObtenido;
    [SerializeField]
    private GameObject bestTime;

    private void Start()
    {
        tiempoObtenido = PlayerPrefs.GetFloat("TiempoObtenido");
        
        int minutes = Mathf.FloorToInt(tiempoObtenido / 60f);
        int seconds = Mathf.FloorToInt(tiempoObtenido % 60f);
        int milliseconds = Mathf.FloorToInt((tiempoObtenido * 100f) % 100f);
        
        bestTime.GetComponent<TMPro.TextMeshProUGUI>().text += string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
        
        Debug.Log("Tiempo obtenido: " + tiempoObtenido);
    }
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}