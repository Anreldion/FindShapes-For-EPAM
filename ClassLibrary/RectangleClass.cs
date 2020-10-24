using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class RectangleClass : FigureClass
    {
        public const string FIGURE_TYPE_NAME = "rectangle";
        const string PARAM_WIDTH = "width";
        const string PARAM_HEIGHT = "height";
        double width;   //Ширина прямоугольника
        double height;   //Высота прямоугольника
        double perimeter; //Периметр
        double area; //Площадь
        public RectangleClass()
        {
            width = 0;
            height = 0;
            perimeter = 0;
            area = 0;
        }
        public double Width
        {
            get { return width; }
            set { width = Math.Abs(value); }
        }
        public double Height
        {
            get { return height; }
            set { height = Math.Abs(value); }
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
                    case PARAM_WIDTH:
                        try { Width = value; }
                        catch { Width = 0; };
                        break;

                    case PARAM_HEIGHT:
                        try { Height = value; }
                        catch { Height = 0; }
                        break;
                }
            }
            area = AreaCalculate(Width, Height);
            perimeter = PerimeterCalculate(Width, Height);
        }

        public double AreaCalculate(double width, double height)//Площадь прямоугольника
        {
            double area = width * height;
            if (double.IsNaN(area))
            {
                return 0;
            }
            return area;
        }

        public double PerimeterCalculate(double width, double height)//Периметр прямоугольника
        {
            double perimeter = 2*(width + height);
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
