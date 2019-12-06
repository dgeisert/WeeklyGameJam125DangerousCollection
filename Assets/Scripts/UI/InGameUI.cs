using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI objectCount;

    public void UpdateScore(float val)
    {
        scoreText.text = "Score: " + val.ToString("#,#");
    }
    public void EndGame(bool victory)
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        objectCount.text = "Elemental Objects: " + (Plant.plants.Count + Fire.fires.Count + Rock.rocks.Count + Water.waters.Count).ToString() + "/100";
    }
}