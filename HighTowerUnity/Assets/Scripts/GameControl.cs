using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // wird für den Zugriff auf GameControl instanziert
    public static GameControl instance;

    [SerializeField]
    private GameObject finishedText;

    [HideInInspector]
    public bool gameFinished;

    // Bei "Erwachen" der Klasse wird geprüft,
    // dass GameControl wirklich instanziert wird
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Entfernt Restart-Screen, wenn das Spiel neu gestartet wird
        if (gameFinished == false)
        {
            finishedText.SetActive(false);
        }

        // Zeigt Restart-Screen an, wenn Player das Goal erreicht
        if (gameFinished == true)
        {
            finishedText.SetActive(true);
        }

        
    }

}
