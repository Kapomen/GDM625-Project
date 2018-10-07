using System;
using UnityEngine;
using UnityEngine.UI;

//#if UNITY_EDITOR
//using UnityEditor;

//[CustomEditor(typeof(GameManager))]
//public class GameManagerButtons : Editor
//{

//    public override void OnInspectorGUI()
//    {

//        GameManager gm = (GameManager)target;

//        if (GUILayout.Button("Next Player"))
//        {
//        }

//        DrawDefaultInspector();
//    }
//} // end GameManagerButtons class
//#endif

[Serializable]
public enum GameStates
{
    Main
} //end GameStates
public delegate void OnStateChangeHandler();

public class GameManager : MonoSingleton<GameManager>
{
    public event OnStateChangeHandler OnStateChange;

    private int BlocksDestroyed_P1;
    private int BlocksDestroyed_P2;

    private int CrestsDestroyed_P1;
    private int CrestsDestroyed_P2;

    public bool timerZero;
    private bool winnerIsPlayer1;
    private bool winnerSet;

    public Text resultText;

    public GameObject resultMenu;

    private GameObject sceneManager;

    public GameStates GameState { get; private set; }

    // Use this for initialization
    void Start () {
        timerZero = false;
        winnerSet = false;
        resultMenu.SetActive(false);

        sceneManager = GameObject.Find("SceneManager");
    }
	
	// Update is called once per frame
	void Update () {
        if (timerZero && !winnerSet)
        {
            DeclareWinner();
            SetEndMenu();
            winnerSet = true;
        }
	} //end update

    /// <summary>
    /// This function sets the next gamestate and handles the event of changing states via the additive of the delegate.
    /// </summary>
    public void SetGameState(GameStates gameState)
    {
        this.GameState = gameState;
        if (OnStateChange != null)
        {
            OnStateChange();
        }
    } //end SetGameState

    public void BlockDestroyed (bool player1)
    {
        if (player1 == false) {
            BlocksDestroyed_P2++;
        } else {
            BlocksDestroyed_P1++;
        }
    } //end BlockDestroyed

    public void CrestDestroyed(bool player1)
    {
        if (player1 == false)
        {
            CrestsDestroyed_P2++;
            //print("P2 Crests Destroyed: " + BlocksDestroyed_P2);
        }
        else
        {
            CrestsDestroyed_P1++;
            //print("P1 Crests Destroyed: " + BlocksDestroyed_P1);
        }
    } //end BlockDestroyed

    public void DeclareWinner()
    {
        if (BlocksDestroyed_P1 == BlocksDestroyed_P2) {
            if (CrestsDestroyed_P1 == CrestsDestroyed_P2) {
                print("** TIE! **");

                // We will need to either:
                // A) Declare an official tie through UI (both knights play defeat animation)
                // B) Reset the Players and the Ball to start positions and relaunch ball for a tiebreaker. 

                //winnerSet = true;
                print(winnerIsPlayer1); //returns false - 'Defaults to P2 Win'
            } else if (CrestsDestroyed_P1 < CrestsDestroyed_P2) {
                winnerIsPlayer1 = true;
            } else {
                winnerIsPlayer1 = false;
            } //end else
  
            print("TIE BREAKER");
        } else if (BlocksDestroyed_P1 < BlocksDestroyed_P2) {
            winnerIsPlayer1 = true;
            print("** PLAYER 1 WINS! **");
        } else {
            winnerIsPlayer1 = false;
            print("** PLAYER 2 WINS! **");
        } //end else
    } //CompareBlocksDestroyed

    private void SetEndMenu()
    {
        string winner;

        if (winnerIsPlayer1) {
            winner = "Player 1 Wins!";
            resultText.text = winner;
        } else {
            winner = "Player 2 Wins!";
            resultText.text = winner;
        } //end else

        gamepausechecking ifpaused = sceneManager.GetComponent<gamepausechecking>();
        ifpaused.paused = true;

        if (!resultMenu.activeInHierarchy)
        {
            resultMenu.SetActive(true);
            
            ifpaused.pausebutton.SetActive(false);
            ifpaused.resetbutton.SetActive(false);

            // Sicheng - Use the winner string value to set the text for the ResultsText UI

            print(winner);
        }
        else {
            resultMenu.SetActive(false);

            print("EndBattle() else fired");
        }
    } //end EndBattle

}  //end GameManager
