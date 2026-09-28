using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public TMP_Text scoreGT;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<TMP_Text>();
        scoreGT.text = "0";
    }
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(mousePos.x, mousePos.y, -Camera.main.transform.position.z)
        );

        transform.position = new Vector3(
            worldPos.x,
            transform.position.y,
            transform.position.z
        );
    }

    void OnCollisionEnter( Collision coll ) { 
        GameObject collidedWith = coll.gameObject;

        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
            {
            HighScore.score = score;
            }
        }
        if (collidedWith.CompareTag("Branch"))
        {
            Destroy(collidedWith);
            GameManager.S.GameOver();
        }

    }
}
