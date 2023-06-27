using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSparkling : MonoBehaviour
{
    public float totalSeconds; 	// The total of seconds the flash will last
	public float maxIntensity; 	// The maximum intensity the flash will reach
    public float minIntensity; 	// The minimum intensity the flash will reach
	[SerializeField] private Light myLight;  // Your light


    // Start is called before the first frame update
    void Start()
    {
        myLight.gameObject.SetActive(true); //remettre en false quand corrections terminées /!\/!\
    }

    void Update()
    {
        //si light activée, faire scintiller
        if(myLight.gameObject.activeSelf == true)
        {
            flashingLight();
        }
    }

    
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
    

    //variation intensité dans le temps quand activée
    //si la light est activée par trigger enter, alors
    //faire varier intensité entre x et y de manière aléatoire, tous les x temps aléatoire
    //arrêter dès extinction light par trigger exit

    private void flashingLight()
    {
        float waitTime = totalSeconds / 2;						// Get half of the seconds (One half to get brighter and one to get darker)

		while (myLight.intensity < maxIntensity) 
        {
			myLight.intensity += Time.deltaTime / waitTime;		// Increase intensity
			break;
		}

		while (myLight.intensity > 0) 
        {
			myLight.intensity -= Time.deltaTime / waitTime;		//Decrease intensity
			break;
		}
    }
    
	public IEnumerator sparkleLight()
	{
		float waitTime = totalSeconds / 2;						
		// Get half of the seconds (One half to get brighter and one to get darker)
		while (myLight.intensity < maxIntensity) {
			myLight.intensity += Time.deltaTime / waitTime;		// Increase intensity
			yield return null;
		}
		while (myLight.intensity > 0) {
			myLight.intensity -= Time.deltaTime / waitTime;		//Decrease intensity
			yield return null;
		}
		yield return null;
	}

    private void flashingLightPerso()
    {
        float waitTime = totalSeconds / 2;						// Get half of the seconds (One half to get brighter and one to get darker)

        //Pendant [waitTime] secondes, augmenter l'intensité jusqu'à [maxIntensity], puis, quand max est atteint, baisser intensité pdt [waitTime] secondes.
        for (float timeElapsed = minIntensity; timeElapsed < waitTime; timeElapsed += Time.deltaTime)
        {
            myLight.intensity++;
        }

        if (myLight.intensity == maxIntensity)
        {
            for (float timeElapsed = maxIntensity; timeElapsed < waitTime; timeElapsed -= Time.deltaTime)
            {
                myLight.intensity--;
            }
        
        }

		while (myLight.intensity < maxIntensity) 
        {
			myLight.intensity += Time.deltaTime / waitTime;		// Increase intensity
			break;
		}

		while (myLight.intensity > 0) 
        {
			myLight.intensity -= Time.deltaTime / waitTime;		//Decrease intensity
			break;
		}
    }
}
