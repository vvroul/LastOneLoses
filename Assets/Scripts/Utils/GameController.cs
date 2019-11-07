using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Utils
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] Coins = new GameObject[20];
        public Text ItemsLeftText;
        public Text PlayerTurn;
        public Text CongratsText;
        public Button RestartButton;
        public Button QuitGameButton;

        private bool _turn = true;
        private bool turn_flag = false;
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
            PlayerTurn.text = _turn ? "Player's 1 turn" : "Player's 2 turn";
        }

        public void Remove3()
        {
            ManageCoins(3);
            CheckForWinner();
            if (turn_flag)
                ChangeTurn();
        }

        public void Remove2()
        {
            ManageCoins(2);
            CheckForWinner();
            if (turn_flag)
                ChangeTurn();
        }

        public void Remove1()
        {
            ManageCoins(1);
            CheckForWinner();
            if (turn_flag)
                ChangeTurn();
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

            turn_flag = true;
        }

        private void CheckForWinner()
        {
            if (_coinsLeftActive == 0)
            {
                CongratsText.gameObject.SetActive(true);
                if (_turn)
                    CongratsText.text += "2";
                else
                    CongratsText.text += "1";

                RestartButton.gameObject.SetActive(true);
                QuitGameButton.gameObject.SetActive(true);
            }
        }

        private void ChangeTurn()
        {
            _turn = !_turn;
        }
    }
}
