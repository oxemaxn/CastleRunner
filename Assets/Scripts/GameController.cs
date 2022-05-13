using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string currentWord;
    public string wordExpected;
    public bool isEndGame;
    public GameObject fakeWall;
    public Text bag;
    public Text warning;
    public GameObject enemy;
    public AudioSource rightLetter;

 
    private void Update()
    {
        if (Input.GetKeyDown("backspace"))
        {
            if (!currentWord.Equals(wordExpected))
            {
                ResetBag();
            }
        }
    }
    public void SetBagLevel(string letter)
    {

        if(letter[0] == wordExpected[currentWord.Length])
        {
            BlinkEye();
            rightLetter.Play();
        }
        currentWord += letter;
        bag.text = currentWord;
        if(currentWord.Length == wordExpected.Length)
        {
            if (!currentWord.Equals(wordExpected))
            {
                StartBlinking();
            }
            else {
                SetEndgame();
            }
        }
    }
    public void ResetBag()
    {
        currentWord = "";
        bag.text = "";
        warning.text = "";
        StopBlinking();
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
            
        }
    }
    public void SetEndgame()
    {
        isEndGame = true;
        fakeWall.SetActive(false);
    }
    IEnumerator Blink()
    {
        while (true)
        {
            warning.text = "Press Backspace";
            yield return new WaitForSeconds(.5f);
            warning.text = "";
            yield return new WaitForSeconds(.5f);
        }

    }
    public void StartBlinking()
    {
        StartCoroutine("Blink");
    }
    public void StopBlinking()
    {
        StopCoroutine("Blink");
    }
    public void BlinkEye()
    {
        enemy.GetComponent<Renderer>().enabled = true;
        new WaitForSeconds(.5f);
        enemy.GetComponent<Renderer>().enabled = false;
        new WaitForSeconds(.5f);
       
    }
}
