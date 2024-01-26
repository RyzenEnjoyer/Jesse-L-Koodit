using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;
    public static PlayerHealth instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void AddPlayerHealth(int healthAmmount)
    {
        currentHealth += healthAmmount;
        // Jos terveys menee yli maksimin, niin estetään se
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthbar.SetHealth(currentHealth);

    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(1); 
        }
        healthbar.SetHealth(currentHealth);
    }
}
