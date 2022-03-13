using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boats : MonoBehaviour
{
    private Vector3 direction;
    private Dictionary<string, int> score_dict= new Dictionary<string, int>()
    {
        {"green", 5},
        {"blue", 5},
        {"red", 5}
    };
    private score_object scoring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_dict(Dictionary<string, int> dict){
        this.score_dict=dict;
    }

    private void score(orb collected_orb){
        int scr= score_dict[collected_orb.get_type()];
        this.scoring.add_score(scr);
    }
}
