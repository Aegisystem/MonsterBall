using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject loseImage;
    private AudioSource musica;

    public float time = 90f;
    
    public static GameManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        musica = GetComponent<AudioSource>();
        musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            
            loseImage.SetActive(true);
            GoToMainMenu();            
            musica.Stop();
        }
        
    }

    private void GoToMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    
    

    

    
}
