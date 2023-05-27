using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private int startBalance = 1000;
    [Header("References")]
    [SerializeField] private TMP_Text balanceText;

    public static BalanceManager Instance;

    private int _balance;
    public int Balance
    {
        get { return _balance; }
        set
        {
            _balance = value;
            balanceText.text = _balance.ToString();
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Balance = startBalance;
    }
}
