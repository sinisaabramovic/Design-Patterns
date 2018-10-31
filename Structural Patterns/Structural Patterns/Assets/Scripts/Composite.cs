using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composite
{
    public class Composite : MonoBehaviour
    {
        Bag backPack = new Bag("BackPack", 100, true);
        Bag greenBag = new Bag("Green Bag", 50, true);
        // Use this for initialization
        void Start()
        {
            backPack.Add(new SellableItem("Helmet", 30, true));
            backPack.Add(new SellableItem("Sword", 50, true));

            greenBag.Add(new SellableItem("Diamond", 200, false));
            greenBag.Add(new SellableItem("Coil", 20, false));

            backPack.Add(greenBag);

            backPack.CalculateValue();

            backPack.Remove(greenBag);

            Debug.Log("++++++++++++++++++++++++++++++++++++++++++");

            backPack.CalculateValue();

            Debug.Log("++++++++++++++++++++++++++++++++++++++++++");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public abstract class Item
    {
        protected string _name;
        protected int _value;
        protected bool _isEquippable;

        public Item(string name, int value, bool isEquippable)
        {
            this._name = name;
            this._value = value;
            this._isEquippable = isEquippable;
        }

        public abstract void Add(Item item);
        public abstract void Remove(Item item);
        public abstract int CalculateValue();
    }

    public class SellableItem : Item
    {
        public SellableItem(string name, int value, bool isEquippable) : base(name, value, isEquippable) {}

        public override void Add(Item item)
        {
            Debug.Log("Cannot add to leaf");
        }

        public override int CalculateValue()
        {
            Debug.Log(string.Format("{0} is worth: {1}", _name, _value));
            return _value;
        }

        public override void Remove(Item item)
        {
            Debug.Log("Cannot remove from leaf");
        }
    }

    public class Bag : Item
    {
        // This will holds all items in the bag
        private List<Item> contents = new List<Item>();

        public Bag(string name, int value, bool isEquippable) : base(name, value, isEquippable) {}

        public override void Add(Item item)
        {
            contents.Add(item);
        }

        public override int CalculateValue()
        {
            foreach(Item item in contents)
            {
                _value += item.CalculateValue();
            }

            Debug.Log(string.Format("{0} is worth: {1}", _name, _value));

            return _value;
        }

        public override void Remove(Item item)
        {
            contents.Remove(item);
        }
    }
}

