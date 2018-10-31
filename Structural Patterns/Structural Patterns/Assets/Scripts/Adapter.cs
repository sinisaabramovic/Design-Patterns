using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Adapter{
    
    public class Adapter : MonoBehaviour
    {
        object[] shapes = { new Line(), new Rectangle() };
        // Use this for initialization
        int x1 = 5, x2 = 10, y1 = 10, y2 = 20;
        int w = 5, h = 10;
        void Start()
        {
            foreach(object shape in shapes){
                if(shape.GetType() == typeof(Line))
                {
                    ((Line)shape).Draw(x1, y1, x2, y2);
                }else if(shape.GetType() == typeof(Rectangle))
                {
                    ((Rectangle)shape).Draw(x1, y1, w, h);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    // Example of Adapter using abstract class Shape
    public abstract class Shape
    {
        public string name;
        // Lets assume that all object will have Draw
        public abstract void Draw(int x1, int x2, int y1, int y2);
    }

    public class LineAdapter : Shape
    {
        private Line adaptee;

        public LineAdapter(Line line)
        {
            this.adaptee = line;
        }

        public override void Draw(int x1, int x2, int y1, int y2)
        {
            adaptee.Draw(x1, x2, y1, y2);
        }
    }

    public class RectangleAdapter : Shape
    {
        private Rectangle adaptee;

        public RectangleAdapter(Rectangle rectangle)
        {
            this.adaptee = rectangle;
        }

        public override void Draw(int x1, int x2, int y1, int y2)
        {
            int x = Mathf.Min(x1, x2);
            int y = Mathf.Min(y1, y2);

            int width = Mathf.Abs(x2 - x1);
            int height = Mathf.Abs(y2 - y1);

            adaptee.Draw(x, y, width, height);
        }
    }

    public class Rectangle
    {
        public string name;

        public Rectangle()
        {
            name = "Rectangle";
        }

        public void Draw(int x, int y, int w, int h)
        {
            Debug.Log(string.Format("Rectangle at : {0}, {1} with width/height {2},{3}", x, y, w, h));
        }
    }

    public class Line
    {
        public string name;

        public Line(){
            name = "Line";
        }

        public void Draw(int x1, int x2, int y1, int y2)
        {
            Debug.Log(string.Format("Line from: {0}, {1} to {2},{3}", x1, y1, x2, y2));
        }
    }
        

}

