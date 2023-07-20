using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public LifeScore lifeScoreScript; //Référence le script LifeScore
    public int life;
    public int startLife = 10;
    [SerializeField] private GameObject meshGO;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource hurtSound;
    private bool dead = false;
    [SerializeField] private GameObject canvasLostGame;
    [SerializeField] private GameObject canvasMenu;
    public PlayerMovement playerMovementScript;
    public EnemiesScore enemiesScoreScript;
    public Timer timerScript;
    public LayerMask head;
    public float raycastDistance = 0.1f;

    private void Start() //Appelée à la première frame de l'application
    {
        if (canvasLostGame != null && canvasMenu != null) //Permet de laisser les références dans l'inspector du Player vides pour la scène finale
        {
            //Désactive les canvas "perdu" et "quitter/rejouer/menu" par sûreté
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

        if (playerMovementScript.IsGrounded() == false)
        {
            IsEnemyHeadTouched();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si le personnage touche un corps d'ennemi ET que le personnage touche le sol
        if (collision.gameObject.CompareTag("Enemy Body") && playerMovementScript.IsGrounded())
        {
            //Joue le son de blessure du personnage
            hurtSound.Play();

            //Enlève de la vie au joueur selon les dommages de l'ennemi correspondant
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            int damage = enemy.enemyValues.damage;
            life = life - damage;

            if (lifeScoreScript != null)
            {
                //Affiche le nombre de vies restant et sauvegarde la donnée
                lifeScoreScript.DisplayAndSaveScore();
            }

            //DEBUG laisser en comm'
            //Debug.Log("Points de vie restants :" + life);

            if (life <= 0)
            {
                Die();
            }

        }

        //Si le personnage touche de l'eau
        if (collision.gameObject.CompareTag("Water"))
        {
            Die();
        }
    }

    public bool IsEnemyHeadTouched()
    {
        RaycastHit hit;

        //Si le rayon de détection du personnage, pointé vers le bas à ses pieds (comment ?), de longueur 0.1f (raycastDistance), touche une couche nommée "head"
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance, head))
        {
            //Supprime l'ennemi touché (à la tête)
            Destroy(hit.collider.gameObject.transform.parent.gameObject);

            //DEBUG laisser en comm'
            //Affiche en pointillés le raycast en bleu pendant les deux dernières secondes
            //Debug.DrawRay(transform.position, Vector3.down*raycastDistance, Color.blue, 2);

            playerMovementScript.Jump();

            if (enemiesScoreScript != null)
            {
                enemiesScoreScript.AddEnemiesPointScore();
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    public void Die()
    {
        //Fait disparaître le joueur en désactivant son apparence, le MeshRenderer
        meshGO.GetComponent<SkinnedMeshRenderer>().enabled = false;

        //Rend le joueur insensible à la poussée des autres GO (ne bouge plus si on le pousse, car on coche isKinematic)
        GetComponent<Rigidbody>().isKinematic = true;

        //Désactive le script gérant le mouvement du joueur, rendant le mouvement impossible par inputs joueur
        GetComponent<PlayerMovement>().enabled = false;

        if (timerScript != null)
        {
            //Arrête le défilement du chrono
            timerScript.stopChrono = true;
        }

        dead = true;

        //Joue un son pour signifier la mort du joueur
        deathSound.Play();

        if (canvasLostGame != null && canvasMenu != null) //Permet de laisser les références dans l'inspector du Player vides pour la scène finale
        {
            //Active le canvas LostGame
            canvasLostGame.SetActive(true);

            //Désactive après x secondes le canvasLostGame, et active le canvasMenu
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
        //Charge la scène du même nom que l'actuelle (= Recharge la scène)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}