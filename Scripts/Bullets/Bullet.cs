using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float shotForce;                 //Имеет публичный геттер
    [SerializeField] protected float forceDecrease;
    [SerializeField] protected float speedMultiplier;           //Используется для корректировки скорости полета пули (не влияет на убойность)
    [SerializeField] protected Rigidbody2D bullet;
    [SerializeField] protected Vector2 directionOfTargetMove;   //Имеет публичный геттер

    public float ShotForce { get => shotForce; private set => shotForce=value; }

    public Vector2 DirectionOfTargetMove { get => directionOfTargetMove;}

    protected void Start() => bullet.velocity = transform.right * ShotForce * speedMultiplier;  //Задание скорости пули

    protected void FixedUpdate() => ShotForce -= forceDecrease;  //С каждым тактом убойная сила летящей пули будет уменьшаться
    
    protected void FixHit(Collider2D collision)
    {
        if (collision.TryGetComponent(out IWeaponVisitor weaponVisitor))    //Если попали в объект, фиксирующий попадания
            Accept(weaponVisitor);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        FixHit(collision);
    }

    abstract protected void Accept(IWeaponVisitor visitor);
}
