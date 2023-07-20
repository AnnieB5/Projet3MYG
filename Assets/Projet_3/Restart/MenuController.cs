using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //RestartGame.instance.Quit(); //exemple appel depuis ailleurs
    }

    public void Restart()
    {
        //Reload scene 0 et reset playerprefs, prévoir bouton appelant la méthode
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Recharge la même scène

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("On a quitté l'application du jeu");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0); //Charge et retourne à la scène 0, normalement la scène du menu/start
    }
}
