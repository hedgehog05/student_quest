using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    Start,
    PlayerTurn,
    EnemyTurn,
    FinishedTurn,
    Won,
    Lost
}

public class TurnHandle : MonoBehaviour
{
    public BattleState state;
    public EnemyProfile[] EnemiesInBattle;
    private bool enemyActed;
    private GameObject[] EnemyAtks;
    public GameObject PlayerUi;
    public PlayerCtrl Player;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.Start;
        enemyActed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == BattleState.Start)
		{
            PlayerUi.SetActive(true);
            state = BattleState.PlayerTurn;
		}

        else if (state == BattleState.PlayerTurn)
		{

		}

        else if (state == BattleState.EnemyTurn)
		{
            if (EnemiesInBattle.Length <= 0)
			{
                EnemyFinishedTurn();
			}

            else
			{
                if (!enemyActed)
				{
                    Player.gameObject.SetActive(true);
                    Player.SetPlayer();

                    foreach (EnemyProfile e in EnemiesInBattle)
					{
                        int AtkNumb = Random.Range(0, e.EnemiesAttacks.Length);
                        Instantiate(e.EnemiesAttacks[AtkNumb], Vector3.zero, Quaternion.identity);
					}

                    EnemyAtks = GameObject.FindGameObjectsWithTag("Enemy");
                    enemyActed = true;
				}

				else
				{
                    bool enemyfin = true;
                    foreach (GameObject e in EnemyAtks)
					{
                        if (!e.GetComponent<EnemyTurnHandle>().FinishedTurn)
						{
                            enemyfin = false;
						}
					}

                    if (enemyfin)
					{
                        EnemyFinishedTurn();
					}
				}
			}
		}

        else if (state == BattleState.FinishedTurn)
		{
            Player.gameObject.SetActive(false);

            if (Player.GetComponent<PlayerHealth>().HP < 0)
			{
                state = BattleState.Lost;
			}

            else
			{
                state = BattleState.Start;
			}
		}

        else if (state == BattleState.Won)
		{
            //чето сюда
		}
    }

    public void PlayerAct()
	{
        playerfinishTurn();
	}

    void playerfinishTurn()
	{
        //PlayerUi.SetActive(false);
        state = BattleState.EnemyTurn;
	}

    void EnemyFinishedTurn()
	{
        foreach (GameObject obj in EnemyAtks)
		{
            Destroy(obj);
		}

        enemyActed = false;
        state = BattleState.FinishedTurn;
	}
}
