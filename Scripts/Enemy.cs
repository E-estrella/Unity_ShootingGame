using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ǥ: ���� �ٸ� ��ü�� �浹���� �� ���� ȿ���� �߻���Ű�� �ʹ�.
// ����: 1. ���� �ٸ� ��ü�� �浹�����ϱ�.
//       2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �Ѵ�.
//       3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
// �ʿ��� �Ӽ�: ���� ���� �ּ�(�ܺο��� ���� �־��ش�.)
public class Enemy : MonoBehaviour
{
    // �ʿ�Ӽ�: �̵��ӵ�
    public float speed = 5;
    GameObject Player;
    
    // ������ ���������� ���� Start�� Update���� ���
    Vector3 dir;

    // ���� ���� �ּ�(�ܺο��� ���� �־��ش�.)
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // Vector3 dir; -> ����
        // 0���� 9(10-1)���� �� �߿� �ϳ��� �������� �����ͼ�
        int randValue = UnityEngine.Random.Range(0, 10);

        // ���� 3���� ������ �÷��̾����
        if(randValue < 3)
        {
            // �÷��̾ ã�Ƽ� target���� �ϰ�ʹ�.
            GameObject target = GameObject.Find("Player");
            // ������ ���ϰ� �ʹ�. target-me
            dir = target.transform.position - transform.position;
            // ������ ũ�⸦ 1�� �ϰ� �ʹ�.
            dir.Normalize();
        }
        // �׷��� ������ �Ʒ��������� ���ϰ� �ʹ�.
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 1. ������ ���Ѵ�.
        // Vector3 dir = Vector3.down; -> ����

        // 2. �̵��ϰ� �ʹ�. ���� P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }

    // 1. ���� �ٸ� ��ü�� �浹�����ϱ�.
    private void OnCollisionEnter(Collision other)
    {
        // ���ʹ̸� ���� ������ ���� ���� ǥ���ϰ� �ʹ�.
        ScoreManager.Instance.Score++;
       
        // 2. ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� ������ �Ѵ�.
        GameObject explosion = Instantiate(explosionFactory);

        // 3. ���� ȿ���� �߻�(��ġ)��Ű�� �ʹ�.
        explosion.transform.position = transform.position;

        // ���� �ε��� ��ü�� Bullet�� ��쿡�� ��Ȱ��ȭ���� źâ�� �ٽ� �־��ش�.
        // 1. ���� �ε��� ��ü�� Bullet�̶��
        if(other.gameObject.name.Contains("Bullet"))
        {
            // 2. �ε��� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);

            // PlayerFire Ŭ���� ������
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // list�� �Ѿ� ����
            player.bulletObjectPool.Add(other.gameObject);
        }
        // 3. �׷��� ������ ����
        else
        {
            Destroy(other.gameObject);
        }
        // Destory�� ���ִ� ��� ��Ȱ��ȭ�Ͽ� Ǯ�� �ڿ��� �ݳ��մϴ�.
        //Destroy(gameObject);
        gameObject.SetActive(false);

        // EnemyManager Ŭ���� ������
        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>();
        // list�� �Ѿ� ����
        manager.enemyObjectPool.Add(other.gameObject);
    }
}
