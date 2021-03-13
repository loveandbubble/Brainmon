using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public const int gridRows = 4;
    public const int gridCols = 4;
    public const float offsetX = 1.6f;
    public const float offsetY = 2.1f;

    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh timeText;
    [SerializeField] GameObject Panel;

    [SerializeField] Text yourTime;
	[SerializeField] Text yourScore;

    public int gameTime;
    public int point;
    

    private void Start() 
    {
        InvokeRepeating("IncreaseTime", 1.0f, 1.0f);
        Vector3 startPos = originalCard.transform.position; //The position of the first card.All other cards are offset from here.

        int[] numbers = {0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7};
        numbers = ShuffleArray(numbers); //This is a function we will create in minute!

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if(i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.ChangeSprite(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = (offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    void Update()
    {
        timeText.text = "Time : " + gameTime;
    }

    void IncreaseTime()
    {
        gameTime ++;
        if(_score >= 8){
            CancelInvoke("IncreaseTime");
            ShowScore();
            Panel.SetActive(true);
        }
    }

    void ShowScore()
    {
        yourTime.text = "Time : " + gameTime;
        if(gameTime <= 15)
        {
            point = 5;
        }
        else if(gameTime <= 20)
        {
            point = 4;
        }
        else
        {
            point = 3;
        }
        // Debug.Log(point);
        yourScore.text = "You got Memory point " + point;
        
    }



    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    public int _score = 0;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if(_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

}
