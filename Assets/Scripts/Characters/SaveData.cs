using System;

[Serializable]
public class SaveData
{
    public int coin;
    public int health;
    public int stamina;

    public bool hasSword;
    public bool hasBow;
    public bool hasStaff;

    public string equippedWeapon;

    public string currentScene;
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;

    public int currentWave;
}