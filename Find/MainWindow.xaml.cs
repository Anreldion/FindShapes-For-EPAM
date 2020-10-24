using ClassLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;

namespace Find
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Доступные фигуры
        public const string FIGURE_CIRCLE = СircleClass.FIGURE_TYPE_NAME;
        public const string FIGURE_RECTANGLE = RectangleClass.FIGURE_TYPE_NAME;
        public const string FIGURE_SQUARE = SquareClass.FIGURE_TYPE_NAME;
        public const string FIGURE_TRAPEZOID = TrapezoidClass.FIGURE_TYPE_NAME;
        public const string FIGURE_TRIANGLE = TriangleClass.FIGURE_TYPE_NAME;
        //
        string shapes_folder_path;//Путь к папке с текстовыми файлами


        public MainWindow()
        {
            InitializeComponent();
            WindowInit();//Инициализация рабочей области
            shapes_folder_path = CreateShapesOnAPlaneFolder(); //Создание папки и получение пути к папке.
            path_to_file_textbox.Text = shapes_folder_path; //Отображаем путь к папке в Textbox
        }

        //Инициализация рабочей области
        void WindowInit()
        {
            //Очистка и настройка документа
            editor_richtextbox.Document.Blocks.Clear();
            FlowDocument fd = new FlowDocument() { LineStackingStrategy = LineStackingStrategy.BlockLineHeight, LineHeight = 15, FontSize = 12 };
            Paragraph par = new Paragraph
            {
                Margin = new Thickness(0)
            };
            fd.Blocks.Add(par);
            editor_richtextbox.Document = fd;
            editor_richtextbox.CaretPosition = editor_richtextbox.Document.ContentStart;

            //Удаление расчетных значений
            ClearAnswer();
        }
        //Очистка поля с ответами
        void ClearAnswer()
        {
            deltaPerimeterTextBlock.Text = String.Format("Cредний периметр: -");
            deltaAreaTextBlock.Text = String.Format("Cредняя площадь: -");
            maxAreaTypeFigureTextBlock.Text = String.Format("Фигура наибольшей площади: - ");
            maxDeltaPerimeterTypeFigureTextBlock.Text = String.Format("Тип фигуры с наибольшим средним периметром: -");
        }


        //**********************************************************************************************
        // РАЗБОР ДОКУМЕНТА
        //**********************************************************************************************
        /// <summary>
        /// Получение данных из документа.
        /// </summary>
        /// <param name="document"></param>
        void DataParcer(FlowDocument document)
        {
            List<FigureClass> Shapes = new List<FigureClass> { }; //Список фигур в документе.
            List<string> blocks = new List<string> { }; //Промежуточный список для хранения блоков с параметрами для каждой фигуры.
            List<DeltaShapesValueClass> deltaShapes = new List<DeltaShapesValueClass>();//Список для расчета средних значений периметра и площади для каждого типа фигур.

            //0. Преобразуем документ в строку
            String input = new TextRange(document.ContentStart, document.ContentEnd).Text;
            input = Regex.Replace(input, @"[ \r\n\t]", ""); //Избавляемся от пробелов, переносов.
            input = input.ToLower();//Переводим в нижний регистр

            //Патерн для разбиения строки на блоки.
            String pattern = @"\{([^\{\}]+)\}";     //где, \{	Совпадение с открывающей скобкой. 
                                                    // ([^\{\}]+)  Совпадение с любым символом, который не является открывающей или закрывающей круглой скобкой один или несколько раз. 
                                                    // \}   Совпадение с закрывающей скобкой

            //1. Извлечение блоков из строки на основе шаблона
            foreach (Match match in Regex.Matches(input, pattern))
            {
                blocks.Add(match.Groups[1].Value);
            }
            //Количество элементов больше 0?
            if (blocks.Count == 0)
            {
                ClearAnswer();
                return;//Пусто. Выход
            }


            //2. Извлечение данных из блоков
            foreach (var item in blocks)
            {
                string type = "";
                //2.1. Существует ли параметр типа фигуры в строке
                if (item.IndexOf("type") == -1) //не существует
                {
                    //Удаляем элемент из списка.
                    blocks.Remove(item);
                    continue;
                }

                //2.2. Разбиение блока на массив строк с параметрами.
                string[] parameters = item.Split(';', StringSplitOptions.RemoveEmptyEntries);

                //2.3. Определение типа фигуры
                foreach (var array_element in parameters)
                {
                    //Ищем параметр type
                    if (array_element.IndexOf("type") == -1) //не тот параметр
                    {
                        continue;//Далее
                    }
                    else//Нашли
                    {
                        type = GetType(array_element); //Проверяем, определен ли данный тип фигуры
                        break;
                    }
                }

                if (type == "")//Тип фигуры не определен
                {
                    //Удаляем элемент из списка.
                    blocks.Remove(item);
                    continue;
                }

                //3. Получаем остальные параметры. Для каждого типа фигуры свой набор параметров.
                switch (type)
                {
                    case FIGURE_CIRCLE:
                        СircleClass circle = new СircleClass(); 
                        circle.ParceParameters(parameters);//Разбор параметров и рассчет значений площади и периметра.
                        Shapes.Add(circle); //Добавляем элемент в список фигур
                        DeltaShapes_AddTypeIfDoesnotExist(FIGURE_CIRCLE, deltaShapes); //Добавить тип фигуры в список используемых фигур.
                        break;

                    case FIGURE_RECTANGLE:
                        RectangleClass rectangle = new RectangleClass();
                        rectangle.ParceParameters(parameters);
                        Shapes.Add(rectangle);
                        DeltaShapes_AddTypeIfDoesnotExist(FIGURE_RECTANGLE, deltaShapes);
                        break;

                    case FIGURE_SQUARE:
                        SquareClass square = new SquareClass();
                        square.ParceParameters(parameters);
                        Shapes.Add(square);
                        DeltaShapes_AddTypeIfDoesnotExist(FIGURE_SQUARE, deltaShapes);
                        break;

                    case FIGURE_TRAPEZOID:
                        TrapezoidClass trapezoid = new TrapezoidClass();
                        trapezoid.ParceParameters(parameters);
                        Shapes.Add(trapezoid);
                        DeltaShapes_AddTypeIfDoesnotExist(FIGURE_TRAPEZOID, deltaShapes);
                        break;

                    case FIGURE_TRIANGLE:
                        TriangleClass triangle = new TriangleClass();
                        triangle.ParceParameters(parameters);
                        Shapes.Add(triangle);
                        DeltaShapes_AddTypeIfDoesnotExist(FIGURE_TRIANGLE, deltaShapes);
                        break;
                }
            }

            //По заданию, неоходимо найти:
            //1. Средний периметр и площадь всех фигур
            //2. Фигура наибольшей площади
            //3. Тип фигуры с наибольшим значением среднего периметра среди всех других типов фигур.

            double deltaPerimeter = 0; //Средний периметр
            double deltaArea = 0; //Средняя площадь
            
            double maxArea = 0; //Значение площади
            string maxAreaTypeFigure = "Пусто"; //Тип фигуры
            
            double maxDeltaPerimeter = 0; //Наибольший средний периметр
            string maxDeltaPerimeterTypeFigure = "Пусто"; //Тип фигуры с наибольшим средним периметром

            //Находим.
            foreach (var figure in Shapes)
            {
                //Получаем значения периметра и площади для каждой фигуры
                deltaPerimeter += figure.PerimeterGet();
                deltaArea += figure.AreaGet();

                //Ищем фигуру наибольшей площади
                if (maxArea < figure.AreaGet())
                {
                    maxArea = figure.AreaGet();
                    maxAreaTypeFigure = figure.TypeGet();
                }
                //Увеличить среднее значение площади и периметра для конкретного типа фигур
                DeltaShapes_AddTypeItem(figure.TypeGet(), figure.PerimeterGet(), figure.AreaGet(), deltaShapes);
            }
            //Расчет среднего значения периметра и площади всех фигур
            deltaPerimeter /= Shapes.Count;
            deltaArea /= Shapes.Count;
            //Расчет среднего значения периметра и площади для каждого типа фигур
            DeltaShapes_CalculateDelta(deltaShapes);
            //Ищем тип фигуры с наибольшим значением среднего периметра среди всех других типов фигур
            foreach (var item in deltaShapes)
            {
                if (maxDeltaPerimeter < item.Perimeter)
                {
                    maxDeltaPerimeter = item.Perimeter;
                    maxDeltaPerimeterTypeFigure = item.Type;
                }
            }

            //Отображаем ответ
            deltaPerimeterTextBlock.Text = String.Format("Cредний периметр: {0:f2}(м)", deltaPerimeter);
            deltaAreaTextBlock.Text = String.Format("Cредняя площадь: {0:f2} (кв.м)", deltaArea);
            maxAreaTypeFigureTextBlock.Text = String.Format("Фигура наибольшей площади: {0} ({1:f2}кв.м)", maxAreaTypeFigure, maxArea);
            maxDeltaPerimeterTypeFigureTextBlock.Text = String.Format("Тип фигуры с наибольшим средним периметром: {0} ({1:f2}м)", maxDeltaPerimeterTypeFigure, maxDeltaPerimeter);
        }

        /// <summary>
        /// Получить тип фигуры из блока
        /// </summary>
        /// <param name="param"></param>
        /// <returns>Тип фигуры. Если указанный тип не существует, возвращает ""</returns>
        string GetType(string param)
        {
            string type = param.Split(new char[] { ':' })[1]; //Получаем тип
            //Есть ли такой тип фигуры 
            switch (type)
            {
                case FIGURE_CIRCLE:
                case FIGURE_RECTANGLE:
                case FIGURE_SQUARE:
                case FIGURE_TRAPEZOID:
                case FIGURE_TRIANGLE:
                    return type;
            }
            return "";
        }


        /// <summary>
        /// Класс используемый для нахождения типа фигуры с наибольшим значением среднего периметра среди всех других типов фигур.
        /// </summary>
        public class DeltaShapesValueClass
        {
            public DeltaShapesValueClass()
            {
                Type = "";
                Area = 0;
                Perimeter = 0;
                Counter = 0;
            }

            public string Type { get; set; }
            public double Area { get; set; }
            public double Perimeter { get; set; }
            public double Counter { get; set; }
        }



        /// <summary>
        /// Добавить тип фигуры в список используемых фигур.
        /// </summary>
        /// <param name="type">Тип фигуры.</param>
        /// <param name="deltaShapes">Список</param>
        void DeltaShapes_AddTypeIfDoesnotExist(string type, List<DeltaShapesValueClass> deltaShapes)
        {
            foreach (var item in deltaShapes)
            {
                if (item.Type == type)
                {
                    return;
                }
            }
            deltaShapes.Add(new DeltaShapesValueClass { Type = type });
        }
        
        /// <summary>
        /// Увеличить среднее значение площади и периметра типа фигур
        /// </summary>
        /// <param name="type"></param>
        /// <param name="perimeter"></param>
        /// <param name="area"></param>
        /// <param name="deltaShapes"></param>
        void DeltaShapes_AddTypeItem(string type, double perimeter, double area, List<DeltaShapesValueClass> deltaShapes)
        {
            foreach (var item in deltaShapes)
            {
                if (item.Type == type)
                {
                    item.Perimeter += perimeter;
                    item.Area += area;
                    item.Counter++;
                    return;
                }
            }
        }
        /// <summary>
        /// Расчет среднего значения периметра и площади
        /// </summary>
        /// <param name="deltaShapes"></param>
        void DeltaShapes_CalculateDelta(List<DeltaShapesValueClass> deltaShapes)
        {
            foreach (var item in deltaShapes)
            {
                item.Perimeter /= item.Counter;
                item.Area /= item.Counter;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            DataParcer(editor_richtextbox.Document);
        }

        //**********************************************************************************************
        //ДОБАВЛЕНИЕ ФИГУР В ДОКУМЕНТ
        //**********************************************************************************************
        private void AddTrapezoidButton_Click(object sender, RoutedEventArgs e)
        {
            editor_richtextbox.Focus();

            editor_richtextbox.AppendText("{\r\n");
            editor_richtextbox.AppendText("\"type\" : trapezoid;\r\n");
            editor_richtextbox.AppendText("\"side_a\" : 1;\r\n");
            editor_richtextbox.AppendText("\"side_b\" : 2;\r\n");
            editor_richtextbox.AppendText("\"side_c\" : 1;\r\n");
            editor_richtextbox.AppendText("\"side_d\" : 3;\r\n");
            editor_richtextbox.AppendText("}\r\n");

            editor_richtextbox.CaretPosition = editor_richtextbox.Document.ContentEnd;
        }

        private void AddСircleButton_Click(object sender, RoutedEventArgs e)
        {
            editor_richtextbox.Focus();

            editor_richtextbox.AppendText("{\r\n");
            editor_richtextbox.AppendText("\"type\" : circle;\r\n");
            editor_richtextbox.AppendText("\"radius\" : 10;\r\n");
            editor_richtextbox.AppendText("}\r\n");

            editor_richtextbox.CaretPosition = editor_richtextbox.Document.ContentEnd;
        }

        private void AddRectangleButton_Click(object sender, RoutedEventArgs e)
        {
            editor_richtextbox.Focus();

            editor_richtextbox.AppendText("{\r\n");
            editor_richtextbox.AppendText("\"type\" : rectangle;\r\n");
            editor_richtextbox.AppendText("\"width\" : 1;\r\n");
            editor_richtextbox.AppendText("\"height\" : 1;\r\n");
            editor_richtextbox.AppendText("}\r\n");

            editor_richtextbox.CaretPosition = editor_richtextbox.Document.ContentEnd;
        }

        private void AddSquareButton_Click(object sender, RoutedEventArgs e)
        {
            editor_richtextbox.Focus();

            editor_richtextbox.AppendText("{\r\n");
            editor_richtextbox.AppendText("\"type\" : square;\r\n");
            editor_richtextbox.AppendText("\"side\" : 2;\r\n");
            editor_richtextbox.AppendText("}\r\n");

            editor_richtextbox.CaretPosition = editor_richtextbox.Document.ContentEnd;
        }

        private void AddTriangleButton_Click(object sender, RoutedEventArgs e)
        {
            editor_richtextbox.Focus();

            editor_richtextbox.AppendText("{ \r\n");
            editor_richtextbox.AppendText("\"type\" : triangle;\r\n");
            editor_richtextbox.AppendText("\"side_a\" : 1;\r\n");
            editor_richtextbox.AppendText("\"side_b\" : 1;\r\n");
            editor_richtextbox.AppendText("\"side_c\" : 1;\r\n");
            editor_richtextbox.AppendText("}\r\n");

            editor_richtextbox.CaretPosition = editor_richtextbox.Document.ContentEnd;
        }

        //Очистка окна.
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            WindowInit();
        }
        //Открыть документ
        private void OpenDocument_button_Click(object sender, RoutedEventArgs e)
        {
            OpenDocument();
        }
        private void SaveFile_button_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }


        //**********************************************************************************************
        //РАБОТА С ПАПКАМИ И ФАЙЛАМИ
        //**********************************************************************************************

        /// <summary>
        /// Создать папку Shapes on a plane в базовой директории программы
        /// </summary>
        /// <returns></returns>
        public string CreateShapesOnAPlaneFolder()
        {
            string basepath = AppDomain.CurrentDomain.BaseDirectory;
            string path = System.IO.Path.Combine(basepath, "Shapes on a plane"); //Фигуры на плоскости
            CreateFolder(path);
            return path;
        }

        /// <summary>
        /// Создать папку, если не существует
        /// </summary>
        /// <param name="path">Путь по которому будет создана папка</param>
        /// <returns></returns>
        public bool CreateFolder(string path)
        {
            if (!Directory.Exists(path))//Проверяем, не создан ли данный путь в предыдущие запуски программы.
            {
                try//Путь пока не создан... 
                {
                    Directory.CreateDirectory(path); //Пытаемся создать папку:
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);//В случае ошибок ввода-вывода выдаем сообщение об ошибке
                    throw ex;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(ex.Message);//В случае ошибки с нехваткой прав вновь выдаем сообщение:
                    throw ex;
                }
            }
            return true;
        }

        /// <summary>
        /// Открыть документ .sop содержащий описание фигур.
        /// </summary>
        void OpenDocument()
        {
            OpenFileDialog window = new OpenFileDialog
            {
                Filter = "Текстовый файл (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = shapes_folder_path,
                Title = "Выберите файл содержащий список фигур на плоскости"
            };
            if (window.ShowDialog() == true)
            {
                path_to_file_textbox.Text = window.FileName;
                FlowDocument fd = new FlowDocument() { LineStackingStrategy = LineStackingStrategy.BlockLineHeight, LineHeight = 15, FontSize = 12 };
                Paragraph par = new Paragraph
                {
                    Margin = new Thickness(0) //убираем интервалы
                };
                using (StreamReader sr = new StreamReader(File.Open(window.FileName, FileMode.Open)))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        par.Inlines.Add(line);
                        par.Inlines.Add(new LineBreak());
                    }
                }
                fd.Blocks.Add(par);

                editor_richtextbox.Document = fd;
            }
        }
        /// <summary>
        /// Сохранить как тектовый документ
        /// </summary>
        void SaveFile()
        {
            SaveFileDialog window = new SaveFileDialog
            {
                FileName = "Plane",
                OverwritePrompt = true,
                Filter = "Текстовый файл (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = shapes_folder_path,
                Title = "Сохранить файл"
            };
            if (window.ShowDialog() == true)
            {
                path_to_file_textbox.Text = window.FileName;
                string RichTextBox1Text = new TextRange(editor_richtextbox.Document.ContentStart, editor_richtextbox.Document.ContentEnd).Text;

                StreamWriter sw = new StreamWriter(window.FileName);
                sw.Write(RichTextBox1Text);
                sw.Close();
            }

        }

        
    }
}
