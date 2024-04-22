using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarderMusique : MonoBehaviour
{
    // Variable bool v�rifiant si la musique est d�j� duppliqu�e
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
