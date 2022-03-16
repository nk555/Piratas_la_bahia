using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiles : MonoBehaviour
{
    private orb tile_orb= null;
    private bool active = true;
    // Start is called before the first frame update
    private SpriteRenderer renderer;
    void Start()
    {
        this.renderer=this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        this.renderer.enabled=active;
    }

    public void deactivate(){
        this.active=false;
        this.renderer.enabled=false;
    }

    public void activate(){
        this.active=true;
        this.renderer.enabled=true;
    }

    public void set_orb(orb tile_orb){
        this.tile_orb=tile_orb;
    }

    public Vector3 get_pos(){
        return this.gameObject.transform.position;
    }
}
