/* Author : Mehmet Bedirhan U?ak*/
using UnityEngine;
using NaughtyAttributes;

public class HitDetection : MonoBehaviour
{
    private CollectManager _collectManager;
    private GameManager _gameManager;
    private PlayerManager _playerManager;
    [BoxGroup("Player Options")]
    public PlayerMovementController playerMovementController;
    [BoxGroup("Player GameObject")]
    public GameObject Player;

    [BoxGroup("Player Value Options")]
    public int PlayerDamageCount = 1;
    [BoxGroup("Player Value Options")]
    public int CollectedCoinCount = 1;

    [BoxGroup("Player Value Options")]
    public int CollectedCrystalCount = 1;

    [Header("Character Controller Required")]
    [BoxGroup("Player Jump Value Options")]
    public float JumpForce;
    [BoxGroup("Player Value Options")]
    public float JumpHeight;


    private void Awake()
    {
        _collectManager = CollectManager.Instance;
        _gameManager = GameManager.Instance;
        _playerManager = PlayerManager.Instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            Vibration.VibratePop();
            if (other.GetComponent<DeadOnHit>())
            {
                _playerManager.AddDamage(_playerManager.PlayerMaxDeadCount);
                _collectManager.ObstacleObjects.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
            else{
                _playerManager.AddDamage(PlayerDamageCount);
                _collectManager.ObstacleObjects.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
           
        }

        if (other.tag == "Collectable")
        {
            if (other.GetComponent<CrystalMode>())
            {
                _collectManager.AddCrystal(CollectedCrystalCount);
                _collectManager.CollectedObjects.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
            else
            {
                _collectManager.AddCoin(CollectedCoinCount);
                _collectManager.CollectedObjects.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }

            if (other.GetComponent<TimeMode>())
            {
                if (other.GetComponent<TimeMode>().isIncrease)
                {
                    _gameManager.UpdateGameTimeState(TimeState.AddTime, other.GetComponent<TimeMode>().IncreaseTimeAmount);
                    _collectManager.CollectedObjects.Add(other.gameObject);
                    other.gameObject.SetActive(false);
                }
                else
                {
                    _gameManager.UpdateGameTimeState(TimeState.DecreaseTime, other.GetComponent<TimeMode>().DecreaseTimeAmount);
                    _collectManager.CollectedObjects.Add(other.gameObject);
                    other.gameObject.SetActive(false);
                }
            }
        }

        if (other.tag == "Finish")
        {
            _gameManager.UpdateGameState(GameState.WinGame);
        }
    }
}
