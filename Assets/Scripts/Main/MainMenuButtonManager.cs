using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Creature;

public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject newGameCanvas;

    public void NewGame()
    {
        gameObject.SetActive(false);
        newGameCanvas.SetActive(true);   
    }

    public void HerbivoreGame()
    {
        Game.playerType = CreatureType.HERBIVORE;

        SceneManager.LoadScene("MainScene");
    }

    public void CarnivoreGame()
    {
        Game.playerType = CreatureType.CARNIVORE;

        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        gameObject.SetActive(true);
        newGameCanvas.SetActive(false);
    }
}
