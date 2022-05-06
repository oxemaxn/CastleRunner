using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rig;
    private Vector2 _direction;
    public Transform enemy;
    public float enemyDistanceThreshold;
    public GameObject warnObject;

    //Acessando _direction de forma correta para ser usado em outro script
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
  
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
      
    }

    private void Update() //Relacionado a input
    {
        bool isClose = CheckIfTheEnemyIsClose();
        if (isClose) warnObject.SetActive(true);
        else warnObject.SetActive(false);

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
        Vector3 enemyPosition = enemy.position;
        float distanceBetwwenEnemyAndPlayer = Vector3.Distance(enemyPosition, rig.position);

        return distanceBetwwenEnemyAndPlayer <= enemyDistanceThreshold;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("colidiu");
        if (collision.gameObject.name == "Enemy")
        {

            SceneManager.LoadScene("game_over");
        }
    }

    #endregion
}
