using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [Header("Economy")]
    public long money = 0;
    public int restaurantLevel = 1;

    [Tooltip("Tiền mỗi con vịt bắt được")]
    public int moneyPerDuck = 10;

    [Tooltip("Idle income mỗi giây (tự tăng theo cấp)")]
    public float baseIncomePerSec = 1f;

    [Header("UI")]
    public TMP_Text moneyText;
    public TMP_Text levelText;
    public TMP_Text incomeText;
    public TMP_Text hintText;

    [Header("Upgrade")]
    public long baseUpgradeCost = 50;
    public float upgradeCostGrowth = 1.55f; // tăng giá nâng cấp

    [HideInInspector] public bool isInRestaurantZone = false;

    float incomeTimer;

    void Awake()
    {
        I = this;
    }

    void Start()
    {
        UpdateUI();
        ShowHint("Đi bắt vịt để kiếm tiền!");
    }

    void Update()
    {
        // Idle income theo thời gian
        incomeTimer += Time.deltaTime;
        if (incomeTimer >= 1f)
        {
            incomeTimer = 0f;
            long add = GetIncomePerSecond();
            AddMoney(add);
        }
    }

    public void AddMoney(long amount)
    {
        money += amount;
        UpdateUI();
    }

    public void OnDuckCaught()
    {
        AddMoney(moneyPerDuck);
        ShowHint($"+{moneyPerDuck}$! Bắt thêm hoặc về nhà hàng nâng cấp.");
    }

    public long GetIncomePerSecond()
    {
        // thu nhập tự động tăng theo cấp
        // ví dụ: level 1 = 1/s, level 5 ~ 5/s (có thể chỉnh)
        float income = baseIncomePerSec * restaurantLevel;
        return Mathf.RoundToInt(income);
    }

    public long GetUpgradeCost()
    {
        // cost = base * growth^(level-1)
        double cost = baseUpgradeCost * System.Math.Pow(upgradeCostGrowth, restaurantLevel - 1);
        return (long)System.Math.Round(cost);
    }

    public void TryUpgrade()
    {
        if (!isInRestaurantZone)
        {
            ShowHint("Bạn phải đứng trong khu nhà hàng mới nâng cấp được!");
            return;
        }

        long cost = GetUpgradeCost();
        if (money < cost)
        {
            ShowHint($"Chưa đủ tiền! Cần {cost}$ để nâng cấp.");
            return;
        }

        money -= cost;
        restaurantLevel += 1;

        ShowHint($"Nâng cấp thành công! Nhà hàng cấp {restaurantLevel}.");
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (moneyText) moneyText.text = $"Tiền: {money}$";
        if (levelText) levelText.text = $"Nhà hàng: Cấp {restaurantLevel}";
        if (incomeText) incomeText.text = $"Thu nhập: {GetIncomePerSecond()}$/giây | Nâng cấp: {GetUpgradeCost()}$";
    }

    public void ShowHint(string msg)
    {
        if (hintText) hintText.text = msg;
    }

    public void ResetAll()
    {
        money = 0;
        restaurantLevel = 1;
        UpdateUI();
        ShowHint("Đã reset!");
    }
}
