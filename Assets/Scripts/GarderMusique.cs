using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarderMusique : MonoBehaviour
{
    // Variable bool vérifiant si la musique est déjà duppliquée
    public static bool dontDestroyDejaFait = false;

    void Start()
    {
        if (dontDestroyDejaFait == false)
        {
            DontDestroyOnLoad(gameObject);
            dontDestroyDejaFait = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
