using System;

namespace Project3
{
    class Program
    {
        /*
         * 1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口、属性来实现。     
         */
        interface Shapefun
        {
            void Cal();
            void Prove();
        }
        class Shape
        {
            private double _height;
            private double _width;
            public Shape(double height, double wide)
            {
                _height = height;
                _width = wide;
            }

            public double Height
            {
                get => _height;
                set => _height = value;
            }

            public double Width
            {
                get => _width;
                set => _width = value;
            }
        }

        class Rectangle : Shape, Shapefun
        {
            public Rectangle(double height, double wide) : base(height, wide)
            {
            }
            public void Cal()
            {
                double total = 0;
                total = this.Height * this.Width;
                Console.WriteLine(total);
            }
            public void Prove()
            {
                if ((this.Height != this.Width) && (this.Height > 0) && (this.Width > 0))
                {
                    Console.WriteLine("形状合法");
                }
                else
                {
                    Console.WriteLine("形状不合法");
                }
            }
        }

        class Square : Shape, Shapefun
        {
            public Square(double height, double wide) : base(height, wide)
            {
            }
            public void Cal()
            {
                double total = 0;
                total = this.Height * this.Width;
                Console.WriteLine(total);
            }
            public void Prove()
            {
                if ((this.Height == this.Width) && (this.Height > 0) && (this.Width > 0))
                {
                    Console.WriteLine("形状合法");
                }
                else
                {
                    Console.WriteLine("形状不合法");
                }
            }
        }

        class Triangle : Shape, Shapefun
        {
            private double _bevelEdge;
            public double BevelEdge
            {
                get => _bevelEdge;
                set => _bevelEdge = value;
            }

            public Triangle(double height, double wide, double bevelEdge) : base(height, wide)
            {
            }

            public void Cal()
            {
                if (IsTriangle())
                {
                    double total = 0;
                    total = (this.Height * this.Width) / 2;
                    Console.WriteLine(total);
                }
            }

            public bool IsTriangle()
            {
                if ((this.BevelEdge + this.Height > this.Width) && (this.BevelEdge + this.Width > this.Height) && (this.Width + this.Height > this.BevelEdge))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Prove()
            {
                if ((this.BevelEdge > 0) && (this.Height > 0) && (this.Width > 0) && IsTriangle())
                {
                    Console.WriteLine("形状合法");
                }
                else
                {
                    Console.WriteLine("形状不合法");
                }

            }

            class ShapeFactory
            {
                public Shapefun CreateShape(string type)
                {
                    switch (type.ToLower())
                    {
                        case "rectangle":
                            Console.WriteLine("Please input rectangle height:");
                            double a = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Please input rectangle width:");
                            double b = Double.Parse(Console.ReadLine());
                            return new Rectangle(a, b);
                            break;

                        case "square":
                            Console.WriteLine("Please input square height:");
                            double c = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Please input square width:");
                            double d = Double.Parse(Console.ReadLine());
                            return new Rectangle(c, d);
                            break;

                        case "triangle":
                            Console.WriteLine("Please input triangle height:");
                            double e = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Please input triangle width:");
                            double f = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Please input triangle bevelEdge:");
                            double g = Double.Parse(Console.ReadLine());
                            return new Triangle(e, f, g);
                            break;

                        default:
                            return null;

                    }
                }
            }

            static void Main(string[] args)
            {

                SimpleFactory();
                Console.ReadKey();
            }

            static void SimpleFactory()
            {
                ShapeFactory shapeFactory = new ShapeFactory();
                Shapefun rectangle = shapeFactory.CreateShape("rectangle");
                Console.Write(" Rectangle Area=");
                rectangle.Cal();
                rectangle.Prove();
                Shapefun square = shapeFactory.CreateShape("square");
                Console.Write(" Square Area=");
                square.Cal();
                square.Prove();
                Shapefun triangle = shapeFactory.CreateShape("triangle");
                Console.Write(" Triangle Area=");
                triangle.Cal();
                triangle.Prove();
            }
        }
    }
}