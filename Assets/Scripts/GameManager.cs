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
    protected GameManager() { }
    public event OnStateChangeHandler OnStateChange;

    public float BlocksInWall_P1;
    private int BlocksDestroyed_P1;
    private float BlocksRemaining_P1;
    private float WallHealth_P1;

    public float BlocksInWall_P2;
    private int BlocksDestroyed_P2;
    private float BlocksRemaining_P2;
    private float WallHealth_P2;

    public float CrestsOnWall_P1;
    private int CrestsDestroyed_P1;
    private float CrestsRemaining_P1;
    private float CrestHealth_P1;

    public float CrestsOnWall_P2;
    private int CrestsDestroyed_P2;
    private float CrestsRemaining_P2;
    private float CrestHealth_P2;

    public bool timerZero;
    private bool winnerIsPlayer1;
    public bool winnerSet;


    public GameObject player1;
    public GameObject player2;
    Player1Controller player1Control;
    Player2Controller player2Control;

    public GameObject resultMenu;
    public Text resultText;

    private GameObject sceneManager;

    public GameStates GameState { get; private set; }

    // Use this for initialization
    void Start () {
        timerZero = false;
        winnerSet = false;
        resultMenu.SetActive(false);

        player1Control = player1.GetComponent<Player1Controller>();
        player2Control = player2.GetComponent<Player2Controller>();

        sceneManager = GameObject.Find("SceneManager");
        print("GM_START");
    }
	
	// Update is called once per frame
	void Update () {
        if (timerZero && !winnerSet)
        {
            AssessWallDamage();
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
        print("StateChange " + OnStateChange);
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
        }
        else
        {
            CrestsDestroyed_P1++;
        }
    } //end BlockDestroyed

    public void DeclareWinner()
    {
        print("Player 1 - Total Blocks: " + BlocksInWall_P1 + ", Remaining: " + BlocksRemaining_P1 + ", Health: " + WallHealth_P1 +"%");
        print("Player 1 - Total Crests: " + CrestsOnWall_P1 + ", Remaining: " + CrestsRemaining_P1 + ", Health: " + CrestHealth_P1 + "%");

        print("Player 2 - Total Blocks: " + BlocksInWall_P2 + ", Remaining: " + BlocksRemaining_P2 + ", Health: " + WallHealth_P2 + "%");
        print("Player 2 - Total Crests: " + CrestsOnWall_P2 + ", Remaining: " + CrestsRemaining_P2 + ", Health: " + CrestHealth_P2 + "%");

        if (WallHealth_P1 == WallHealth_P2)
        {
            if (CrestHealth_P1 == CrestHealth_P2)
            {
                print("** TIE! **");

                // We will need to either:
                // A) Declare an official tie through UI (both knights play defeat animation)
                // B) Reset the Players and the Ball to start positions and relaunch ball for a tiebreaker. 

                //winnerSet = true;
                print(winnerIsPlayer1); //returns false - 'Defaults to P2 Win'
            }
            else if (CrestHealth_P1 > CrestHealth_P2)
            {
                winnerIsPlayer1 = true;
                //SetEndPoses();
            }
            else
            {
                winnerIsPlayer1 = false;
                //SetEndPoses();
            } //end else

            print("TIE BREAKER");
        }
        else if (WallHealth_P1 > WallHealth_P2)
        {
            winnerIsPlayer1 = true;
            //SetEndPoses();

            print("** PLAYER 1 WINS! **");
        }
        else
        {
            winnerIsPlayer1 = false;
            //SetEndPoses();

            print("** PLAYER 2 WINS! **");
        } //end else
    } //CompareBlocksDestroyed

    public void AssessWallDamage() {

        BlocksRemaining_P1 = BlocksInWall_P1 - BlocksDestroyed_P1;
        BlocksRemaining_P2 = BlocksInWall_P2 - BlocksDestroyed_P2;

        CrestsRemaining_P1 = CrestsOnWall_P1 - CrestsDestroyed_P1;
        CrestsRemaining_P2 = CrestsOnWall_P2 - CrestsDestroyed_P2;

        WallHealth_P1 = BlocksRemaining_P1 / BlocksInWall_P1;
        WallHealth_P2 = BlocksRemaining_P2 / BlocksInWall_P2;

        CrestHealth_P1 = CrestsRemaining_P1 / CrestsOnWall_P1;
        CrestHealth_P2 = CrestsRemaining_P2 / CrestsOnWall_P2;

        //return float;
    } //end AssessWallDamage

    private void SetEndMenu() {
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

            print(winner);
        }
        else {
            resultMenu.SetActive(false);

            print("EndBattle() else fired");
        }
    } //end EndBattle

    private void SetEndPoses()
    {
        player1Control.DoEndPose(winnerIsPlayer1);
        player2Control.DoEndPose(winnerIsPlayer1);
    } //end SetEndPoses

}  //end GameManager
