using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // <-- Required for UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 2f;

    [Header("UI")]
    public Image healthBarFill; // Drag in the UI Image (HealthBarFill)

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage()
    {
        if (isInvulnerable) return;

        currentHealth--;
        Debug.Log("Player hit! Health: " + currentHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f; // Freeze game
        }
        else
        {
            StartCoroutine(InvulnerabilityCoroutine());
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    private System.Collections.IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }
}
