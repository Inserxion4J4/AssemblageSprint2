using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gestionUI : MonoBehaviour
{
    // Gestion pv
    public Image barrePv;
    float nbrPvMax = 100;
    public static float nbrPvActuel = 100;

    // Gestion chargeur
    public static float chargeurActuel = 15;
    float chargeurMax = 15;
    
    public TextMeshProUGUI compteurChargeurActuel;
    public TextMeshProUGUI compteurChargeurMax;


    // Capacit�s

    // Capacit� 1 - Dash
    public Image capaciteImageDash;
    public KeyCode toucheDash;
    float cooldownTempsDash = 5;

    bool cooldownEnCoursDash = false;
    float cooldownActuelDash;

    // Capacit� 2 - Bouclier
    public Image capaciteImageBouclier;
    public KeyCode toucheBouclier;
    float cooldownTempsBouclier = 20;

    bool cooldownEnCoursBouclier = false;
    float cooldownActuelBouclier;

    // Capacit� 3 - Grenade incendiaire
    public Image capaciteImageGrenade;
    public KeyCode toucheGrenade;
    float cooldownTempsGrenade = 45;

    bool cooldownEnCoursGrenade = false;
    float cooldownActuelGrenade;


    public AudioClip sonRechargementPistolet;
    AudioSource audioSource;
    private void Start()
    {
        capaciteImageDash.fillAmount = 0;
        capaciteImageBouclier.fillAmount = 0;
        capaciteImageGrenade.fillAmount = 0;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Gestion capacit�s

        // Capacit� 2 - Grenade incendiaire
        CapaciteDashInput();

        CapaciteCooldown(ref cooldownActuelDash, cooldownTempsDash, ref cooldownEnCoursDash, capaciteImageDash);

        // Capacit� 2 - Grenade incendiaire
        CapaciteBouclierInput();

        CapaciteCooldown(ref cooldownActuelBouclier, cooldownTempsBouclier, ref cooldownEnCoursBouclier, capaciteImageBouclier);

        // Capacit� 3 - Grenade incendiaire
        CapaciteGrenadeInput();

        CapaciteCooldown(ref cooldownActuelGrenade, cooldownTempsGrenade, ref cooldownEnCoursGrenade, capaciteImageGrenade);



        // Gestion affichage barre vie
        float pourcentagePv = nbrPvActuel / nbrPvMax;
        barrePv.fillAmount = pourcentagePv;

        // Gestion chargeur
        compteurChargeurActuel.text = chargeurActuel.ToString();
        compteurChargeurMax.text = chargeurMax.ToString();

        if (Input.GetKeyDown(KeyCode.Mouse0) && chargeurActuel > 0)
        {
            chargeurActuel -= 1;
        }

        if (Input.GetKeyDown(KeyCode.R) && chargeurActuel != 15)
        {
            audioSource.PlayOneShot(sonRechargementPistolet);
            Invoke("Recharger", 1f);
        }

        if (nbrPvActuel <= 0) {
            SceneManager.LoadScene("MenuStart");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void Recharger()
    {
        chargeurActuel = chargeurMax;
    }

    void CapaciteDashInput()
    {
        if (Input.GetKeyDown(toucheDash) && !cooldownEnCoursDash)
        {
            cooldownEnCoursDash = true;
            cooldownActuelDash = cooldownTempsDash;
        }
    }

    void CapaciteBouclierInput()
    {
        if (Input.GetKeyDown(toucheBouclier) && !cooldownEnCoursBouclier)
        {
            cooldownEnCoursBouclier = true;
            cooldownActuelBouclier = cooldownTempsBouclier;
        }
    }

    void CapaciteGrenadeInput()
    {
        if (Input.GetKeyDown(toucheGrenade) && !cooldownEnCoursGrenade)
        {
            cooldownEnCoursGrenade = true;
            cooldownActuelGrenade = cooldownTempsGrenade;
        }
    }

    void CapaciteCooldown(ref float cooldownActuel, float cooldownMax, ref bool cooldownEnCours, Image capaciteImage)
    {
        if (cooldownEnCours)
        {
            cooldownActuel -= Time.deltaTime;

            if (cooldownActuel <= 0)
            {
                cooldownEnCours = false;
                cooldownActuel = 0;

                if(capaciteImage != null)
                {
                    capaciteImage.fillAmount = 0;
                }
            }
            else
            {
                if (capaciteImage != null)
                {
                    capaciteImage.fillAmount = cooldownActuel / cooldownMax;
                }
            }
        }
    }
}
