using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSource : MonoBehaviour
{
    //Statement - Health System Gestion

    public float maxHp;
    public float currentHp;

    //Statement - Moovement System

    public bool isPlayerMoovAvailable;
    public float speed;
    public Vector3 moove;
    public Rigidbody2D playerRgb;
    public float horizontalMoove;       //these variables exist just to check joystick value with a Debug.Log
    public float verticalMoove;         //look upward
    public int direction;

    //Statement - Attack System

    public bool isPlayerAttackAvailable;
    public float attackSpeed;
    public GameObject[] attackDirectionList;
    public int attackDirection;

    //Dash
    public bool isPlayerDashAvailable;
    public float dashSpeed = 3f;
    public float dashTime;
    public float initialDashTime = 1f;
    public float dashCooldown;
    public float initialDashCooldown = 3f;
    public AnimationCurve dashCurve;

    private void Start()
    {
    }
}
