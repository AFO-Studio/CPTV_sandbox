using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;

    private float maxHealth = 100.0f;
    private float minHealth = 0f;

    public float currentHealth;

    public float damage = 10.0f;

    void Start ()
    {
        currentHealth = 100;
        maxHealth = 100;
    }

    private void FixedUpdate()
    {
        healthBar.value = currentHealth;

        if(currentHealth >= maxHealth)
            currentHealth = 100;

        if (currentHealth <= minHealth)
        {
            Destroy(gameObject);

            PlayerStats playerScript = FindObjectOfType<PlayerStats>();
            playerScript.addXP();
        }
    }

    public void DecreaseHealth(float damage = 1f)
    {
        currentHealth -= damage * damage;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Sword")
        {
            DecreaseHealth();

            PlayerStats playerScript = FindObjectOfType<PlayerStats>();
            playerScript.addXP();
        }
        if (col.gameObject.tag == "Bullet")
        {
            DecreaseHealth(8);

            PlayerStats playerScript = FindObjectOfType<PlayerStats>();
            playerScript.addXP();
        }

    }
    private void OnTriggerExit(Collider col)
    {
        Pickup DangerPrompt = FindObjectOfType<Pickup>();
        DangerPrompt.Prompt.SetActive(false);
        DangerPrompt.pickupPrompt.SetActive(false);
    }
}

