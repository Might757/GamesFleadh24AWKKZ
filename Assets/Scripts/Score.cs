using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI MyScoreText;
    public int ScoreNum;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyScoreText.text = "Cells infected : " + ScoreNum + "/6";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if(coin.tag == "Coin")
        {
            ScoreNum += 1;
            MyScoreText.text = "Cells infected :" + ScoreNum + "/6";
            Destroy(coin.gameObject);


        }
     }
     
 }
