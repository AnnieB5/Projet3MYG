using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    [SerializeField] GameObject meshGO;
    bool dead = false;

    private Timer timer;

    public int life;
    public int startLife = 10;

    private void Start()
    {
        life = startLife;
    }

    private void Update()
    {
        if (transform.position.y < -1f && !dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            

            //on applique les damage de l'ennemi correspondant
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            int damage = enemy.enemyValues.damage;
            life = life - damage;
            Debug.Log("Points de vie restants :" + life);
            if (life <= 0)
            {
                //fait disparaître le joueur en désactivant son apparence, le MeshRenderer
                meshGO.GetComponent<SkinnedMeshRenderer>().enabled = false;

                //rend le joueur insensible à la poussée des autres GO (ne bouge plus si on le pousse, car on coche isKinematic)
                GetComponent<Rigidbody>().isKinematic = true;

                //désactive le script gérant le mouvement du joueur, rendant le mouvement impossible par inputs joueur
                GetComponent<PlayerMovement>().enabled = false;
                
                Die();
            }
            
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            //fait disparaître le joueur en désactivant son apparence, le MeshRenderer
            meshGO.GetComponent<SkinnedMeshRenderer>().enabled = false;

            //rend le joueur insensible à la poussée des autres GO (ne bouge plus si on le pousse, car on coche isKinematic)
            GetComponent<Rigidbody>().isKinematic = true;

            //désactive le script gérant le mouvement du joueur, rendant le mouvement impossible par inputs joueur
            GetComponent<PlayerMovement>().enabled = false;

            Die();
        }
    }

    public void Die()
    {
        //relance le niveau qu'après une attente de 1,3 secondes.
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        deathSound.Play();   
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        timer.timeValue = timer.timeStart;
    }
}