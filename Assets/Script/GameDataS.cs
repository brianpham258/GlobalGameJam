using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDataS : MonoBehaviour
{
    public int playerStress;
    public int playerStamina;
    [SerializeField] Text StressMeter;
    [SerializeField] Text Stamina;
    // Start is called before the first frame update
    private void Awake()
    {
        int numGameDataS = FindObjectsOfType<GameDataS>().Length;
        if (numGameDataS > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        StressMeter.text = playerStress.ToString();
        Stamina.text = playerStamina.ToString();
    }
    public int getStamina()
    {
        return playerStamina;
    }
    public void setStamina()
    {
        playerStamina--;
        Stamina.text = playerStamina.ToString();
    }
    public void staminaToAdd(int addStamina) 
    {
        playerStamina += addStamina;
        Stamina.text = playerStamina.ToString();
    }
    public void setStress()
    {
        playerStress++;
        StressMeter.text = playerStress.ToString();
    }

    // Update is called once per frame
    public void playerGameOver()
    {
        if(playerStress > 100)
        {
            takelife();
        }
        else
        {
            resetGameSession();
        }
    }

    private void takelife()
    {

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }

    private void resetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
