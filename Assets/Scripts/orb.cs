using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : MonoBehaviour
{
    private string orb_type;
    public Sprite[] sprites;
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
            "bomb", 3
        }
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set_orb_type(string orb_type){
        this.orb_type=orb_type;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[sprite_dict[orb_type]];
    }

    public string get_type(){
        return this.orb_type;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        monito moni=player.gameObject.GetComponent<monito>();
        moni.add_orb(this.orb_type);
        Destroy(this.gameObject);
    }


}
