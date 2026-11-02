using System; // Tilføj denne for at kunne bruge Action
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    // Dette er eventen, som dit GameUIHandler-script lytter på!
    public event Action OnHealthChange;

    void Start()
    {
        currentHealth = maxHealth; // Sæt liv til max ved start
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.hKey.wasPressedThisFrame)
        {
            TakeDamage(35);
        }
    }

    // Eksempel på en funktion der giver skade (kald denne når spilleren rammer en rød kube)
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Sørg for helbred ikke går under 0

        // Fortæl alle der lytter (f.eks. UI'et) at helbredet har ændret sig
        OnHealthChange?.Invoke();

        if (currentHealth <= 0)
        {
            Debug.Log("Spilleren er død!");
            // Her kan du evt. genstarte spillet el.lign.
        }
    }
}