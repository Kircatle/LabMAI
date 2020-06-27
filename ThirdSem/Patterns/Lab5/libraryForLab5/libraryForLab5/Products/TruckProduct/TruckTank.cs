using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class TruckTank : AbstractProductTank
    {
        public override double MaxVolume => 800;
        public double Volume { get; private set; }
        public override bool Empty => Volume == 0;
        public override double SpeedFactor
        {
            get
            {
                return -0.15 * (Volume / MaxVolume) + 1.1;
            }
        }
        public override string Name => "Бак KAMAZ-5490";
        public override double Price => 300000;
        public override double Weight => 200 + Volume;
        public TruckTank()
        {
            Volume = MaxVolume;
        }
        public override double SpendFuel (double fuel)
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
