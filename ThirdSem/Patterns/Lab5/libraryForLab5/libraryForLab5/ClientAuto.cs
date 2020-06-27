using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryForLab5
{
    public class ClientAuto
    {
        //Корпус машины
		public AbstractProductBody Body { get; }

        //Двигатель машины
        public AbstractProductEngine Engine { get; }

        //Бак машины
        public AbstractProductTank Tank { get; }

        //Цена
        public double Price
        {
            get
            {
                if (Body != null && Engine != null && Tank != null)
                {
                    return (Body.Price + Engine.Price + Tank.Price) * 1.5;
                }
                else
                {
                    return 0;
                }
            }
        }

        //Вес
        public double Weight
        {
            get
            {
                if (Body != null && Engine != null && Tank != null)
                {
                    if (Body.Weight + Engine.Weight + Tank.Weight <= Body.MaxWeight)
                    {
                        return Body.Weight + Engine.Weight + Tank.Weight;
                    }
                    else
                    {
                        throw new Exception("Вес автомобиля превысил максимально возможный.");
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        //Событие движение
        public event EventHandler<double> Moved;


        public ClientAuto(AbstractFactoryAuto factory)
        {
            Body = factory.CreateBody();
            Engine = factory.CreateEngine();
            Tank = factory.CreateTank();
        }


        //Движение
        public double Start(double speed)
        {
            if (Weight > Body.MaxWeight)
            {
                throw new Exception("Вес автомобиля больше максимального. Движение не возможно.");
            }

            var path = 0.0;
            while (!Tank.Empty)
            {
                path += Step(speed);
                Moved?.Invoke(this, path);
            }

            return path;
        }

        //Расчет пройденного пути за шаг
        protected double Step(double speed)
        {
            var actualSpeed = speed < Engine.MaxSpeed ? speed : Engine.MaxSpeed;
            actualSpeed *= Body.Aerodynamic;
            actualSpeed *= Tank.SpeedFactor;
            var needFuel = Engine.GetFuel(actualSpeed);
            var pathRate = Tank.SpendFuel (needFuel);
            var path = actualSpeed * pathRate;
            return path;
        }
    }
}
