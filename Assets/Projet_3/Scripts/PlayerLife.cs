using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public LifeScore lifeScoreScript; //Référence le script LifeScore
    public int life;
    public int startLife = 10;
    [SerializeField] private GameObject meshGO;
    [SerializeField] private AudioSource deathSound;
    private bool dead = false;
    [SerializeField] private GameObject canvasLostGame;
    [SerializeField] private GameObject canvasMenu;
    public Timer timerScript;

    private void Start() //Appelée à la première frame de l'application
    {
        if (canvasLostGame != null && canvasMenu != null) //permet de laisser les références dans l'inspector du Player vides pour la scène fianale
        {
            //désactiver les canvas "perdu" et "quitter/rejouer/menu" par sûreté
            canvasLostGame.SetActive(false);
            canvasMenu.SetActive(false);
        }

        life = startLife;

        if (lifeScoreScript != null)
        {
            //Affiche le nombre de vies initial et sauvegarde la donnée
            lifeScoreScript.DisplayAndSaveScore();
        }

    }

    private void Update()
    {
        if (transform.position.y < -1f && !dead) //Tue le joueur s'il est trop bas dans la map
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            //Enlève de la vie au joueur selon les dommages de l'ennemi correspondant
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            int damage = enemy.enemyValues.damage;
            life = life - damage;

            //Affiche le nombre de vies restant et sauvegarde la donnée
            lifeScoreScript.DisplayAndSaveScore();

            Debug.Log("Points de vie restants :" + life);

            if (life <= 0)
            {
                Die();
            }

        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Die();
        }
    }

    public void Die()
    {
        //fait disparaître le joueur en désactivant son apparence, le MeshRenderer
        meshGO.GetComponent<SkinnedMeshRenderer>().enabled = false;

        //rend le joueur insensible à la poussée des autres GO (ne bouge plus si on le pousse, car on coche isKinematic)
        GetComponent<Rigidbody>().isKinematic = true;

        //désactive le script gérant le mouvement du joueur, rendant le mouvement impossible par inputs joueur
        GetComponent<PlayerMovement>().enabled = false;

        if (timerScript != null)
        {
            //arrête le défilement du chrono
            timerScript.stopChrono = true;
        }

        dead = true;

        //joue un son pour signifier la mort du joueur
        deathSound.Play();

        if (canvasLostGame != null && canvasMenu != null) //permet de laisser les références dans l'inspector du Player vides pour la scène fianale
        {
            //active le canvas LostGame
            canvasLostGame.SetActive(true);

            //désactive après x secondes le canvasLostGame, et active le canvasMenu
            Invoke("ActivateCanvasMenu", 3);
        }
    }

    public void ActivateCanvasMenu()
    {
        canvasLostGame.SetActive(false);
        canvasMenu.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}