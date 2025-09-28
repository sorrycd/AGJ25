using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 2f;

    [Header("UI")]
    public Image healthBarFill;

    [Header("Death")]
    public string deathCutsceneSceneName = "DeathCutscene";

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
            SceneManager.LoadScene(deathCutsceneSceneName);
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