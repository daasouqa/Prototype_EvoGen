using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Creature;

public class MainMenuButtonManager : MonoBehaviour
{
    public GameObject newGameCanvas;
    public GameObject chooseSexcanvas;

    public void Restart()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void NewGame()
    {
        gameObject.SetActive(false);
        newGameCanvas.SetActive(true);   
    }

    public void HerbivoreGame()
    {
        Game.playerType = CreatureType.HERBIVORE;

        newGameCanvas.SetActive(false);
        chooseSexcanvas.SetActive(true);

    }

    public void CarnivoreGame()
    {
        Game.playerType = CreatureType.CARNIVORE;

        newGameCanvas.SetActive(false);
        chooseSexcanvas.SetActive(true);
    }

    public void MaleGame()
    {
        Game.playerSex = Creature.Sex.MALE;
        SceneManager.LoadScene("MainScene");
    }

    public void FemaleGame()
    {
        Game.playerSex = Creature.Sex.FEMALE;
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
