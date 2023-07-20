using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public CollectKey collectKeyScript;
    public Timer timerScript;
    private void OnCollisionEnter(Collision collision)
    {
        //Si le GO touché est le personnage et que la porte est ouverte
        if (collision.gameObject.name == "Player" && collectKeyScript.isOpenDoor == true)
        {
            //Arrête le chrono, calcule le temps réalisé et le sauvegarde avec un PlayerPref
            timerScript.StopAndSaveTime();

            //Charge la scène suivante (scène finale)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
