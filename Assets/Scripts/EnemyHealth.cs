using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    public float healthVal;
    [SerializeField]
    private Slider healthBar;
    private float maxHealth = 100.0f;
    private float minHealth = 0f;
    public float damage = 10.0f;

    void Start ()
    {
        healthVal = 100;
        maxHealth = 100;
}

    private void FixedUpdate()
    {
        healthBar.value = healthVal;


        if(healthVal >= maxHealth)
        {
            healthVal = 100;
        }
        if (healthVal <= minHealth)
        {
            Destroy(gameObject);

            PlayerStats playerScript = FindObjectOfType<PlayerStats>();
            playerScript.addXP();
        }
    }

    public void minusHealth()
    {
        healthVal -= damage;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Sword")
        {
            minusHealth();
            PlayerStats playerScript = FindObjectOfType<PlayerStats>();
            playerScript.addXP();
        }

    }
    private void OnTriggerExit(Collider col)
    {
        pickup DangerPrompt = FindObjectOfType<pickup>();
        DangerPrompt.Prompt.SetActive(false);
        DangerPrompt.pickupPrompt.SetActive(false);
    }
}

