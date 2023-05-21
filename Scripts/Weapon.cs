using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] public Text ammo;

    private Vector3 weaponPosition;
    private bool shootingIsAble;
    private Camera mainCamera;

    public void ShowNumOfAmmo()
    {
        ammo.text = "Патроны:" + numberOfBullets;
    }

    private void Start()
    {
        //Инициализация
        shootingIsAble = true;
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (!shootingIsAble) return;

        //Скрипт для вращения оружия вокруг своей оси
        weaponPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(weaponPosition.y, weaponPosition.x));

        if (Input.GetMouseButton(0))
        {
            Shoot();
            StartCoroutine(ShootingDelayer());
        }
    }

    private void Shoot()
    {
        if (numberOfBullets > 0 && shootingIsAble)
        {
            Instantiate(bulletPrefab, spawnPoint.transform);
            numberOfBullets--;
            ShowNumOfAmmo();
        }
    }

    //Создает задержку между выстрелами для того, чтобы ружье не превратилось в автомат
    IEnumerator ShootingDelayer()
    {
        shootingIsAble = false;
        yield return new WaitForSeconds(1.25f);
        shootingIsAble = true;
    }
}
