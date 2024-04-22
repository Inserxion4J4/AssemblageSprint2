using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject panneauPause;
    bool pauseEnCours;
    // Start is called before the first frame update
    void Start()
    {
        panneauPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!pauseEnCours)
            {
                Pause();
            }
            else
            {
                Continuer();
            }
        }
    }

    public void Pause() 
    {
        panneauPause.SetActive(true);
        Time.timeScale = 0f;
        pauseEnCours = true;
    }

    public void Continuer() 
    {
        panneauPause.SetActive(false);
        Time.timeScale = 1f;
        pauseEnCours = false;
    }
}
