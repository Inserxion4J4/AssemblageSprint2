using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnleverMusique : MonoBehaviour
{
    // Lorsque a scène de jeu est chargée, la musique d'intro est mise en sourdine.
    // Lorsque le joueur revient à l'accueil, le volume est remonté
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "niveauTUTO")
        {
            gameObject.GetComponent<AudioSource>().volume = 0f;
        }
        if (SceneManager.GetActiveScene().name == "MenuStart")
        {
            gameObject.GetComponent<AudioSource>().volume = 0.5f;
        }
    }
}
