using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/* This class handles of the appearance of the player model, allowing it to be changed by the user in the Change Color scene. */
public class ChangeColor : MonoBehaviour
{
    GameObject player;
    MeshRenderer rend;
    public const float SOCCER_BALL_COLLIDER_RADIUS = 0.11f;
    public const float BASKETBALL_COLLIDER_RADIUS = 1f;

    public Mesh soccerBall;
    public Material soccerBallMatWhite;
    public Material soccerBallMatBlack;

    public Mesh basketball;
    public Material basketballMatBall;
    public Material basketballMatRings;

    public static Color c = Color.cyan;         // The color chosen by the player in the Change Color scene
    public static bool isBasketball = false;    // set to true if the player chose Basketball
    public static bool isSoccerBall = false;    // set to true if the player chose Soccer Ball

    public static bool isRainbow = false;                // set to true if player chose Rainbow
    private float currentTimeVal = 0f;          
    private int currentColorNum = 0;
    private const float TIME_BETWEEN_COLORS = 1f;     // controls the speed at which the player changes colors

    private readonly Color32[] colorArray = {Color.red,                                 // The sequence of colors used for the rainbow appearance (ROYGBIV)
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
            rend = player.GetComponent<MeshRenderer>();
            MeshFilter filter = player.GetComponent<MeshFilter>();
            if (isSoccerBall)
            {
                filter.mesh = soccerBall;
                Material[] soccerBallMats = new Material[2];
                soccerBallMats[0] = soccerBallMatWhite;
                soccerBallMats[1] = soccerBallMatBlack;
                rend.materials = soccerBallMats;
                player.transform.localScale = Vector3.one * 5;
                player.GetComponent<SphereCollider>().radius = SOCCER_BALL_COLLIDER_RADIUS;
            }
            else if(isBasketball)
            {
                filter.mesh = basketball;
                Material[] basketballMats = new Material[2];
                basketballMats[0] = basketballMatBall;
                basketballMats[1] = basketballMatRings;
                rend.materials = basketballMats;
                player.transform.localScale = Vector3.one * 0.5f;
                player.GetComponent<SphereCollider>().radius = BASKETBALL_COLLIDER_RADIUS;
            }
            else
            {
                rend.material.color = c;
            }

            
        }
    }

    private void Update()
    {
        currentTimeVal += Time.deltaTime;
        if (currentTimeVal >= TIME_BETWEEN_COLORS)
        {
            currentColorNum++;
            currentTimeVal = 0;
        }

        if (isRainbow && player != null)      // apply rainbow effect to player if they selected the rainbow option
        {
            RainbowColor(rend);
        }

        GameObject[] rainbowObjs = GameObject.FindGameObjectsWithTag("Rainbow");

        foreach(GameObject rainbowObj in rainbowObjs)       // apply rainbow effect to all GameObjects with tag Rainbow
        {
            if (rainbowObj.layer == 5)                      // 5 is UI layer
            {
                Image uiRainbow = rainbowObj.GetComponent<Image>();
                if (uiRainbow != null)
                {
                    RainbowImage(uiRainbow);
                }
            }
            else
            {
                MeshRenderer currentRenderer = rainbowObj.GetComponent<MeshRenderer>();
                if (currentRenderer != null)
                {
                    RainbowColor(currentRenderer);
                }
            }
        }
        
        
    }

    private void RainbowColor(MeshRenderer objToChange)
    {
        if(currentColorNum == 7)
        {
            currentColorNum = 0;
            return;
        }
        if(currentColorNum == 6)
        {
            objToChange.material.color = Color.Lerp(colorArray[currentColorNum], colorArray[0], currentTimeVal / TIME_BETWEEN_COLORS);
            return;
        }
        objToChange.material.color = Color.Lerp(colorArray[currentColorNum], colorArray[currentColorNum + 1], currentTimeVal / TIME_BETWEEN_COLORS);

    }

    private void RainbowImage(Image imageToChange)      // used for the rainbow button in Change Color scene
    {
        if (currentColorNum == 7)
        {
            currentColorNum = 0;
            return;
        }
        if (currentColorNum == 6)
        {
            imageToChange.color = Color.Lerp(colorArray[currentColorNum], colorArray[0], currentTimeVal / TIME_BETWEEN_COLORS);
            return;
        }
 
        imageToChange.color = Color.Lerp(colorArray[currentColorNum], colorArray[currentColorNum + 1], currentTimeVal / TIME_BETWEEN_COLORS);
    }

    public void changeColorsToCyan()
    {
        c = Color.cyan;
        isSoccerBall = false;
        isRainbow = false;
        isBasketball = false;
    }
    public void changeColorsToGreen()
    {
        c = Color.green;
        isSoccerBall = false;
        isRainbow = false;
        isBasketball = false;
    }
    public void changeColorsToPurple()
    {
        c = new Color32(128, 0, 128, 255);
        isSoccerBall = false;
        isRainbow = false;
        isBasketball = false;
    }
    public void changeColorsToYellow()
    {
        c = Color.yellow;
        isSoccerBall = false;
        isRainbow = false;
        isBasketball = false;
    }
    public void changeColorsToOrange()
    {
        c = new Color32(255, 165, 0, 255);
        isSoccerBall = false;
        isRainbow = false;
        isBasketball = false;
    }
    public void changeColorsToBlue()
    {
        c = Color.blue;
        isSoccerBall = false;
        isRainbow = false;
        isBasketball = false;
    }

    public void changeToSoccerBall()
    {
        isSoccerBall = true;
        isRainbow = false;
        isBasketball = false;
    }

    public void changeToRainbow()
    {
        isRainbow = true;
        isSoccerBall = false;
        isBasketball = false;
    }

    public void changeToBasketball()
    {
        isRainbow = false;
        isSoccerBall = false;
        isBasketball = true;
    }
}
