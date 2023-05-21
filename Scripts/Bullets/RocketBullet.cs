using UnityEngine;

public class RocketBullet : Bullet
{
    [SerializeField] private float radius;
    [SerializeField] private float explodeForce;

    private void Explode()
    {
        //��������� ����������� � ����� � ������� � ������� ��������� �������
        Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in overlappedColliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //���������� ����� ������� ������ � ��������
                Vector2 direction = collider.transform.position - transform.position;
                //���� ����������� ������� ~ ��������� �� ������
                float forceImpact = explodeForce / (1 + direction.magnitude);  

                rb.AddForce(direction * forceImpact);
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
        FixHit(collision);
    }

    protected override void Accept(IWeaponVisitor visitor) => visitor?.Visit(this, gameObject);
}
