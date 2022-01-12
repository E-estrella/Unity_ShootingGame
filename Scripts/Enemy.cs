using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 목표: 적이 다른 물체와 충돌했을 때 폭발 효과를 발생시키고 싶다.
// 순서: 1. 적이 다른 물체와 충돌했으니까.
//       2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
//       3. 폭발 효과를 발생(위치)시키고 싶다.
// 필요한 속성: 폭발 공장 주소(외부에서 값을 넣어준다.)
public class Enemy : MonoBehaviour
{
    // 필요속성: 이동속도
    public float speed = 5;
    GameObject Player;
    
    // 방향을 전역변수로 만들어서 Start와 Update에서 사용
    Vector3 dir;

    // 폭발 공장 주소(외부에서 값을 넣어준다.)
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // Vector3 dir; -> 삭제
        // 0부터 9(10-1)까지 값 중에 하나를 랜덤으로 가져와서
        int randValue = UnityEngine.Random.Range(0, 10);

        // 만약 3보다 작으면 플레이어방향
        if(randValue < 3)
        {
            // 플레이어를 찾아서 target으로 하고싶다.
            GameObject target = GameObject.Find("Player");
            // 방향을 구하고 싶다. target-me
            dir = target.transform.position - transform.position;
            // 방향의 크기를 1로 하고 싶다.
            dir.Normalize();
        }
        // 그렇지 않으면 아래방향으로 정하고 싶다.
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 방향을 구한다.
        // Vector3 dir = Vector3.down; -> 삭제

        // 2. 이동하고 싶다. 공식 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    // 1. 적이 다른 물체와 충돌했으니까.
    private void OnCollisionEnter(Collision other)
    {
        // 에너미를 잡을 때마다 현재 점수 표시하고 싶다.
        ScoreManager.Instance.Score++;
       
        // 2. 폭발 효과 공장에서 폭발 효과를 하나 만들어야 한다.
        GameObject explosion = Instantiate(explosionFactory);

        // 3. 폭발 효과를 발생(위치)시키고 싶다.
        explosion.transform.position = transform.position;

        // 만약 부딪힌 객체가 Bullet인 경우에는 비활성화시켜 탄창에 다시 넣어준다.
        // 1. 만약 부딪힌 물체가 Bullet이라면
        if(other.gameObject.name.Contains("Bullet"))
        {
            // 2. 부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);

            // PlayerFire 클래스 얻어오기
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // list에 총알 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }
        // 3. 그렇지 않으면 제거
        else
        {
            Destroy(other.gameObject);
        }
        // Destory로 없애는 대신 비활성화하여 풀에 자원을 반납합니다.
        //Destroy(gameObject);
        gameObject.SetActive(false);

        // EnemyManager 클래스 얻어오기
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        // list에 총알 삽입
        manager.enemyObjectPool.Add(other.gameObject);
    }
}
