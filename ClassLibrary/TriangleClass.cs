using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class TriangleClass : FigureClass
    {
        public const string FIGURE_TYPE_NAME = "triangle";
        const string PARAM_SIDEA = "side_a";
        const string PARAM_SIDEB = "side_b";
        const string PARAM_SIDEC = "side_c";

        double sideA, sideB, sideC;   // Стороны треугольника
        double perimeter; //Периметр
        double area; //Площадь
        public TriangleClass()
        {
            sideA = 0;
            sideB = 0;
            sideC = 0;
            perimeter = 0;
            area = 0;
        }
        public double SideA
        {
            get { return sideA; }
            set { sideA = Math.Abs(value); }
        }

        public double SideB
        {
            get { return sideB; }
            set { sideB = Math.Abs(value); }
        }

        public double SideC
        {
            get { return sideC; }
            set { sideC = Math.Abs(value); }
        }

        public override void ParceParameters(string[] parameters)
        {
            string[] parameter;
            String pattern = @"\""([^\""]+)\"""; //Оставляем только то, что в двойных кавычках

            foreach (var item in parameters)
            {
                //Параметр состоит из типа и значения
                parameter = item.Split(new char[] { ':' });//Разбиваем параметр на 2 части
                //Проверяем длину
                if (parameter.Length < 2)
                {
                    continue;
                }
                
                string type ="";
                //Оставляем только то, что в двойных кавычках (избавляемся от случайных символов до и после)
                foreach (Match match in Regex.Matches(parameter[0], pattern))
                {
                    type = match.Groups[1].Value;
                }

                String str_value = parameter[1];//Получаем значение
                double value = 0;
                //оставляем только цифры, если параметр не содержит значения, то value = 0;
                double.TryParse(string.Join("", str_value.Where(c => char.IsDigit(c))), out value);
                switch (type)
                {
                    case PARAM_SIDEA:
                        try { SideA = value; }
                        catch { SideA = 0; };
                        break;
                    case PARAM_SIDEB:
                        try { SideB = value; }
                        catch { SideB = 0; };
                        break;

                    case PARAM_SIDEC:
                        try { SideC = value; }
                        catch { SideC = 0; };
                        break;
                }
            }
            area = AreaCalculate(sideA, sideB, sideC);
            perimeter = PerimeterCalculate(sideA, sideB, sideC);
        }

        //Площадь
        public double AreaCalculate(double a, double b, double c)
        {
            double semi_perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semi_perimeter * (semi_perimeter - a) * (semi_perimeter - b) * (semi_perimeter - c));
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }
        //Периметр
        public double PerimeterCalculate(double a, double b, double c)
        {
            double perimeter = a + b + c;
            return perimeter;
        }

        public override double AreaGet()
        {
            return area;
        }

        public override double PerimeterGet()
        {
            return perimeter; 
        }

        public override string TypeGet()
        {
            return FIGURE_TYPE_NAME;
        }
    }
}
