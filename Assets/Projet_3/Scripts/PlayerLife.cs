using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    bool dead = false;
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
            //fait disparaître le joueur en désactivant son apparence, le MeshRenderer
            GetComponent<MeshRenderer>().enabled = false;

            //rend le joueur insensible à la poussée des autres GO (ne bouge plus si on le pousse, car on coche isKinematic)
            GetComponent<Rigidbody>().isKinematic = true;

            //désactive le script gérant le mouvement du joueur, rendant le mouvement impossible par inputs joueur
            GetComponent<PlayerMovement>().enabled = false;

            Die();
        }
    }

    void Die()
    {
        //relance le niveau qu'après une attente de 1,3 secondes.
        Invoke(nameof(ReloadLevel), 1.3f);
        dead = true;
        deathSound.Play();   
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}