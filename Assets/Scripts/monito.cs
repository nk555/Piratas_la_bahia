using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monito : MonoBehaviour
{
    private List<string> orbs= new List<string>();
    private Vector3 speed= new Vector3(3,1.5f,0);
    private float cooldown_time = 0.1f;
    private float cooldown=0f;
    private Vector3 pull_end;
    private Vector3 pull_start;
    private float angle=0;
    private Vector3 original_direction=new Vector3(0,1,0);
    private Vector3 direction = new Vector3(0,1,0);
    private bool pull=false;
    public tile_controller controller;


    // Start is called before the first frame update
    void Start()
    {
        string new_orb="green";
        this.orbs.Add(new_orb);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown+=Time.deltaTime;
        this.movement();
    }

    public List<string> get_orbs(){
        return this.orbs;
    }

    public void remove_orbs(string ob){
        this.orbs.Remove(ob);
    }
    public void add_orb(string ob){
        this.orbs.Add(ob);
    }

    private void movement(){
        detect_pull();
        release_move();
    }
    void detect_pull(){
        if (pull== false){
            if (Input.touchCount > 0){
                if (Input.touches[0].phase==TouchPhase.Began){
                    this.pull_start=Input.touches[0].position;
                    this.pull=true;
                }
            }    
        }
    }

    void release_move(){
        if (Input.touchCount > 0){
            if(Input.touches[0].phase==TouchPhase.Ended){
                this.pull=false;
                this.pull_end=Input.touches[0].position;
                if (this.cooldown>this.cooldown_time){
                    this.cooldown=0;
                    Vector3 move=this.pull_end-this.pull_start;
                    this.angle=Vector2.SignedAngle(this.original_direction, move);
                    this.angle= 90*Mathf.Round(this.angle/90); //set to 180,90,0,-90
                    this.direction = Quaternion.Euler(0,0,this.angle)*this.original_direction;
                    this.gameObject.transform.rotation= Quaternion.Euler(0,0,this.angle);
                    Vector3 new_pos = this.gameObject.transform.position+Vector3.Scale(this.direction, this.speed);
                    if(this.controller.valid_pos(new_pos)){
                        this.gameObject.transform.position=new_pos;
                    }
                }
            }
        }
    }
}
