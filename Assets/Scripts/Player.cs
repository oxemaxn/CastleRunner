using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;
    public GameObject enemy;
    public float enemyDistanceThreshold;
    public GameObject warnObject;
    public string letters;

    //Acessando _direction de forma correta para ser usado em outro script
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
  
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        letters = "";
    }

    private void Update() //Relacionado a input
    {
        bool isClose = CheckIfTheEnemyIsClose();
        if (isClose)
        {
            warnObject.SetActive(true);
            enemy.GetComponent<Renderer>().enabled = true;
        }
        else { 
            warnObject.SetActive(false);
            enemy.GetComponent<Renderer>().enabled = false;
        }

        OnInput();
    }

    private void FixedUpdate() // Relacionado a fisica
    {
        OnMove();
    }

    #region Movement

        void OnInput()
        {
            _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        void OnMove()
        {
            rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
        }

    #endregion


    #region Interactors
    private bool CheckIfTheEnemyIsClose()
    {

        Vector3 enemyPosition = enemy.transform.position;
        float distanceBetwwenEnemyAndPlayer = Vector3.Distance(enemyPosition, rig.position);

        return distanceBetwwenEnemyAndPlayer <= enemyDistanceThreshold;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            SceneManager.LoadScene("game_over");
        }
    }

    #endregion
}
