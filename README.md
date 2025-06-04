# 🧩 FindShapes – EPAM Test Task

This is a WPF-based desktop application developed as a test assignment for **EPAM**.

## 📌 Features

- 🗂️ **Open text files** with a custom shape description format
- 💾 **Save** and **edit** shape data in a built-in document editor
- ➕ **Add shapes** with a single click using the UI (Trapezoid, Circle, Rectangle, Triangle, Square)
- 🧮 **Calculate** geometric properties as required by the assignment:
  - Total and average areas
  - Perimeters
  - Shape with the largest area
  - Shape with the highest average perimeter

---

## 📄 Supported Input Format

Each shape is described in its own **block**, using the following syntax (semicolon-separated, not strict JSON):

<pre>
{
"type" : trapezoid;
"side_a" : 1;
"side_b" : 2;
"side_c" : 1;
"side_d" : 3;
}

{
"type" : circle;
"radius" : 10;
}

{
"type" : rectangle;
"width" : 1;
"height" : 1;
}

{
"type" : square;
"side" : 2;
}

{
"type" : triangle;
"side_a" : 1;
"side_b" : 1;
"side_c" : 1;
}
</pre>

- Each block must include a `"type"` field.
- Values can be edited manually or inserted using the corresponding buttons in the UI.

---

## 🧠 Technical Overview

- Written in **C# / WPF** using **MVVM** pattern
- Modular architecture with:
  - Parsers for shape blocks
  - Calculators for area and perimeter
  - Generator for shape templates
- Uses `ICommand` bindings for all UI actions
- Fully unit tested with **NUnit** and **Moq**

---

## ✅ Status

This project is fully functional and ready for demonstration or further development.

---

## 🧪 How to Run

1. Clone the repository
2. Open in **Visual Studio 2022+**
3. Build the solution
4. Run the `FindShapes` WPF application

---

## 📧 Author

Developed by Andrei Samusenka as part of a test task for EPAM Systems.
