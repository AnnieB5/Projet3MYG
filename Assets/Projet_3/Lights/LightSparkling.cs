using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSparkling : MonoBehaviour
{
    public float minIntensity; //Détermine l'intensité minimale que peut avoir la lumière
    public float maxIntensity; //Détermine l'intensité maximale que peut atteindre la lumière
    private float addIntensity = 0.1f; //Détermine l'ajout d'intensité (par quelle unité de temps?)
    [Range(0,1)] public float waitTime = 0.1f; //Paramètre le temps d'attente entre une hausse ou une baisse totale d'intensité
    private bool flagOn; //Drapeau pour activer/désactiver le scintillement en fonction de l'état d'activation du script
    [SerializeField] private Light myLight;  //Référence la lumière concernée

    void OnEnable() //Appelée à chaque activation du script (ce qui est différent du Start())
    {
        flagOn = true; //active le scintillement dans la coroutine
        Debug.Log("On active le script");
        StartCoroutine(sparkleLight());
    }

    void OnDisable() //Appelée à chaque désactivation du script
    {
        flagOn = false; //désactive le scintillement dans la coroutine
        Debug.Log("On désactive le script");
        StopCoroutine(sparkleLight());
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    myLight.gameObject.SetActive(false);
    //}

    /*
    private void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag("Player"))
        return;

        myLight.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.gameObject.CompareTag("Player"))
        return;

        myLight.gameObject.SetActive(false);
    }
    */

    public IEnumerator sparkleLight()
    {
        Debug.Log("Entrée de coroutine réussie");
        //float waitTime = totalSeconds / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)



        while (flagOn)
        {
            while (myLight.intensity < maxIntensity)
            {
                myLight.intensity += addIntensity;     // Increase intensity
                yield return new WaitForSeconds(waitTime);
            }
            while (myLight.intensity > 0)
            {
                myLight.intensity -= addIntensity;     //Decrease intensity
                yield return new WaitForSeconds(waitTime);
            }
        }


        Debug.Log("Sortie de coroutine réussie");
        yield return null;
    }

}
