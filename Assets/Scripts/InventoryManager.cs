using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public GameObject FakeWall;
    public List<Vector3> letterPositionMatrix = new List<Vector3>();

    public List<char> inventoryList = new List<char>();
    public int numberOfLetters = 3;
    public string word = "BAG";
    private Canvas canvas;
    public List<Vector2> letterPositionList = new List<Vector2>();
    private TextMeshPro mesh;
    private GameObject objectChild;
    private char letterToAdd;

    void Start()
    {
        setLetterPosition();
    }

    public void PickupLetter(GameObject obj)
    {   
        objectChild = obj.transform.GetChild(0).GetChild(0).gameObject;

        if (objectChild.tag == "LetterText")
        {
            letterToAdd = objectChild.GetComponentInChildren<TextMeshProUGUI>().text.ToCharArray()[0];
            inventoryList.Add(letterToAdd);
            if(!LevelFinished() && LevelWronglyFinished())
            {
                // Game over
            } else if(LevelFinished()) {
                // Won
                FakeWall.SetActive(false);
            } else {
                // Playing
                UpdateInventoryLetters();
                obj.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }

    public void UpdateInventoryLetters()
    {
        for(int i = 0; i < numberOfLetters; i++)
        {
            var inventoryItem = GameObject.FindWithTag($"Letter{i}");
            var itemText = inventoryItem.GetComponent<TMPro.TextMeshProUGUI>();
            if(i <= inventoryList.Count -1)
            {
                itemText.text = inventoryList[i].ToString();
            } else {
                itemText.text = '_'.ToString();
            }
        }
    }

    public bool LevelFinished()
    {
        if(inventoryList.Count == numberOfLetters)
        {
            if(new string(inventoryList.ToArray()) == word)
            {
                return true;
            }
        }
        return false;
    }

    public bool LevelWronglyFinished()
    {
        if(inventoryList.Count == numberOfLetters)
        {
            if(new string(inventoryList.ToArray()) != word)
            {
                return true;
            }
        }
        return false;
    }

    public void RestartLetters()
    {
        var letterList = GameObject.FindGameObjectsWithTag("LetterContainer");
         foreach(GameObject letterContainer in letterList)
         {
             Debug.LogWarning($"Loop ------>>>: {letterContainer.tag}");
             letterContainer.transform.localScale = new Vector3(1, 1, 1);
         }
    }

    public void RestartPlayerPosition() 
    {
        var player = GameObject.FindGameObjectsWithTag("Player")[0];
        player.transform.position = new Vector3(-15, 8, 0);
    }

    public void ClearBag()
    {
        Debug.LogWarning($"Clear Bag click ------>>>");
        inventoryList.Clear();
        RestartPlayerPosition();
        UpdateInventoryLetters();
        RandomLetterPositionList();
        RestartLetters();
    }

    private void RandomLetterPositionList()
    {
        var letterList = GameObject.FindGameObjectsWithTag("LetterContainer");
        for(int i = 0; i < numberOfLetters; i++)
        {
            int num = Random.Range(i*numberOfLetters, (i*numberOfLetters)+2);
            letterList[i].transform.position = letterPositionMatrix[num];
        }
    }

    private void setLetterPosition()
    {   var letterList = GameObject.FindGameObjectsWithTag("LetterContainer");
        foreach(GameObject letterContainer in letterList)
        {
            letterPositionList.Add(letterContainer.transform.position);
        }
    }
}
