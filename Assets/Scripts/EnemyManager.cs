using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // ������ƮǮ ũ��
    public int poolSize = 10;
    // ������ƮǮ �迭
    public List<GameObject> enemyObjectPool;
    // SpawnPoint��
    public Transform[] spawnPoints;
    // ���� �ð�
    float currentTime;
    // ���� �ð�
    public float createTime = 1;
    // �� ����
    public GameObject enemyFactory;

    // �ּҽð�
    float minTime = 1;
    // �ִ�ð�
    float maxTime = 5;

    // �¾ ��
    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(1.0f, 5.0f);
        // 2. ������ƮǮ�� ���ʹ̵��� ���� �� �ִ� ũ��� ������ش�.
        enemyObjectPool = new List<GameObject>();
        // 3. ������ƮǮ�� ���� ���ʹ� ������ŭ �ݺ��Ͽ�
        for(int i = 0; i < poolSize; i++)
        {
            // 4. ���ʹ̰��忡�� ���ʹ̸� �����Ѵ�.
            GameObject enemy = Instantiate(enemyFactory);
            // 5. ���ʹ̸� ������ƮǮ�� �ְ� �ʹ�.
            enemyObjectPool.Add(enemy);
            // ��Ȱ��ȭ��Ű��.
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // 1. ���� �ð��� �Ǿ����ϱ�
        if(currentTime > createTime)
        {
            // 2. ������ƮǮ�� ���ʹ̰� �ִٸ�
            GameObject enemy = enemyObjectPool[0];
            if(enemyObjectPool.Count > 0)
            {
                // 3. ���ʹ̸� Ȱ��ȭ�ϰ� �ʹ�.
                enemy.SetActive(true);
                // 4. ������ƮǮ���� ���ʹ�����
                enemyObjectPool.Remove(enemy);
                // �������� �ε��� ����
                int index = Random.Range(0, spawnPoints.Length);
                // ���ʹ� ��ġ ��Ű��
                enemy.transform.position = spawnPoints[index].position;
            }
            createTime = Random.Range(1.0f, 5.0f);
            currentTime = 0;
        }
    }
}
