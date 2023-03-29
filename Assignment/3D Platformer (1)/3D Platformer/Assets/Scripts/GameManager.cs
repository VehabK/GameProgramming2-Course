using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton Instance

    public int score;
    public int lastScore;

    void Awake() 
    {
        // Set Instance to this, Destroy if another instance is in the scene.

        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        UIManager.Instance.SetScore(score);
    }

    public void AddScore(int x)
    {
        score += x;
    }

    public void ResetScore()
    {
        score = lastScore;
    }

    public void OnDeath()
    {
        score = lastScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishStage()
    {
        lastScore = score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetAll()
    {
        score = 0;
        lastScore = 0;
    }
}
