using UnityEngine;

public class FacePlayerInstant : MonoBehaviour
{
    public Transform player; // assign in inspector or leave null to find by tag

    void Start()
    {
        if (player == null)
        {
            var p = GameObject.FindWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        // compute direction on horizontal plane only
        Vector3 dir = player.position - transform.position;
        dir.y = 0f;
        if (dir.sqrMagnitude < 0.0001f) return;

        // rotate immediately to look at player horizontally
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
