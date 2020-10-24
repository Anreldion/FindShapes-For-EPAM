using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class TrapezoidClass : FigureClass
    {
        public const string FIGURE_TYPE_NAME = "trapezoid";
        const string PARAM_SIDEA = "side_a";
        const string PARAM_SIDEB = "side_b";
        const string PARAM_SIDEC = "side_c";
        const string PARAM_SIDED = "side_d";
        double sideA, sideB, sideC, sideD;   // Стороны трапеции
        double perimeter; //Периметр
        double area; //Площадь
        public TrapezoidClass()
        {
            sideA = 0;
            sideB = 0;
            sideC = 0;
            sideD = 0;
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
        public double SideD
        {
            get { return sideD; }
            set { sideD = Math.Abs(value); }
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

                string type = "";
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
                        try { SideA = Convert.ToDouble(value); }
                        catch { SideA = 0; };
                        break;
                    case PARAM_SIDEB:
                        try { SideB = Convert.ToDouble(value); }
                        catch { SideB = 0; };
                        break;

                    case PARAM_SIDEC:
                        try { SideC = Convert.ToDouble(value); }
                        catch { SideC = 0; };
                        break;

                    case PARAM_SIDED:
                        try { SideD = Convert.ToDouble(value); }
                        catch { SideD = 0; };
                        break;
                }
            }
            area = AreaCalculate(sideA, sideB, sideC, sideD);
            perimeter = PerimeterCalculate(sideA, sideB, sideC, sideD);
        }

        //Площадь
        public double AreaCalculate(double a, double b, double c, double d)
        {
            //              _______b_______
            //             /               \ 
            //          a /                 \ c
            //           /___________________\
            //                  d
            //               __________________________________________
            // S =  b+d     / a^2     -    ((d-b)^2 + a^2 - c^2  ) ^2
            //       2    _/               (       2(d-b)        )
            //
            double area = ((b + d) / 2.0) * Math.Sqrt(Math.Pow(a, 2) - Math.Pow(((Math.Pow(d - b, 2) + Math.Pow(a, 2) - Math.Pow(c, 2)) / (2 * (d - b))),2));
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }

        //Периметр
        public double PerimeterCalculate(double a, double b, double c, double d)
        {
            double perimeter = (a + b + c + d);
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
