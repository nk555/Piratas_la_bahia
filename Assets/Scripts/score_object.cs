using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class score_object : MonoBehaviour
{
    [SerializeField] private int score=0;
    public Text score_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.score_text.text="Score: "+score;
    }

    public int get_score(){
        return this.score;
    }

    public void add_score(int scr){
        this.score+=scr;
    }
}
