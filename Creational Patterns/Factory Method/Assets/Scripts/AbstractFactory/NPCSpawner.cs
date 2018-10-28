using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractFactoryNamespace
{
    public class NPCSpawner : MonoBehaviour
    {
        // Or use enums (instend of strings)
        NPCFactory enemmyFactory = NPCFactoryProducer.GetFactory(FactoryTypes.enemy);
        NPCFactory friendlyFactory = NPCFactoryProducer.GetFactory(FactoryTypes.friendly);

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public abstract class Enemy
    {
        public int health;
        public int attackPower;

        public abstract void Move();
        public abstract void Attack();
    }

    public abstract class Friendly
    {
        public int health;
        public int attackPower;

        public abstract void Move();
        public abstract void Attack();
    }

    public class FlyingEnemey : Enemy
    {
        public FlyingEnemey()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("Flying Enemy Attack !");
        }

        public override void Move()
        {
            Debug.Log("Flying Enemy Move !");
        }
    }

    public class WalkingEnemy : Enemy
    {
        public WalkingEnemy()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("WalkingEnemy  Attack !");
        }

        public override void Move()
        {
            Debug.Log("WalkingEnemy  Move !");
        }
    }

    public class FlyingFriendly : Friendly
    {
        public FlyingFriendly()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("FlyingFriendly  Attack !");
        }

        public override void Move()
        {
            Debug.Log("FlyingFriendly Move !");
        }
    }

    public class WalkingFriendly : Friendly
    {
        public WalkingFriendly()
        {
            health = 10;
            attackPower = 1;
        }

        public override void Attack()
        {
            Debug.Log("WalkingFriendly  Attack !");
        }

        public override void Move()
        {
            Debug.Log("WalkingFriendly  Move !");
        }
    }

    public abstract class NPCFactory
    {
        public abstract Enemy GetEnemy(EnemyTypes enemyType);
        public abstract Friendly GetFriendly(FriendlyTypes friendlyType);
    }

    public class EnemyFactory : NPCFactory
    {
        public override Enemy GetEnemy(EnemyTypes enemyType)
        {
            switch(enemyType)
            {
                case EnemyTypes.flying:
                    return new FlyingEnemey();
                case EnemyTypes.walking:
                    return new WalkingEnemy();
                default:
                    return new WalkingEnemy();
            }
        }

        public override Friendly GetFriendly(FriendlyTypes friendlyType)
        {
            return null;
        }
    }

    public class FriendlyFactory : NPCFactory
    {
        public override Enemy GetEnemy(EnemyTypes enemyType)
        {
            return null;
        }

        public override Friendly GetFriendly(FriendlyTypes friendlyType)
        {
            switch (friendlyType)
            {
                case FriendlyTypes.flying:
                    return new FlyingFriendly();
                case FriendlyTypes.walking:
                    return new WalkingFriendly();
                default:
                    return new WalkingFriendly();
            }
        }
    }

    public class NPCFactoryProducer
    {
        // Producer
        public static NPCFactory GetFactory (string choice)
        {
            switch(choice)
            {
                case ("EnemyFactory"):
                    return new EnemyFactory();
                case ("FriendlyFactory"):
                    return new FriendlyFactory();
                default:
                    return null;
            }
        }

        // Overrides of the GetFactory so it can use enums insteed of strings (more elegant solution) 
        public static NPCFactory GetFactory(FactoryTypes choice)
        {
            switch (choice)
            {
                case FactoryTypes.enemy:
                    return new EnemyFactory();
                case FactoryTypes.friendly:
                    return new FriendlyFactory();
                default:
                    return null;
            }
        }
    }
}


