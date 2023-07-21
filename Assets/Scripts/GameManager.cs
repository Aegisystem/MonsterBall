using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loseImage;

    public float time = 90f;
    public bool finish = false;
    
    public static GameManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                LoseGame();
            }
        }
        else
        {
            // Si el juego ha terminado, cargar la escena "Menu" con el tiempo obtenido
            if (Input.anyKeyDown)
            {
                LoadMenuSceneWithTime();
            }
        }
    }

    // Método para cargar la escena "Menu" con el tiempo obtenido
    private void LoadMenuSceneWithTime()
    {
        float tiempoObtenido = 90f - time;
        if (PlayerPrefs.GetFloat("TiempoObtenido") > tiempoObtenido)
        {
            PlayerPrefs.SetFloat("TiempoObtenido", tiempoObtenido);
        }
        SceneManager.LoadScene(0);
    }

    // Método para mostrar la imagen de derrota y marcar el juego como terminado
    public void LoseGame()
    {
        finish = true;
        loseImage.SetActive(true);
    }
}
