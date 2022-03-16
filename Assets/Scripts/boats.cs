using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boats : MonoBehaviour
{
    private Vector3 direction;
    public Dictionary<string, int> score_dict= new Dictionary<string, int>()
    {
        {"green", 5},
        {"blue", 5},
        {"red", 5}
    };
    public score_object scoring;
    // Start is called before the first frame update
    void Start()
    {
        scoring=GameObject.Find("score").GetComponent<score_object>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_dict(Dictionary<string, int> dict){
        this.score_dict=dict;
    }
    public Dictionary<string,int> get_dict(){
        return this.score_dict;
    }
    private void score(orb collected_orb){
        int scr= score_dict[collected_orb.get_type()];
        this.scoring.add_score(scr);
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        monito moni=player.gameObject.GetComponent<monito>();
        List<string> orbs= new List<string>(moni.get_orbs());
        foreach(string ob in orbs){
            if(score_dict.ContainsKey(ob)){
                scoring.add_score(score_dict[ob]);
                moni.remove_orbs(ob);
            }
        }
    }
}
