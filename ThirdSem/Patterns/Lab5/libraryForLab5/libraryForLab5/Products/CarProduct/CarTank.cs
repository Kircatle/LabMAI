using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class CarTank : AbstractProductTank
    {
		public override double MaxVolume => 30;
        public double Volume { get; private set; }
        public override bool Empty => Volume == 0;
        public override double SpeedFactor
        {
            get
            {
                var currentVolumePercent = Volume / MaxVolume;
                return -0.4 * currentVolumePercent + 1.2;
            }
        }

        public override string Name => "Бак ВАЗ-1111";
        public override double Price => 20000;
        public override double Weight => 45 + Volume;


        public CarTank()
        {
            Volume = MaxVolume;
        }


        public override double SpendFuel(double fuel)
        {
            if (fuel <= Volume)
            {
                Volume -= fuel;
                return 1;
            }
            else
            {
                var wayPercent = Volume / fuel;
                Volume = 0;
                return wayPercent;
            }
        }
    }
}
