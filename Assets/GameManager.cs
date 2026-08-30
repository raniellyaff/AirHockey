using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar

    public static void Score (string wallID) 
    {
        if (wallID == "TopWall3") // Se a bola bateu no topo, ponto para o Player 1 (ou vice-versa)
        {
            PlayerScore1++;
        } 
        else if (wallID == "BottomWall3") // Se bateu embaixo, ponto para o Player 2
        {
            PlayerScore2++;
        }
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () 
    {
        if (layout != null)
        {
            GUI.skin = layout;
        }

        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;

            // Busca a bola pelo nome ou tag de forma segura ao reiniciar
            GameObject theBall = GameObject.Find("puck_0");
            if (theBall != null)
            {
                theBall.SendMessage("RestartGame", null, SendMessageOptions.DontRequireReceiver);
            }
        }

        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            GameObject theBall = GameObject.Find("puck_0");
            if (theBall != null)
            {
                theBall.SendMessage("ResetBall", null, SendMessageOptions.DontRequireReceiver);
            }
        } 
        else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            GameObject theBall = GameObject.Find("puck_0");
            if (theBall != null)
            {
                theBall.SendMessage("ResetBall", null, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}