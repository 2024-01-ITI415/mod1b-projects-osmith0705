using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        scoreGT = scoreGO.GetComponent<Text>();

        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition2D = Input.mousePosition;

        mousePosition2D.z = -Camera.main.transform.position.z;

        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePosition3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if(collided.tag == "Apple") { 
            Destroy(collided);


            int score = int.Parse(scoreGT.text);

            score += 100;
            
            scoreGT.text = score.ToString();
           
            if(score > HighAcore.score)
            {
                HighAcore.score = score;
            }
        }
    }
}
