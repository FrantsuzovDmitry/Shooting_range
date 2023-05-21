using UnityEngine;

public class SimpleWall : MonoBehaviour
{
    //Этот класс служит ограничителем, чтобы пули, улетевшие за пределы экрана, удалялись
    //protected void DestroyTheObject(GameObject obj) => Destroy(obj);

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
