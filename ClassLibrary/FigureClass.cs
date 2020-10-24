using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class FigureClass
    {
        public abstract double AreaGet();
        public abstract double PerimeterGet();
        public abstract string TypeGet();
        public abstract void ParceParameters(string[] parameters);

    }
}
