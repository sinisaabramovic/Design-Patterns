using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // Use this for initialization

    public List<IEnemy> enemies = new List<IEnemy>();
    // Instance of Factory
    EnemyFactory enemyFactory = new EnemyFactory();

    private void Awake () 
    {
        enemies.Add(enemyFactory.GetEnemy(EnemyTypes.flying));
        enemies.Add(enemyFactory.GetEnemy(EnemyTypes.walking));
        enemies.Add(enemyFactory.GetEnemy(EnemyTypes.swimming));

        foreach(IEnemy enemy in enemies){
            enemy.Move();
            enemy.Attack();
            enemy.TakeDamage();
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}   
}

public enum EnemyTypes
{
    flying = 0,
    walking,
    swimming
};

public class EnemyFactory
{
    public IEnemy GetEnemy(EnemyTypes enemyType)
    {
        switch (enemyType)
        {
            case EnemyTypes.flying:
                return new FlyingEnemy();
            case EnemyTypes.walking:
                return new WalkingEnemy();
            case EnemyTypes.swimming:
                return new SwimmingEnemy();
            default:
                return new WalkingEnemy();
        }
    }
}

public interface IEnemy
{
    void Move();
    void Attack();
    void TakeDamage();
}

[System.Serializable]
public class FlyingEnemy : IEnemy
{
    public int health;
    public int attDmg;
    public EnemyTypes type;

    public FlyingEnemy()
    {
        health = 50;
        attDmg = 5;
        type = EnemyTypes.flying;
    }

    public void Move()
    {
        Debug.Log("I'm flying about!");
    }

    public void Attack()
    {
        Debug.Log("I'm aerial attacking you!");
    }

    public void TakeDamage()
    {
        Debug.Log("I'm taking damage up here!");
    }

}

[System.Serializable]
public class WalkingEnemy : IEnemy
{
    public int health;
    public int attDmg;
    public EnemyTypes type;

    public WalkingEnemy()
    {
        health = 150;
        attDmg = 15;
        type = EnemyTypes.walking;
    }

    public void Move()
    {
        Debug.Log("I'm walking about!");
    }

    public void Attack()
    {
        Debug.Log("I'm ground attacking you!");
    }

    public void TakeDamage()
    {
        Debug.Log("I'm taking damage up here!");
    }
}

[System.Serializable]
public class SwimmingEnemy : IEnemy
{
    public int health;
    public int attDmg;
    public EnemyTypes type;

    public SwimmingEnemy()
    {
        health = 25;
        attDmg = 1;
        type = EnemyTypes.swimming;
    }

    public void Move()
    {
        Debug.Log("I'm swimming about!");
    }

    public void Attack()
    {
        Debug.Log("I'm watter attacking you!");
    }

    public void TakeDamage()
    {
        Debug.Log("I'm taking damage up here!");
    }
}
