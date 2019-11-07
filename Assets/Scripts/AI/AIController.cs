using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.AI
{
    public class AIController : MonoBehaviour
    {
        public GameObject[] Coins = new GameObject[20];
        public Text ItemsLeftText;
        public Text PlayerTurn;
        public Text CongratsText;
        public Button RestartButton;
        public Button QuitGameButton;

        private bool _turn = false;
        private int _coinsLeftActive = 20;

        // Start is called before the first frame update
        private void Start()
        {
            Coins = GameObject.FindGameObjectsWithTag("Coin");
        }

        // Update is called once per frame
        private void Update()
        {
            ItemsLeftText.text = "Items Left : " + _coinsLeftActive;
            PlayerTurn.text = _turn ? "Player's turn" : "Computer's turn";

            StartCoroutine(AI_turn(1.0f));
        }

        public void Remove3()
        {
            if (_turn)
            {
                ManageCoins(3);
                CheckForWinner();
                ChangeTurn();
            }
        }

        public void Remove2()
        {
            if (_turn)
            {
                ManageCoins(2);
                CheckForWinner();
                ChangeTurn();
            }
        }

        public void Remove1()
        {
            if (_turn)
            {
                ManageCoins(1);
                CheckForWinner();
                ChangeTurn();
            }
        }

        private void ManageCoins(int removeCount)
        {
            var count = 0;
            if (_coinsLeftActive < removeCount)
                return;
            foreach (var coin in Coins)
            {
                if (coin.gameObject.activeSelf)
                {
                    coin.gameObject.SetActive(false);
                    ++count;
                    --_coinsLeftActive;
                    if (count == removeCount)
                        break;
                }
            }
        }

        private void CheckForWinner()
        {
            if (_coinsLeftActive == 0)
            {
                CongratsText.gameObject.SetActive(true);
                if (_turn)
                    CongratsText.text = "The winner is the Player";
                else
                    CongratsText.text = "The winner is the Computer";

                RestartButton.gameObject.SetActive(true);
                QuitGameButton.gameObject.SetActive(true);
            }
        }

        private void ChangeTurn()
        {
            _turn = !_turn;
        }

        private IEnumerator AI_turn(float waitTime)
        {

            yield return new WaitForSeconds(waitTime);

            if (!_turn)
            {
                var theMod = _coinsLeftActive % 4;
                if (theMod == 0)
                {
                    ManageCoins(3);
                }
                else if (theMod == 1)
                {
                    ManageCoins(1);
                }
                else if (theMod == 2)
                {
                    ManageCoins(1);
                }
                else if (theMod == 3)
                {
                    ManageCoins(2);
                }

                CheckForWinner();
                ChangeTurn();
            }
        }
    }
}
