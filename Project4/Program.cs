using System;

namespace Project4
{
    class Program
    {
        //2. 随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。
        interface Shapefun
        {
            double Cal();
            void Prove();
        }
        class Shape
        {
            public static double sum = 0;
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
            public double Cal()
            {
                double total = 0;
                total = this.Height * this.Width;
                Console.Write("Rectangle Area=");
                Console.WriteLine(total);
                return total;
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
            public double Cal()
            {
                double total = 0;
                total = this.Height * this.Width;
                Console.Write("Square Area=");
                Console.WriteLine(total);
                return total;
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

            public double Cal()
            {
                double total = 0;
                if (IsTriangle())
                {
                   
                    total = (this.Height * this.Width) / 2;
                    Console.Write("Triangle Area=");
                    Console.WriteLine(total);
                    
                }
                return total;
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
                public Shapefun CreateShape(int type)
                {
                    switch (type.ToString())
                    {
                        case "1":
                            Console.WriteLine("Please input rectangle height:");
                            double a = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Please input rectangle width:");
                            double b = Double.Parse(Console.ReadLine());
                            return new Rectangle(a, b);
                            break;

                        case "2":
                            Console.WriteLine("Please input square height:");
                            double c = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Please input square width:");
                            double d = Double.Parse(Console.ReadLine());
                            return new Rectangle(c, d);
                            break;

                        case "3":
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
                int i = 0;
              
                Random r = new Random();
                while (i < 10)
                {
                    SimpleFactory(r.Next(1,3));
                    i++;
                }
                
                Console.ReadKey();
            }

            static void SimpleFactory(int n)
            {
                ShapeFactory shapeFactory = new ShapeFactory();
                Shapefun randomShape = shapeFactory.CreateShape(n);
                sum +=(randomShape.Cal());
                Console.WriteLine("Sum area = "+sum);
                randomShape.Prove();           
            }
        }
    }
}

