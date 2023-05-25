using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPlayerPrefs : MonoBehaviour
{
    private Scene m_Scene;

    [SerializeField] private ItemCollector itemCollectorScript;
    [SerializeField] private EnemiesScore enemiesScoreScript;
    [SerializeField] private ItemScore itemScoreScript;

    public int coinsCount = 0;
    public int score = 0;
    public int enemiesScore = 0;
    
    
    private void Awake() //Méthode appelée à chaque activation du GO, instantation de GO et chargement de scène
    {
        //Le GO associé au script reste dans la Hierarchy même en changeant de scène
        DontDestroyOnLoad(this.gameObject);

        /*
        //Return the current Active Scene in order to get the current Scene's name
        m_Scene = SceneManager.GetActiveScene();

        //créer, maj les données ici, qui se supprimeront en quittant la partie tout seul
        if (m_Scene.name == "Level01")
        {  
            coinsCount = 0;
            score = 0;
            enemiesScore = 0;
            //PlayerPrefs.DeleteAll();
            //PlayerPrefs.SetInt("ItemScore", 0);
        }

        //Supprime tous les PlayerPrefs et leurs données
        */
        
    }

    //créer, maj les données ici, qui se supprimeront en quittant la partie tout seul
    
}
