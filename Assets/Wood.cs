using UnityEngine;

public class Wood : MonoBehaviour
{

    public Sprite[] WoodSprites;
    private int _logs = 3;
    public int LogCount
    {
        get { return _logs; }
        private set{}
    }

	// Use this for initialization
	void Start ()
	{
	    TurnManager.newDayCallback += DecrementWoodCount;
	}

    private void DecrementWoodCount()
    {
        _logs -= 1;
        if (_logs == 0)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            TurnManager.newDayCallback -= DecrementWoodCount;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = WoodSprites[_logs - 1];
        }
        Debug.Log("LOGS: " + _logs);
    }
	
	// Update is called once per frame
	void Update ()
	{
	}
}
