using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{

    public float speed;
    public bool endGame;
    public Transform player;

    private Rigidbody2D rig;
    private Vector2 _direction;
    private float acelerationTime = 5f;
    private float timeleft;
    private Vector2 playerDirection;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        endGame = false;
    }

    private void Update()
    {
        playerDirection = player.position - transform.position;
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _direction.Normalize();
            timeleft += acelerationTime;
        }

    }

    private void FixedUpdate()
    {
        if (!endGame)
        {
            RandomSteps();
            return;
        }
        FollowPlayer(playerDirection);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction *= -1;
    }
    #region Moviment
    private void RandomSteps()
    {
        rig.MovePosition((Vector2)transform.position + (_direction * speed * Time.deltaTime));
    }
    private void FollowPlayer(Vector2 playerDirection)
    {
        rig.MovePosition((Vector2)transform.position + (playerDirection.normalized * speed * Time.deltaTime));
    }
    #endregion
}