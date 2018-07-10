using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using GraphingAlgorithms.GraphObjects;

namespace GraphingAlgorithmsUI.ViewModels
{
    public interface ICartesianPointViewModel
    {
        double X { get; set; }
        double Y { get; set; }
    }

    public class CartesianPointViewModel : PropertyChangedBase, ICartesianPointViewModel
    {
        readonly ICartesianPoint _cartesianPoint;
        private double _x;
        private double _y;

        public CartesianPointViewModel(ICartesianPoint cartesianPoint)
        {
            _cartesianPoint = cartesianPoint;
            _x = _cartesianPoint.X;
            _y = _cartesianPoint.Y;
        }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                NotifyOfPropertyChange(() => X);
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                NotifyOfPropertyChange(() => Y);
            }
        }
    }
}