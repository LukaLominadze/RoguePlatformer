using UnityEngine;

public class RollingSkull : MonoBehaviour
{
    [SerializeField] EventHandler EHandler;

    [SerializeField] AnimationHandler animHandler;

    [SerializeField] EnemyVision enemyVision;

    const string ATTACK_END = "Rolling_Skull_Attack_End";

    void Start()
    {
        EHandler = GetComponent<EventHandler>();
        animHandler = GetComponent<AnimationHandler>();
        enemyVision = GetComponent<EnemyVision>();
    }

    public void RotateSkull(float fullRotationInSeconds)
    {
        float deltaRotation = (360 / fullRotationInSeconds) * Time.fixedDeltaTime;

        transform.rotation *= Quaternion.Euler(0, 0, -transform.localScale.x * deltaRotation);
    }

    public void ChaseAnimationEnd()
    {
        if (!enemyVision.DetectPlayer())
        {
            animHandler.ChangeAnimationState(ATTACK_END);
            EHandler.SetEvent(Events.cooldown);
        }
    }
}
