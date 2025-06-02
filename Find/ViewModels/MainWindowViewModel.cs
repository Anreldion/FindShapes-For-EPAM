using System.Windows.Input;
using System;
using Find.Services.Interfaces;
using ShapeLib.Calculators;
using ShapeLib.Generators;
using ShapeLib.Parsers;
using Find.Services.enums;

namespace Find.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand AddRectangleCommand { get; }
        public ICommand AddSquareCommand { get; }
        public ICommand AddTrapezoidCommand { get; }
        public ICommand AddCircleCommand { get; }
        public ICommand AddTriangleCommand { get; }
        public ICommand CalculateCommand { get; }
        public ICommand CloseAppCommand { get; }
        public ICommand ShowAboutCommand { get; }

        public string PlainText
        {
            get => _plainText;
            set
            {
                _plainText = value;
                HasUnsavedChanges = true;
                OnPropertyChanged();
            }
        }

        public string AveragePerimeter
        {
            get => _averagePerimeter;
            set
            {
                _averagePerimeter = value;
                OnPropertyChanged();
            }
        }

        public string AverageArea
        {
            get => _averageArea;
            set
            {
                _averageArea = value;
                OnPropertyChanged();
            }
        }

        public string LargestAreaShape
        {
            get => _largestAreaShape;
            set
            {
                _largestAreaShape = value;
                OnPropertyChanged();
            }
        }

        public string ShapeWithMaxAveragePerimeter
        {
            get => _shapeWithMaxAveragePerimeter;
            set
            {
                _shapeWithMaxAveragePerimeter = value;
                OnPropertyChanged();
            }
        }

        public string ShapesFolderPath
        {
            get => _shapesFolderPath;
            set
            {
                _shapesFolderPath = value;
                OnPropertyChanged();
            }
        }

        public string ShapesFilePath
        {
            get => _shapesFilePath;
            set
            {
                _shapesFilePath = value;
                OnPropertyChanged();
            }
        }
        
        public bool HasUnsavedChanges
        {
            get => _hasUnsavedChanges;
            set
            {
                _hasUnsavedChanges = value;
                OnPropertyChanged();
            }
        }

        private string _averagePerimeter;
        private string _averageArea;
        private string _largestAreaShape;
        private string _shapeWithMaxAveragePerimeter;
        private string _plainText;
        private string _shapesFolderPath;
        private string _shapesFilePath;
        private readonly IWindowService _windowService;
        private readonly IShapeTextGenerator _shapeTextGenerator;
        private readonly IFileDialogService _fileDialogService;
        private readonly IShapeCalculator _shapeCalculator;
        private readonly IFileService _fileService;
        private readonly IShapeParser _shapeParser;
        private readonly IDialogService _dialogService;
        private bool _hasUnsavedChanges;


        public MainWindowViewModel(IShapeCalculator calculator, IShapeParser parser,
            IShapeTextGenerator textGenerator, IFileDialogService fileDialogService,
            IFileService fileService, IFolderService folderService, IWindowService windowService, IDialogService dialogService)
        {
            _shapeTextGenerator = textGenerator;
            _shapeCalculator = calculator;
            _fileService = fileService;
            _fileDialogService = fileDialogService;
            _shapeParser = parser;
            _windowService = windowService;
            _dialogService = dialogService;

            OpenCommand = new RelayCommand(_ => Open());
            SaveCommand = new RelayCommand(_ => Save());
            SaveAsCommand = new RelayCommand(_ => SaveAs());
            CalculateCommand = new RelayCommand(_ => Calculate());
            ClearCommand = new RelayCommand(_ => Clear());
            ShowAboutCommand = new RelayCommand(_ => ShowAbout());

            AddRectangleCommand = new RelayCommand(_ => AddShape("rectangle"));
            AddCircleCommand = new RelayCommand(_ => AddShape("circle"));
            AddSquareCommand = new RelayCommand(_ => AddShape("square"));
            AddTrapezoidCommand = new RelayCommand(_ => AddShape("trapezoid"));
            AddTriangleCommand = new RelayCommand(_ => AddShape("triangle"));
            CloseAppCommand = new RelayCommand(_ => CloseApp());

            ShapesFolderPath = folderService.CreateFolderInBaseDirectory("Shapes");

            Clear();
        }

        private void ShowAbout()
        {
            _windowService.ShowDialog<AboutViewModel>();
        }
        private void CloseApp()
        {
            if (!HasUnsavedChanges)
            {
                Environment.Exit(0);
            }

            var result = _dialogService.AskSaveConfirmation();
            switch (result)
            {
                case UnsavedChangesResult.Save:
                    Save();
                    break;
                case UnsavedChangesResult.DontSave:
                    Environment.Exit(0);
                    break;
                case UnsavedChangesResult.Cancel:
                    break;
            }
        }

        private void AddShape(string shapeType)
        {
            PlainText += _shapeTextGenerator.Generate(shapeType) + Environment.NewLine;
        }

        private void Calculate()
        {
            var shapes = _shapeParser.Parse(PlainText);
            if (shapes == null || shapes.Count == 0)
            {
                _dialogService.ShowError("Nothing to calculate! Please check input","Error");
                return;
            }

            var largestAreaShape = _shapeCalculator.GetLargestAreaShape(shapes);
            var averagePerimeter = _shapeCalculator.GetAveragePerimeter(shapes);
            var areaSum = _shapeCalculator.GetAreaSum(shapes);
            var shapeWithMaxAveragePerimeter = _shapeCalculator.GetShapeWithMaxAveragePerimeter(shapes);


            AveragePerimeter = $"{averagePerimeter:f2}(m)";
            AverageArea = $"{areaSum:f2} (sq.m)";
            LargestAreaShape = $"{largestAreaShape.Name} ({largestAreaShape.GetArea():f2}sq.m)";
            ShapeWithMaxAveragePerimeter = $"{shapeWithMaxAveragePerimeter.Key} ({shapeWithMaxAveragePerimeter.Value:f2}m)";
        }

        private void Clear()
        {
            PlainText = string.Empty;
            AveragePerimeter = "0";
            AverageArea = "0";
            LargestAreaShape = "0";
            ShapeWithMaxAveragePerimeter = "0";
        }

        private void Open()
        {
            var openPath = string.IsNullOrEmpty(ShapesFilePath) ? ShapesFolderPath : ShapesFilePath;

            var path = _fileDialogService.OpenFileDialog("Text file (*.txt)|*.txt|All files (*.*)|*.*", openPath,
                "Select the file containing the list of shapes");
            if (string.IsNullOrEmpty(path)) return;

            ShapesFilePath = path;
            PlainText = _fileService.ReadFile(path);
        }

        private void Save()
        {
            if (string.IsNullOrEmpty(ShapesFilePath))
            {
                SaveAs();
            }
            else
            {
                _fileService.WriteFile(ShapesFilePath, PlainText);
            }
        }

        private void SaveAs()
        {
            var path = _fileDialogService.SaveAsFileDialog("Shapes", ShapesFolderPath, "Text file (*.txt)|*.txt|All files (*.*)|*.*",
                "Save file");
            if (string.IsNullOrEmpty(path)) return;

            ShapesFilePath = path;
            _fileService.WriteFile(path, PlainText);
        }
    }
}
