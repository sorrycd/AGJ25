using UnityEngine;

public class PlayerAttackStab : MonoBehaviour
{
    public int damageAmount = 25;
    public float attackRange = 2f;
    public LayerMask enemyLayer; // assign "Enemy" layer in Inspector

    // Called from the animation event
    public void DealDamageStab()
    {
        Debug.Log("DealDamage called!");

        // Detect enemies in range
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth health = enemy.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }


    // Just to visualize the range in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
