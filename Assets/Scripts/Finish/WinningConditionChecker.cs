using UnityEngine;

public class WinningConditionChecker : MonoBehaviour
{
    private GameObject[] _AllFinish;
    private int _AmountOfFinishesThatHasBox = 0;
    private void Awake()
    {
        _AllFinish = GameObject.FindGameObjectsWithTag("Finish");
        foreach (var finish in _AllFinish)
        {
            var boxFinish = finish.GetComponent<BoxFinish>();
            boxFinish.boxEnter += AddBoxWhichHasHisBox;
            boxFinish.boxExit += DeleteBoxWhichBoxGoesFromIt;
        }
    }

    private void AddBoxWhichHasHisBox()
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
            Debug.Log("End game!");
        }
    }
}
