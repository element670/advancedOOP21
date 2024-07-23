using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private UIController _uiController;
    
    private WhoPlays currentPlayer = WhoPlays.ME;
    private int score=0;
    private void Start()
    {
        EventBus.Register<Buttons>(ButtonClick.ACTION, HandleButtonClick);
        _uiController.MatchMaking(() =>
        {
            _uiController.HidePeopleSearchPanel();
            _uiController.SetActiveButtons(true);
        });
    }
    private void HandleButtonClick(Buttons buttons)
    {
        var result = GetNumber(buttons);
        if (currentPlayer == WhoPlays.ME)
        {
            _uiController.SetMyScore(result);
            MyLogger.Logd("my selected button is: " + result);
            
        }
        else
        {
            _uiController.SetAIScore(result);
            MyLogger.Logd("ai selected button is " + result);
        }
        score += result;
        _uiController.SetResult(score);

        MyLogger.Logd($"current score is {score}");
        
        if (currentPlayer == WhoPlays.ME)
            currentPlayer = WhoPlays.AI;
        else
            currentPlayer = WhoPlays.ME;
        
        if (score >= 20)
        {
            _uiController.SetInteractable(false);
        }
        else
        {
            if (currentPlayer == WhoPlays.AI)
            {
                StartCoroutine(AISelection());
                _uiController.SetInteractable(false);
            }
            else 
                _uiController.SetInteractable(true);
        }
    }

    private int GetNumber(Buttons buttons)
    {
        
        switch (buttons)
        {
            case Buttons.ONE:
                return 1;
            case Buttons.TWO:
                return  2;
            case Buttons.THREE:
                return  3;
        }

        return 0;
    }
    private IEnumerator AISelection()
    {
        yield return new WaitForSeconds(2);
        var aiSelection = UnityEngine.Random.Range(1, 3);
        Buttons selectedButton = Buttons.ONE;
        switch (aiSelection)
        {
            case 2:
                selectedButton = Buttons.TWO;
                break;
            case 3:
                selectedButton = Buttons.THREE;
                break;

        }
        EventBus.Trigger(ButtonClick.ACTION, selectedButton);
    }
    
    public enum WhoPlays
    {
        ME, AI
    }

    public enum Buttons
    {
        ONE, TWO, THREE
    }

}
