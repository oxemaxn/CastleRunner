using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("fase_1");
        }
    }

}
