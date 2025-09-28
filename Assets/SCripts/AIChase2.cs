using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase2 : MonoBehaviour
{
    public GameObject player;
    public float speed;


    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.forward;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        //dond mind this

    }
}