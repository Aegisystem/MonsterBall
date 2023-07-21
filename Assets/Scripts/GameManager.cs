using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loseImage;
    [FormerlySerializedAs("startImage")] [SerializeField]
    private GameObject startText; 
    private AudioSource musica;

    public float time = 90f;
    public bool finish = false;
    private bool gameStarted = false; // Variable para verificar si el juego ha comenzado
    private bool defeat = false;

    public static GameManager Instance;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        musica = GetComponent<AudioSource>();
        // Comienza el juego desactivado para que todo esté quieto
        Time.timeScale = 0f;
        musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            if (gameStarted) // Solo actualiza el tiempo si el juego ha comenzado
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    LoseGame();
                }
            }

            if (defeat)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    GoToMainMenu();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
        else
        {
            // Si el juego ha terminado, cargar la escena "Menu" con el tiempo obtenido
            if (Input.GetKeyDown("space"))
            {
                LoadMenuSceneWithTime();
            }
        }
    }

    // Método para cargar la escena "Menu" con el tiempo obtenido
    private void LoadMenuSceneWithTime()
    {
        float tiempoObtenido = 90f - time;
        if (PlayerPrefs.GetFloat("Tiempo") > tiempoObtenido || PlayerPrefs.GetFloat("Tiempo") == 0)
        {
            PlayerPrefs.SetFloat("Tiempo", tiempoObtenido);
        }
        SceneManager.LoadScene(0);
    }

    // Método para mostrar la imagen de derrota y marcar el juego como terminado
    public void LoseGame()
    {
        defeat = true;
        loseImage.SetActive(true);
        musica.Stop();
    }

    private void GoToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void StartGame()
    {
        // Comienza el juego, activando el tiempo y permitiendo el movimiento
        startText.SetActive(false);
        Time.timeScale = 1f;
        gameStarted = true;
    }
}