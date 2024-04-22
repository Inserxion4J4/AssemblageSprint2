using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnleverMusique : MonoBehaviour
{
    // Lorsque a sc�ne de jeu est charg�e, la musique d'intro est mise en sourdine.
    // Lorsque le joueur revient � l'accueil, le volume est remont�
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
