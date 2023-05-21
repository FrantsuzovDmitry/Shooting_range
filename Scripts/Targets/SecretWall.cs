using UnityEngine;
using UnityEngine.UI;

public class SecretWall : SimpleWall, IWeaponVisitor
{
    [SerializeField] private bool isKidsMode;
    [SerializeField] private Text field;        //Поле для вывода сообщений на экран
    private bool[] achievement = new bool[3];

    public void Visit(PistolBullet bullet, GameObject obj)
    {
        if (isKidsMode) return;

        if (achievement[0])
            ShowLabel("Да-да, вы снова попали в секретную стену из пистолета...");
        else
        {
            ShowLabel("Поздравляем, вы попали в секретную стену из пистолета!");
            achievement[0] = true;
            TryTurnONFanfare();
        }
    }

    public void Visit(ShotgunBullet bullet, GameObject obj)
    {
        if (isKidsMode) return;

        if (achievement[1])
            ShowLabel("Да-да, вы снова попали в секретную стену из ружья...");
        else
        {
            ShowLabel("Поздравляем, вы попали в секретную стену из ружья!");
            achievement[1] = true;
            TryTurnONFanfare();
        }
    }

    public void Visit(RocketBullet bullet, GameObject obj)
    {
        if (isKidsMode) return;

        if (achievement[2])
            ShowLabel("Да-да, вы снова попали в секретную стену из ракетницы...");
        else
        {
            ShowLabel("Поздравляем, вы попали в секретную стену из ракетницы!");
            achievement[2] = true;
            TryTurnONFanfare();
        }
    }

    private void TryTurnONFanfare()
    {
        if (achievement[0] && achievement[1] && achievement[2])
            ShowLabel("Поздравляем, вы расстреляли стену со всех видов оружия");
    }

    private void ShowLabel(string str)
    {
        field.text = str;
        Invoke("ClearLabel", 3f);       //Вызывает функцию очистки поля через 3 секунды
    }

    private void ClearLabel() => field.text = "";
}
