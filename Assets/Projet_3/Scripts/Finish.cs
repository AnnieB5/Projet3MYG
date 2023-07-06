using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public CollectKey collectKeyScript;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && collectKeyScript.isOpenDoor == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
