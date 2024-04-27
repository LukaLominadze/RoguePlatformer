using System.Collections;
using UnityEngine;

public class SkeleHealer : MonoBehaviour, IGlobalEvents
{
    [SerializeField] EventHandler eventHandler;

    [SerializeField] Animator animator;
    [SerializeField] AnimationHandler animHandler;

    [SerializeField] EnemyBasicShoot shootScript;

    [SerializeField] HealthSystem health;

    const string IDLE = "Skeleton_Healer_Idle";
    const string WALK = "Skeleton_Healer_Walk";
    const string ATTACK = "Skeleton_Healer_Attack";
    const string ATTACK_END = "Skeleton_Healer_Attack_End";
    const string HEAL = "Skeleton_Healer_Heal";

    private float maxHealth;
    private float healTime;
    private float endAttackTime;

    private bool healing = false;
    private bool attacking = false;
    private bool onCooldown = false;

    public EventHandler EHandler => eventHandler;

    private void Start()
    {
        maxHealth = health.GetHealth();

        EHandler.SubscribeTo(Events.active, shootScript.Shoot);

        animHandler.CreateClipInfos();
        healTime = animHandler.GetClipTime(HEAL);
        endAttackTime = animHandler.GetClipTime(ATTACK_END);
    }

    public void Ready()
    {
        if (onCooldown)
        {
            StopAllCoroutines();
            attacking = false;
            healing = false;
            onCooldown = false;
        }

        animHandler.ChangeAnimationState(WALK);
    }

    public void Active()
    {
        StopAllCoroutines();

        attacking = true;

        if (healing)
        {
            return;
        }

        if (health.GetHealth() / maxHealth < 0.3f)
        {
            EHandler.UnsubscribeFrom(Events.active, shootScript.Shoot);

            animHandler.ChangeAnimationState(HEAL);

            healing = true;

            // Wait for the healing animation to end
            StartCoroutine(Heal(healTime));

            return;
        }
        else
        {
            animHandler.ChangeAnimationState(ATTACK);
        }
    }

    public void Cooldown()
    {
        if (onCooldown)
        {
            return;
        }
        if (attacking)
        {
            animHandler.ChangeAnimationState(ATTACK_END);

            // Wait for the animation to end
            StartCoroutine(CooldownAnim(endAttackTime));
        }
        else
        {
            animHandler.ChangeAnimationState(IDLE);
        }

    }

    IEnumerator CooldownAnim(float time)
    {
        yield return new WaitForSeconds(time);
        animHandler.ChangeAnimationState(IDLE);
        attacking = false;
    }

    IEnumerator Heal(float time)
    {
        yield return new WaitForSeconds(time);

        EHandler.SubscribeTo(Events.active, shootScript.Shoot);

        animHandler.ChangeAnimationState(ATTACK);
        healing = false;
    }
}
