using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class lives_counter : MonoBehaviour
{
    public int lives = 3;
    public Sprite[] sprites;
    public score_object score_obj;
    private string money_file="money_file";
    [SerializeField] private int money = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(System.IO.Path.Combine(Application.persistentDataPath, money_file))){
            using FileStream fileStream = File.Open(System.IO.Path.Combine(Application.persistentDataPath, money_file), FileMode.Open); 
            using BinaryReader binaryReader = new BinaryReader(fileStream); 
            money = binaryReader.ReadInt32(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite=sprites[lives];
        if(this.lives<=0){
            //make a you lost popout with a button to replay or go back to main_menu
            //add the file to save resources in particular add points or special coins for shop
            int score=score_obj.get_score();

            using FileStream fileStream = File.Open(System.IO.Path.Combine(Application.persistentDataPath, money_file), FileMode.Create);
            using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            money+=score;
            binaryWriter.Write(money);
            
            SceneManager.LoadScene("Assets/Scenes/main_menu.unity");
        }
    }

    public void gomain(){
        int score=score_obj.get_score();

        using FileStream fileStream = File.Open(System.IO.Path.Combine(Application.persistentDataPath, money_file), FileMode.Create);
        using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
        money+=score;
        binaryWriter.Write(money);
            
        SceneManager.LoadScene("Assets/Scenes/main_menu.unity");
    }

    public void add_lives(int life){
        this.lives+=life;
        if (this.lives>=3){
            this.lives=3;
        }
        if(this.lives<=0){
            this.lives=0;
        }
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[this.lives];
    }

}
