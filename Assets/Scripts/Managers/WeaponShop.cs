using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [SerializeField] private int bowPrice = 20;
    [SerializeField] private int staffPrice = 30;

    public bool BuyBow()
    {
        if (GameDataManager.Instance.hasBow)
        {
            Debug.Log("Bow already unlocked.");
            return false;
        }

        if (GameDataManager.Instance.coin < bowPrice)
        {
            Debug.Log("Not enough coin for Bow.");
            return false;
        }

        GameDataManager.Instance.coin -= bowPrice;
        GameDataManager.Instance.hasBow = true;

        Debug.Log("Bow purchased!");
        return true;
    }

    public bool BuyStaff()
    {
        if (GameDataManager.Instance.hasStaff)
        {
            Debug.Log("Staff already unlocked.");
            return false;
        }

        if (GameDataManager.Instance.coin < staffPrice)
        {
            Debug.Log("Not enough coin for Staff.");
            return false;
        }

        GameDataManager.Instance.coin -= staffPrice;
        GameDataManager.Instance.hasStaff = true;

        Debug.Log("Staff purchased!");
        return true;
    }

    public void EquipSword()
    {
        if (GameDataManager.Instance.hasSword)
        {
            GameDataManager.Instance.equippedWeapon = "Sword";
        }
    }

    public void EquipBow()
    {
        if (GameDataManager.Instance.hasBow)
        {
            GameDataManager.Instance.equippedWeapon = "Bow";
        }
    }

    public void EquipStaff()
    {
        if (GameDataManager.Instance.hasStaff)
        {
            GameDataManager.Instance.equippedWeapon = "Staff";
        }
    }
}