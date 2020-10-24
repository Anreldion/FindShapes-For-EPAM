using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class СircleClass : FigureClass
    {
        public const string FIGURE_TYPE_NAME = "circle";
        const string PARAM_RADIUS = "radius";

        double radius; //Радиус окружности
        double perimeter; //Периметр
        double area; //Площадь
        public СircleClass()
        {
            radius = 0;
            perimeter = 0;
            area = 0;
        }
        public double Radius
        {
            get { return radius; }
            set { radius = Math.Abs(value); }
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
                    case PARAM_RADIUS:
                        try { Radius = Convert.ToDouble(value); }
                        catch { Radius = 0; };
                        break;
                }
            }
            area = AreaCalculate(Radius);
            perimeter = PerimeterCalculate(Radius);
        }

        public double AreaCalculate(double radius)//Площадь окружности
        {
            double area = Math.PI * (radius * radius);
            if (double.IsNaN(perimeter))
            {
                return 0;
            }
            return area;
        }

        public double PerimeterCalculate(double radius)//Периметр окружности
        {
            double perimeter = 2 * Math.PI * radius;
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
