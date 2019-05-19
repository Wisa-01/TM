using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterMovemnent : MonoBehaviour
{
    //connecter avec le script Chara...
    public CharacterController2D controller;
    public Animator animator;
    //variable de vitesse
    public float runSpeed = 40f;
    //variable de mouvement
    float horizontalMove = 0f;
    //variable de saut
    bool jump = false;
    //variable de crouch
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        // c'est le truc avec un axe ou pour aller a gauche c'est -1 (A) et a droite 1 (D)
        // -1------0------1
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    
        //jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;

        }

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool crounch) {
        animator.SetBool("isCrounching", crounch);
    }
  

    void FixedUpdate() //c'est une fonction pour la physique
    {
        // Move the charachter
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    } 
}