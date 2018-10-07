using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerButtons : Editor
{

    public override void OnInspectorGUI()
    {

        GameManager gm = (GameManager)target;

        if (GUILayout.Button("Next Player"))
        {
        }

        DrawDefaultInspector();
    }
} // end GameManagerButtons class
#endif

[Serializable]
public enum GameStates
{
    Main
} //end GameStates
public delegate void OnStateChangeHandler();

public class GameManager : MonoSingleton<GameManager>
{
    public event OnStateChangeHandler OnStateChange;

    public int BlocksDestroyed_P1;
    public int BlocksDestroyed_P2;

    public GameStates GameState { get; private set; }

    //private List<GameObject> BlocksInPlayIndex = new List<GameObject>();
    //public int CurrentBlockIndexPos;
    //public int BlocksInPlay;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

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

    private void BlockDestroyed (bool player1)
    {
        if (player1 == false) {
            BlocksDestroyed_P2++;
            print(BlocksDestroyed_P2);
        } else {
            //BlocksDestroyed_P1++;
            print(BlocksDestroyed_P1);
        }
    } //end BlockDestroyed

}  //end GameManager
