using UnityEngine;

public class SimpleWall : MonoBehaviour
{
    //���� ����� ������ �������������, ����� ����, ��������� �� ������� ������, ���������
    //protected void DestroyTheObject(GameObject obj) => Destroy(obj);

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
