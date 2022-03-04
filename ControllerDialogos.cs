using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDialogos : MonoBehaviour
{
    public static ControllerDialogos singleton;
    public static bool INconversation =  false;

    public GameObject Dialogos;
    public Text TEXTDIALOGOS;
    [Header("keyBoard Settings")]
    
    public TalkSettings SETTINGS;
    [Header("Interactions")]
    public Conversation[] interaction;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    void Start()
    {
        Dialogos.SetActive(false);
    }

    public IEnumerator say(Conversation[]_Dialogos)
    { 

        Dialogos.SetActive(true);
        INconversation = true;
        for( int i = 0; i < _Dialogos.Length; i++)
        {
            TEXTDIALOGOS.text = "";
            for (int j = 0; j < _Dialogos[i].TEXT.Length + 1 ; j++)
            {
                if(Input.GetKey(SETTINGS.keySkip) || Input.GetKey(SETTINGS.keySkip2))
                {
                    j = _Dialogos[i].TEXT.Length;
                }
                TEXTDIALOGOS.text = _Dialogos[i].TEXT.Substring(0,j);
                yield return new WaitForSeconds(SETTINGS.TimeSpell);
            }
            TEXTDIALOGOS.text = _Dialogos[i].TEXT;
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => Input.GetKeyDown(SETTINGS.keyToNext));
        }
        Dialogos.SetActive(false);
        INconversation = false;
    }
    [ContextMenu("Activar proof")]
    public void proof()
    {
        StartCoroutine(say(interaction));
    }

}

[System.Serializable]

public class Conversation
{
    public string TEXT ;
}

[System.Serializable]

public class ConversationState
{
    public Conversation[] conversations;
}
public class NpcConversation
{
    public string words;
    public Sprite Npc;
}
public class PlayerConversation
{

}
