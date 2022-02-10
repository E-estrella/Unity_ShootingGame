using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����Ƽ UI�� ����ϱ� ���� ���ӽ����̽�
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // �̱��� ��ü
    public static ScoreManager Instance = null;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            // 3. ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ��Ѵ�.
            currentScore = value;
            // 4. ȭ�鿡 ���� ���� ǥ���ϱ�
            currentScoreUI.text = "�������� : " + currentScore;

            // ��ǥ: �ְ� ������ ǥ���ϰ� �ʹ�.
            // 1. ���� ������ �ְ� �������� ũ�ϱ�
            // -> ���� ���� ������ �ְ� ������ �ʰ��Ͽ��ٸ�
            if (currentScore > bestScore)
            {
                // 2. �ְ� ������ ���Ž�Ų��.
                bestScore = currentScore;

                // 3. �ְ� ���� UI�� ǥ��
                bestScoreUI.text = "�ְ����� : " + bestScore;

                // ��ǥ : �ְ������� �����ϰ� �ʹ�.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }
    // �̱��� ��ü�� ���� ������ ������ �ڱ� �ڽ��� �Ҵ�
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // �ʿ�Ӽ� : ���� UI, ��������, �ְ�����
    // ���� ���� UI
    public Text currentScoreUI;
    // ���� ����
    private int currentScore;

    // �ְ� ���� UI
    public Text bestScoreUI;
    // �ְ� ����
    private int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        // ��ǥ : �ְ����� �ҷ��ͼ� bestScore ������ �Ҵ��ϰ� ȭ�鿡 ǥ���Ѵ�.
        // ���� : 1. �ְ����� �ҷ��ͼ� bestScore�� �־��ֱ�
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        //        2. �ְ����� ȭ�鿡 ǥ���ϱ�
        bestScoreUI.text = "�ְ����� : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
