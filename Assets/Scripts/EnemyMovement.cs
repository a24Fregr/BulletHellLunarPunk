using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private EnemyStats enemyStats;
    readonly float deadZone = 0.1f;
    Rigidbody2D rb2D;
    [SerializeField] private UnityEvent onDeath;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        enemyStats.onDeath.AddListener(OnDeath);
    }

    void OnDeath()
    {
        onDeath.Invoke();
    }

    float AngleMath(Vector2 Dest)
    {
        return Mathf.Atan2(rb2D.position.y - Dest.y, rb2D.position.x - Dest.x);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Dest = player.GetComponent<Rigidbody2D>().position;
        float angle = AngleMath(Dest);
        float length = Mathf.Abs(Vector2.Distance(Dest, rb2D.position));

        if (length + deadZone < enemyStats.MinDistance)
        {
            rb2D.velocity = new Vector2(enemyStats.Speed * Mathf.Cos(angle), enemyStats.Speed * Mathf.Sin(angle));
        }
        else if (length - deadZone > enemyStats.MinDistance)
        {
            rb2D.velocity = new Vector2(-enemyStats.Speed * Mathf.Cos(angle), -enemyStats.Speed * Mathf.Sin(angle));
        }
        else
        {
            rb2D.velocity = new Vector2(0, 0);
            return;
        }
    }
}
