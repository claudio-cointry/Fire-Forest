using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHero_Script : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public Animator birdAnimator;
    public MainScript mainScript;
    public float birdJumpSpeed = 1;
    public float birdFastfallSpeed = 1F;
    public float FastfallDuration = 0.5F;
    private float FastfallTimer = 0;
    public float dashVelocity = 3;
    public float DashDuration = 0.5F;
    private float DashActiveTimer = 0;
    private float DashCooldown = 2;
    private float DashCooldownTimer = 0;
    private float InicialGravity;
    public float AirVelocity = 1;
    public float AirDuration = 0.5F;
    private float AirActiveTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        birdAnimator = this.GetComponent<Animator>();
        InicialGravity = birdRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & DashActiveTimer <= 0){
            birdRigidbody.velocity = Vector2.up * birdJumpSpeed;
            if (birdAnimator.GetBool("OnJump")){
                birdAnimator.Play("Jump" ,0, 0);
            }
            birdAnimator.SetBool("OnFastfall", false);
            birdAnimator.SetBool("OnDash", false);
            DashActiveTimer = 0;
            AirActiveTimer = 0;
        }

        if (birdRigidbody.velocity.y > 0){
            birdAnimator.SetBool("OnJump",true);
        } else if (birdRigidbody.velocity.y < -5){
            birdAnimator.SetBool("OnJump",false);
        }

        if (Input.GetKeyDown(KeyCode.S) & DashActiveTimer <= 0){
            if (birdRigidbody.velocity.y > 0) {
                birdRigidbody.velocity = Vector2.down * birdFastfallSpeed;
            } else {
                birdRigidbody.velocity = new Vector2(0,birdRigidbody.velocity.y - birdFastfallSpeed * 0.5F);
            }
            if (birdAnimator.GetBool("OnFastfall")){
                birdAnimator.Play("FastFall" ,0, 0);
            }
            FastfallTimer = 0;
            AirActiveTimer = 0;
            birdAnimator.SetBool("OnFastfall", true);
            birdAnimator.SetBool("OnJump",false);
            birdAnimator.SetBool("OnDash", false);         
        }

        if (FastfallTimer < FastfallDuration && birdAnimator.GetBool("OnFastfall")){
            FastfallTimer += Time.deltaTime;
        }
        
        if (FastfallTimer >= FastfallDuration && birdAnimator.GetBool("OnFastfall")){
            birdRigidbody.velocity = Vector2.down * birdFastfallSpeed * 0.5F;   
            birdAnimator.SetBool("OnFastfall", false);
        }

        if (Input.GetKeyDown(KeyCode.D) && DashCooldownTimer <= 0){
            DashActiveTimer = DashDuration;
            DashCooldownTimer = DashCooldown;
            AirActiveTimer = 0;
            birdAnimator.SetBool("OnDash", true);
            birdAnimator.SetBool("OnFastfall", false);
            birdAnimator.SetBool("OnJump", false);
        }

        if (DashActiveTimer > 0){
            mainScript.Scene_velocity = dashVelocity;
            DashActiveTimer -= Time.deltaTime;
            birdRigidbody.gravityScale = 0;
            birdRigidbody.velocity = Vector2.zero;
        }
        
        
        if (DashCooldownTimer > 0){
            DashCooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.A) && DashActiveTimer <= 0){
            AirActiveTimer = AirDuration;
            DashActiveTimer = 0;
            birdAnimator.SetBool("OnAir", true);
            birdAnimator.SetBool("OnDash", false);
            birdAnimator.SetBool("OnFastfall", false);
            birdAnimator.SetBool("OnJump", false);
        }

        if (AirActiveTimer > 0){
            mainScript.Scene_velocity = AirVelocity;
            AirActiveTimer -= Time.deltaTime;
            birdRigidbody.gravityScale = 0;
            birdRigidbody.velocity = Vector2.zero;
        }

        if (AirActiveTimer <=0 && DashActiveTimer <= 0){
            mainScript.Scene_velocity = mainScript.Scene_InicialVelocity;
            birdRigidbody.gravityScale = InicialGravity;
            birdAnimator.SetBool("OnDash", false);
            birdAnimator.SetBool("OnAir", false);
        }
        
    }
}