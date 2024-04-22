using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinitionNiveau1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ennemiScript.compteurEnnemisMorts == 10)
        {
            SceneManager.LoadScene("MenuStart");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
