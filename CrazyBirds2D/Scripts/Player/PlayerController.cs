using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum OperatingSystem {PcOrMac = 0, IOS = 1, Android = 2 }
    public OperatingSystem operatingSystem = OperatingSystem.PcOrMac; 
    [SerializeField] private float Health;
    [SerializeField] public float JumpHeight = 3;
    [SerializeField] private Transform CamMove;
    [SerializeField] private Animator Anim;

    private PlayerSatsBehaviour _shop;
    public Rigidbody2D rb;

    void Awake()
    {
        if(_shop == null)
        {
            _shop = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
        }
        if(_shop.SpeedLevel == 1)
        {
            JumpHeight = 3;
        }
        if(_shop.SpeedLevel > 26)
        {
            JumpHeight += _shop.SpeedLevel;
        }
    }


    void FixedUpdate()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        if(operatingSystem == OperatingSystem.PcOrMac)
        {
            if (Input.GetButton("Jump"))
            {
                Anim.SetTrigger("SpacePressed");
                rb.velocity = Vector2.up * JumpHeight;
                yield return new WaitForSeconds(Anim.GetCurrentAnimatorStateInfo(0).length);
            }
        }
        if(operatingSystem == OperatingSystem.IOS)
        {
            if(Input.GetMouseButtonUp(0))
            {
                Anim.SetTrigger("SpacePressed");
                rb.velocity = Vector2.up * JumpHeight;
                yield return new WaitForSeconds(Anim.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }
}
