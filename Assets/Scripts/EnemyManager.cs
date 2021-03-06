using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // 오브젝트풀 크기
    public int poolSize = 10;
    // 오브젝트풀 배열
    public List<GameObject> enemyObjectPool;
    // SpawnPoint들
    public Transform[] spawnPoints;
    // 현재 시간
    float currentTime;
    // 일정 시간
    public float createTime = 1;
    // 적 공장
    public GameObject enemyFactory;

    // 최소시간
    float minTime = 1;
    // 최대시간
    float maxTime = 5;

    // 태어날 때
    // Start is called before the first frame update
    void Start()
    {
        createTime = Random.Range(1.0f, 5.0f);
        // 2. 오브젝트풀을 에너미들을 담을 수 있는 크기로 만들어준다.
        enemyObjectPool = new List<GameObject>();
        // 3. 오브젝트풀에 넣을 에너미 개수만큼 반복하여
        for(int i = 0; i < poolSize; i++)
        {
            // 4. 에너미공장에서 에너미를 생성한다.
            GameObject enemy = Instantiate(enemyFactory);
            // 5. 에너미를 오브젝트풀에 넣고 싶다.
            enemyObjectPool.Add(enemy);
            // 비활성화시키자.
            enemy.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // 1. 생성 시간이 되었으니까
        if(currentTime > createTime)
        {
            // 2. 오브젝트풀에 에너미가 있다면
            GameObject enemy = enemyObjectPool[0];
            if(enemyObjectPool.Count > 0)
            {
                // 3. 에너미를 활성화하고 싶다.
                enemy.SetActive(true);
                // 4. 오브젝트풀에서 에너미제거
                enemyObjectPool.Remove(enemy);
                // 랜덤으로 인덱스 선택
                int index = Random.Range(0, spawnPoints.Length);
                // 에너미 위치 시키기
                enemy.transform.position = spawnPoints[index].position;
            }
            createTime = Random.Range(1.0f, 5.0f);
            currentTime = 0;
        }
    }
}
