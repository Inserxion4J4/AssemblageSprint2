using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GererMenu : MonoBehaviour
{
    public int niveauGeneration;
    public void CommencerJeu()
    {
        niveauGeneration = Random.Range(1, 4);
        SceneManager.LoadScene(niveauGeneration);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gestionUI.nbrPvActuel = 100;
    }

    public void QuitterJeu()
    {
        Application.Quit();
    }

    public void AfficherControles()
    {
        SceneManager.LoadScene("Commandes");
    }

    public void AfficherMention()
    {
        SceneManager.LoadScene("Mentions");
    }
    public void RevenirMenu()
    {
        SceneManager.LoadScene("MenuStart");
    }
}
