using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat_tiles : MonoBehaviour
{
    public boat_spawner spawner;
    public GameObject boat_prefab;
    private GameObject boat;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void create_boat(string type){
        boat = Instantiate(boat_prefab, this.transform.position, this.transform.rotation);
        boat.GetComponent<boats>().set_dict(type);
    }

    public void destroy_boat(){
        Destroy(this.boat);
    }
}
