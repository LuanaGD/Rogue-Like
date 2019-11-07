using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSource : MonoBehaviour
{
    //Statement - Health System Gestion

    protected static float maxHp;
    protected static float currentHp;

    //Statement - Moovement System

    protected static bool isPlayerMoovAvailable;
    protected static float speed;
    protected static Vector3 moove;
    protected static Rigidbody2D playerRgb;
    protected static int direction;

    //Statement - Attack System

    protected bool isPlayerAttackAvailable;
    protected float attackSpeed;
    protected GameObject[] attackDirectionList;
    protected int attackDirection;

    //Dash
    protected bool isPlayerDashAvailable;
    protected float dashSpeed = 3f;
    protected float dashTime;
    protected float initialDashTime = 1f;
    protected float dashCooldown;
    protected float initialDashCooldown = 3f;
    protected AnimationCurve dashCurve;

    public virtual void Start()
    {
        playerRgb = GetComponent<Rigidbody2D>();
    }
}
