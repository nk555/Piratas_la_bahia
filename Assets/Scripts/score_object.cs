using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_object : MonoBehaviour
{
    private int score=0;
    public Text score_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.score_text.text="Score: "+score;
    }

    public void add_score(int scr){
        this.score+=scr;
    }
}
