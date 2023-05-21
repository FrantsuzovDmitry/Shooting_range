using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float shotForce;                 //����� ��������� ������
    [SerializeField] protected float forceDecrease;
    [SerializeField] protected float speedMultiplier;           //������������ ��� ������������� �������� ������ ���� (�� ������ �� ���������)
    [SerializeField] protected Rigidbody2D bullet;
    [SerializeField] protected Vector2 directionOfTargetMove;   //����� ��������� ������

    public float ShotForce { get => shotForce; private set => shotForce=value; }

    public Vector2 DirectionOfTargetMove { get => directionOfTargetMove;}

    protected void Start() => bullet.velocity = transform.right * ShotForce * speedMultiplier;  //������� �������� ����

    protected void FixedUpdate() => ShotForce -= forceDecrease;  //� ������ ������ ������� ���� ������� ���� ����� �����������
    
    protected void FixHit(Collider2D collision)
    {
        if (collision.TryGetComponent(out IWeaponVisitor weaponVisitor))    //���� ������ � ������, ����������� ���������
            Accept(weaponVisitor);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        FixHit(collision);
    }

    abstract protected void Accept(IWeaponVisitor visitor);
}
