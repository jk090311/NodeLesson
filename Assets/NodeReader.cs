using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XNode;

public class NodeReader : MonoBehaviour
{
    public TMP_Text dialog;
    public Sprite backgroundImage;
    public GameObject ImageGO;
    public NodeGraph graph;
    public BaseNode currentNode;
    public GameObject characterSheet;
    public TMPro.TMP_Text buttonAText;
    public TMPro.TMP_Text buttonBText;
    public GameObject buttonA;
    public GameObject buttonB;

    public GameObject nextButtonGO;
    public AudioSource audioSource;
    public AudioClip suspenseClip;
    public AudioClip adventureClip;
    public AudioClip dramaClip;
    public AudioClip happyClip;
    public GameObject ActorImageGO;
    private Vector2 actorStartPosition = new Vector2(-1360f, 0f); // Starting position (off-screen to the left)
    private Vector2 actorEndPosition = new Vector2(0f, 0f); // Ending position (onscreen)

    void Start()
    {
        currentNode = GetStartNode();
        AdvancedDialog();
    }

    public BaseNode GetStartNode()
    {
        return graph.nodes.Find(node => node is BaseNode && node.name == "Start") as BaseNode;
    }

    public void DisplayNode(BaseNode node)
    {
        dialog.text = node.getDialogText();
        backgroundImage = node.getSprite();
        ImageGO.gameObject.GetComponent<Image>().sprite = backgroundImage;
        if (node is SimpleDialogV2 simpleNode)
        {
            ActorImageGO.GetComponent<Image>().sprite = simpleNode.getSpriteActor();
            PlayBackgroundMusic(simpleNode.getBgMusic());
            if (ActorImageGO.GetComponent<Image>().sprite == null)
            {
                ActorImageGO.GetComponent<RectTransform>().anchoredPosition = actorStartPosition;
            }
            else
            {
                if (simpleNode.getSlideInActor())
                {
                    SlideInActorImage(simpleNode.getSpriteActor());
                }
                else
                {
                    ActorImageGO.GetComponent<Image>().sprite = simpleNode.getSpriteActor();
                    ActorImageGO.GetComponent<RectTransform>().anchoredPosition = actorEndPosition;
                }
            }

        }
        if (node is MultipleChoiceDialog)
        {
            buttonAText.text = "" + ((MultipleChoiceDialog)node).a;
            buttonBText.text = "" + ((MultipleChoiceDialog)node).b;

            buttonA.SetActive(true);
            buttonB.SetActive(true);
            nextButtonGO.SetActive(false);
        }
        else
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
            nextButtonGO.SetActive(true);
        }

    }
    private void SlideInActorImage(Sprite actorSprite)
    {
        ActorImageGO.GetComponent<Image>().sprite = actorSprite;
        StartCoroutine(SlideImageCoroutine());
    }

    private IEnumerator SlideImageCoroutine()
    {
        RectTransform actorRect = ActorImageGO.GetComponent<RectTransform>();
        float duration = 1.0f;
        float elapsedTime = 0f;

        actorRect.anchoredPosition = actorStartPosition;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            actorRect.anchoredPosition = Vector2.Lerp(actorStartPosition, actorEndPosition, elapsedTime / duration);

            yield return null;
        }

        actorRect.anchoredPosition = actorEndPosition;
    }

    private void PlayBackgroundMusic(BgMusic bgm)
    {
        switch (bgm)
        {
            case BgMusic.SUSPENSE:
                audioSource.clip = suspenseClip;
                break;
            case BgMusic.ADVENTURE:
                audioSource.clip = adventureClip;
                break;
            case BgMusic.DRAMA:
                audioSource.clip = dramaClip;
                break;
            case BgMusic.HAPPY:
                audioSource.clip = happyClip;
                break;
        }

        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public void AdvancedDialog()
    {
        var nextNode = GetNextNode(currentNode);
        if (nextNode != null)
        {
            currentNode = nextNode;
            DisplayNode(currentNode);
        }
        else
        {
            Debug.Log("nothing found");
        }
    }

    private BaseNode GetNextNode(BaseNode node)
    {
        if (node is MultipleChoiceDialog)
        {
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
            TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();
            if (buttonText.text == ("" + ((MultipleChoiceDialog)node).a))
            {
                return currentNode.GetOutputPort("a")?.Connection.node as BaseNode;
            }
            if (buttonText.text == ("" + ((MultipleChoiceDialog)node).b))
            {
                return currentNode.GetOutputPort("b")?.Connection.node as BaseNode;
            }
            return currentNode.GetOutputPort("a")?.Connection.node as BaseNode;
        }
        else if (node is AbilityCheckNode)
        {
            int d20 = Random.Range(0, 21);
            if ((d20 + characterSheet.gameObject.GetComponent<CharacterStats>().survival) >= ((AbilityCheckNode)node).getDC())
            {
                return currentNode.GetOutputPort("success")?.Connection.node as BaseNode;
            }
            else
            {
                return currentNode.GetOutputPort("failure")?.Connection.node as BaseNode;
            }
        }
        else
        {
            return currentNode.GetOutputPort("exit")?.Connection.node as BaseNode;
        }
    }

}
