using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            score = 1000;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnEnable()
    {
        GameEvents.OnPause += Pausar;
        GameEvents.OnResume += Reanudar;
    }

    private void OnDisable()
    {
        GameEvents.OnPause -= Pausar;
        GameEvents.OnResume -= Reanudar;
    }

    private void Pausar()
    {
        Time.timeScale = 0;
        Debug.Log("PAUSADO");
    }

    private void Reanudar()
    {
        Time.timeScale = 1;
        Debug.Log("REANUDADO");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0)
            {
                GameEvents.TriggerPause();
            }
            else
            {
                GameEvents.TriggerResume();
            }
            
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Puntaje actualizado a: " + score);

        if (score <= 0)
        {
            if (ApplicationManager.Instance != null)
            {
                Debug.Log("Cambiando a la escena previa...");
                ApplicationManager.Instance.GoToPreviousScene();
            }
            else
            {
                Debug.LogError("ApplicationManager.Instance es null. Asegúrate de que esté en la escena.");
            }
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }
}
