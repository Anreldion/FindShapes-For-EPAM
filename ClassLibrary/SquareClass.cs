using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class SquareClass : FigureClass
    {
        public const string FIGURE_TYPE_NAME = "square";
        const string PARAM_SIDE = "side";
        double side;   //Сторона квадрата
        double perimeter; //Периметр
        double area; //Площадь
        public SquareClass()
        {
            side = 0;
        }
        public double Side
        {
            get { return side; }
            set { side = Math.Abs(value); }
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
                    case PARAM_SIDE:
                        try { Side = Convert.ToDouble(value); }
                        catch { Side = 0; };
                        break;
                }
            }
            area = AreaCalculate(Side);
            perimeter = PerimeterCalculate(Side);
        }

        public double AreaCalculate(double side)//Площадь квадрата
        {
            double area = side * side;
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }
        
        public double PerimeterCalculate(double side)//Периметр квадрата
        {
            double perimeter = side * 4;
            if (double.IsNaN(perimeter))
            {
                return 0;
            }
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
