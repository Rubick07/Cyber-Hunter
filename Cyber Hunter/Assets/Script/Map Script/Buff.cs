using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public int BuffNumber;
    /*
     Note
    0 = Chatlog
    1 = VoiceLog
    2 = Digital Trail
    3 = SpareEnergyBox
     */
    public void ChatLog()
    {
        GameManager.Instance.Phase = 5;
        //gameManager.Phase = 5;
        Debug.Log("ChatLog");
    }

    public void VoiceLog()
    {
        //GameManager gameManager = FindObjectOfType<GameManager>();
        //gameManager.MaxTurn += 3;
        GameManager.Instance.MaxTurn += 3;
        Debug.Log("VoiceLog");
    }

    public void DigitalTrail()
    {
        //GameManager gameManager = FindObjectOfType<GameManager>();
        //gameManager.DoubleTurn = true;
        GameManager.Instance.DoubleTurn = true;
        Debug.Log("DigitalTrail");
    }

    public void SpareEnergyBox()
    {
        Player player = FindObjectOfType<Player>();
        player.TakeHeal(40);
        Debug.Log("SpareEnergyBox");
    }


}
