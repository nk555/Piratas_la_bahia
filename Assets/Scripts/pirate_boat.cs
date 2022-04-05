using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirate_boat : boats
{
    // Start is called before the first frame update
    public Dictionary<string, Dictionary<string, int>> score_dicts = new Dictionary<string, Dictionary<string, int>>()
    {
        {
            "green", new Dictionary<string, int>{
                {"green", 10}
            }
        },
        {
            "red", new Dictionary<string, int>{
                {"red", 10}
            }
        },
        {
            "blue", new Dictionary<string, int>{
                {"blue", 10}
            }
        },
        {
            "rainbow", new Dictionary<string, int>{
                {"green", 5},
                {"red", 5},
                {"blue", 5}
            }
        },
        {
            "pirate", new Dictionary<string, int>{
                {"bomb", 50}
            }
        }
    };
    public Dictionary<string,int> sprite_dict = new Dictionary<string, int>()
    {
        {
            "green", 0
        },
        {
            "red", 1
        },
        {
            "blue", 2
        },
        {
            "rainbow", 3
        },
        {
            "pirate", 4
        }
    };
    public float bomb_cooldown = 9f;
    private float bomb_timer = 0f;
    private lives_counter live_counter;
    public Dictionary<string, int> score_dict= new Dictionary<string, int>();
    void Start()
    {
        live_counter=GameObject.Find("lives").GetComponent<lives_counter>();
        scoring=GameObject.Find("score").GetComponent<score_object>();
    }

    // Update is called once per frame
    void Update()
    {
        bomb_timer+=Time.deltaTime;
        if(bomb_timer>=bomb_cooldown){
            live_counter.add_lives(-1);
            bomb_timer=-100f;
        }
    }

    public void set_dict(string type){
        this.score_dict=this.score_dicts[type];
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[sprite_dict[type]];
    }
    public Dictionary<string,int> get_dict(){
        return this.score_dict;
    }
    private void score(orb collected_orb){
        int scr= score_dict[collected_orb.get_type()];
        this.scoring.add_score(scr);
    }

    void explode(){
        //this.gameObject.GetComponent<Sprite_Renderer>() ;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        monito moni=player.gameObject.GetComponent<monito>();
        List<string> orbs= new List<string>(moni.get_orbs());
        foreach(string ob in orbs){
            if(score_dict.ContainsKey(ob)){
                scoring.add_score(score_dict[ob]);
                moni.remove_one(ob);
                this.explode();
            }
        }
    }
}
