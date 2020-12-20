using UnityEngine;
using UnityEngine.InputSystem;

public class WinningConditionChecker : MonoBehaviour
{
    [SerializeField] private GameObject endGame = null;
    [SerializeField] private PlayerInput input = null;
    
    private GameObject[] _AllFinish;
    private int _AmountOfFinishesThatHasBox = 0;
    private void Awake()
    {
        _AllFinish = GameObject.FindGameObjectsWithTag("Finish");
        foreach (var finish in _AllFinish)
        {
            var boxFinish = finish.GetComponent<BoxFinish>();
            boxFinish.boxEnter += AddFinishWhichHasHisBox;
            boxFinish.boxExit += DeleteBoxWhichBoxGoesFromIt;
        }
    }

    private void AddFinishWhichHasHisBox()
    {
        _AmountOfFinishesThatHasBox++;
        CheckWinningConditions();
    }

    private void DeleteBoxWhichBoxGoesFromIt()
    {
        _AmountOfFinishesThatHasBox--;
    }

    private void CheckWinningConditions()
    {
        if (_AmountOfFinishesThatHasBox == _AllFinish.Length)
        {
            input.SwitchCurrentActionMap("Empty");
            endGame.SetActive(true);
        }
    }
}
