using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float speedEndGame;
    public Transform player;

    private Rigidbody2D rig;
    private BoxCollider2D col;
    private Vector2 _direction;
    private float acelerationTime = 5f;
    private float timeleft;
    private Vector2 playerDirection;

    public GameController GC;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        gameObject.GetComponent<Renderer>().enabled = false;
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
        if (!GC.isEndGame)
        {
            col.enabled = true;
            RandomSteps();
            return;
        }
        col.enabled = false;
        FollowPlayer(playerDirection);
        OnCollisionInEndGame();
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
      
        rig.MovePosition((Vector2)transform.position + (playerDirection.normalized * speedEndGame * Time.deltaTime));
    }

    private void OnCollisionInEndGame()
    {
        float precision = 0.1f;
        if (Vector2.Distance(player.position, rig.position) <= precision)
        {
            col.enabled = true;
        }
    }
    #endregion
}