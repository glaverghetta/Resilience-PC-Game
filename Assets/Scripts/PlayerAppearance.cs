using UnityEngine;
using UnityEngine.UI;

/* This class handles of the appearance of the player model, allowing it to be changed by the user in the Change Color scene. */
public class PlayerAppearance : MonoBehaviour
{
    public const float SOCCER_BALL_COLLIDER_RADIUS = 0.11f;
    public const float BASKETBALL_COLLIDER_RADIUS = 1f;

    public enum appearance                              // Enumeration of all possible player appearances in the game
    {
        Rainbow,
        SoccerBall,
        Basketball,
        Cyan,
        Green,
        Yellow,
        Purple,
        Orange,
        Blue
    }

    public static appearance playerAppear = appearance.Rainbow;    // Player's appearance value, defaults to Rainbow

    GameObject player;
    MeshRenderer playerRend;

    public Mesh soccerBall;
    public Material soccerBallMatWhite;
    public Material soccerBallMatBlack;

    public Mesh basketball;
    public Material basketballMatBall;
    public Material basketballMatRings;

    private float currentTimeVal = 0f;          
    private int currentColorNum = 0;
    private const float TIME_BETWEEN_COLORS = 1f;     // controls the speed at which rainbow objects changes colors

    private readonly Color32[] colorSeq = {Color.red,                                 // The sequence of colors used for the rainbow appearance (ROYGBIV)
                                             new Color32(255, 165, 0, 255),
                                             Color.yellow,
                                             Color.green,
                                             Color.blue,
                                             new Color32(75, 0, 130, 255),
                                             new Color32(127, 0, 255, 255) };


    void Start()
    {
        // Find the player object, if it exists, and set its appearance
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRend = player.GetComponent<MeshRenderer>();
            MeshFilter filter = player.GetComponent<MeshFilter>();
            if (playerAppear == appearance.SoccerBall)          // soccer ball appearance
            { 
                filter.mesh = soccerBall;
                Material[] soccerBallMats = new Material[2];
                soccerBallMats[0] = soccerBallMatWhite;
                soccerBallMats[1] = soccerBallMatBlack;
                playerRend.materials = soccerBallMats;
                player.transform.localScale = Vector3.one * 5;
                player.GetComponent<SphereCollider>().radius = SOCCER_BALL_COLLIDER_RADIUS;
            }
            else if(playerAppear == appearance.Basketball)      // basketball appearance
            {
                filter.mesh = basketball;
                Material[] basketballMats = new Material[2];
                basketballMats[0] = basketballMatBall;
                basketballMats[1] = basketballMatRings;
                playerRend.materials = basketballMats;
                player.transform.localScale = Vector3.one * 0.5f;
                player.GetComponent<SphereCollider>().radius = BASKETBALL_COLLIDER_RADIUS;
            }
            else                // solid color
            {
                switch ( (int)playerAppear ) 
                {
                    case 3:
                        playerRend.material.color = Color.cyan;
                        break;
                    case 4:
                        playerRend.material.color = Color.green;
                        break;
                    case 5:
                        playerRend.material.color = Color.yellow;
                        break;
                    case 6:
                        playerRend.material.color = new Color32(128, 0, 128, 255);
                        break;
                    case 7:
                        playerRend.material.color = new Color32(255, 165, 0, 255);
                        break;
                    case 8:
                        playerRend.material.color = Color.blue;
                        break;
                }
            }          
        }
    }

    private void Update()
    {
        // Update currentTimeVal and currentColorNum
        currentTimeVal += Time.deltaTime;
        if (currentTimeVal >= TIME_BETWEEN_COLORS)
        {
            currentColorNum++;
            currentTimeVal = 0;
        }

        if (playerAppear == appearance.Rainbow && player != null)      // apply rainbow effect to player if they selected the rainbow option
        {
            playerRend.material.color = RainbowColor(playerRend.material.color);
        }

        GameObject[] rainbowObjs = GameObject.FindGameObjectsWithTag("Rainbow");

        foreach(GameObject rainbowObj in rainbowObjs)       // apply rainbow effect to all GameObjects with tag Rainbow
        {
            if (rainbowObj.layer == 5)                      // 5 is UI layer
            {
                Image uiImage = rainbowObj.GetComponent<Image>();
                if (uiImage != null)
                {
                    uiImage.color = RainbowColor(uiImage.color);
                }
            }
            else
            {
                MeshRenderer currentRenderer = rainbowObj.GetComponent<MeshRenderer>();
                if (currentRenderer != null)
                {
                    currentRenderer.material.color = RainbowColor(currentRenderer.material.color);
                }
            }
        }
    }

    /* Alters the specified Color based on currentColorNum and currentTimeVal */
    private Color RainbowColor(Color c)
    {
        if (currentColorNum == 7)
        {
            currentColorNum = 0;
            return c;
        }
        if (currentColorNum == 6)
        {
            c = Color.Lerp(colorSeq[currentColorNum], colorSeq[0], currentTimeVal / TIME_BETWEEN_COLORS);
            return c;
        }
        c = Color.Lerp(colorSeq[currentColorNum], colorSeq[currentColorNum + 1], currentTimeVal / TIME_BETWEEN_COLORS);
        return c;

    }

    /* Sets the player's appearance based on the parameter given */
    public void SetAppearance(int value)
    {
        playerAppear = (appearance)value;   // convert int argument to an appearance and set playerAppear to the converted value
    }
}
