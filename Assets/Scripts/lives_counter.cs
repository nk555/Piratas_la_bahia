using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lives_counter : MonoBehaviour
{
    public int lives = 3;
    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite=sprites[lives];
        if(this.lives<=0){
            //make a you lost popout with a button to replay or go back to main_menu
            //add the file to save resources in particular add points or special coins for shop
            SceneManager.LoadScene("main_menu_scene");
        }
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
