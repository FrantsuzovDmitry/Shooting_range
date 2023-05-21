using UnityEngine;
using UnityEngine.UI;

public class SecretWall : SimpleWall, IWeaponVisitor
{
    [SerializeField] private bool isKidsMode;
    [SerializeField] private Text field;        //���� ��� ������ ��������� �� �����
    private bool[] achievement = new bool[3];

    public void Visit(PistolBullet bullet, GameObject obj)
    {
        if (isKidsMode) return;

        if (achievement[0])
            ShowLabel("��-��, �� ����� ������ � ��������� ����� �� ���������...");
        else
        {
            ShowLabel("�����������, �� ������ � ��������� ����� �� ���������!");
            achievement[0] = true;
            TryTurnONFanfare();
        }
    }

    public void Visit(ShotgunBullet bullet, GameObject obj)
    {
        if (isKidsMode) return;

        if (achievement[1])
            ShowLabel("��-��, �� ����� ������ � ��������� ����� �� �����...");
        else
        {
            ShowLabel("�����������, �� ������ � ��������� ����� �� �����!");
            achievement[1] = true;
            TryTurnONFanfare();
        }
    }

    public void Visit(RocketBullet bullet, GameObject obj)
    {
        if (isKidsMode) return;

        if (achievement[2])
            ShowLabel("��-��, �� ����� ������ � ��������� ����� �� ���������...");
        else
        {
            ShowLabel("�����������, �� ������ � ��������� ����� �� ���������!");
            achievement[2] = true;
            TryTurnONFanfare();
        }
    }

    private void TryTurnONFanfare()
    {
        if (achievement[0] && achievement[1] && achievement[2])
            ShowLabel("�����������, �� ����������� ����� �� ���� ����� ������");
    }

    private void ShowLabel(string str)
    {
        field.text = str;
        Invoke("ClearLabel", 3f);       //�������� ������� ������� ���� ����� 3 �������
    }

    private void ClearLabel() => field.text = "";
}
