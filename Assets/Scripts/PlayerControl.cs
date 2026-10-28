using System; // Tilføj denne for at kunne bruge Action
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Keyboard keyboard;
    public float speed = 1f;

    [Header("Health Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    // Dette er eventen, som dit GameUIHandler-script lytter på!
    public event Action OnHealthChange;

    void Start()
    {
        keyboard = Keyboard.current;
        currentHealth = maxHealth; // Sæt liv til max ved start
    }

    void Update()
    {
        if (keyboard != null)
        {
            Vector3 movement = Vector3.zero;

            if (keyboard.wKey.isPressed) { movement += Vector3.forward; }
            if (keyboard.sKey.isPressed) { movement += Vector3.back; }
            if (keyboard.aKey.isPressed) { movement += Vector3.left; }
            if (keyboard.dKey.isPressed) { movement += Vector3.right; }

            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.MovePosition(rb.position + movement * Time.deltaTime * speed);
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

    // Eksempel til test: Tryk på 'H'-tasten for at miste 10 liv og se UI'et opdatere sig
    private void LateUpdate()
    {
        if (keyboard != null && keyboard.hKey.wasPressedThisFrame)
        {
            TakeDamage(10);
        }
    }
}