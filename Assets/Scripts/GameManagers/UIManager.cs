using TMPro;
using UnityEngine;
using EasyUI.Toast;


public class UIManager : MonoBehaviour
{
    [SerializeField] ShowDetails _showDetails;
    [SerializeField] GameMenu _gameMenu;
    [SerializeField] AoeBtn _aodeBtn;
    [SerializeField] UpgradeUnitsBtn _upgradeUnitsBtn;
    [SerializeField] SpawnUnitsBtn _spawnUnitsBtn;
    [SerializeField] UpgradeTooltip _upgradeTooltip;
    [SerializeField] FloatingGetGold _floatingGetGold;
    
    public ShowDetails ShowDetails => _showDetails;
    public GameMenu GameMenu => _gameMenu;
    public AoeBtn AoeBtn => _aodeBtn;
    public UpgradeUnitsBtn UpgradeUnitsBtn => _upgradeUnitsBtn;
    public SpawnUnitsBtn SpawnUnitsBtn => _spawnUnitsBtn;
    public UpgradeTooltip UpgradeTooltip => _upgradeTooltip;
    public FloatingGetGold FloatingGetGold => _floatingGetGold;
    
    public bool isButtonLocked = false;
    public bool isMeteoLocked = false;
    public bool isSnowLocked = false;
    public bool isBomBLocked = false;

    [Header("Info")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI monsterCountText;
    public TextMeshProUGUI curGold;

    [Header("Panel")]
    public GameObject gameWin;
    public GameObject gameLost;

    private void Update()
    {
        UpdateUI();
        _showDetails.MonsterDetails();
        _showDetails.BossDetails();
        _upgradeTooltip.TooltipUpdate();
    }

    private void UpdateUI()
    {
        timerText.text = (GameWorld.Instance.remainTime < 10 ? GameWorld.Instance.remainTime.ToString("F1") : GameWorld.Instance.remainTime.ToString("F0"));
        roundText.text = $"{GameWorld.Instance.curRound.ToString()}/{GameWorld.Instance.totalRounds.ToString()}";
        monsterCountText.text = "" + GameWorld.Instance.MonsterManager.allMonsterList.Count;
        curGold.text = "" + GameWorld.Instance.playerGolds.ToString();
    }

    public void GameState(bool isState)
    {
        gameWin.SetActive(isState);
        gameLost.SetActive(!isState);
    }

    public void Alert(int cost, int playerGold)
    {
        int neededGold = cost - playerGold;
        Toast.Show($"Not Enough Gold. <size=25> \n{neededGold} Needed gold : </size>", 2f, ToastColor.Black, ToastPosition.MiddleCenter);
    }

    // 치팅
    public void addGold()
    {
        GameWorld.Instance.AddGold(100);
    }
}
