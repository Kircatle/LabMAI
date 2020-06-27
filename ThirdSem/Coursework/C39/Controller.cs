using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace C39
{
    public class Controller
    {
        private string function;
        private Swarm model;
        private View view;

        public Controller(View view, Swarm model)
        {
            this.model = model;
            this.view = view;
        }
        /// <summary>
        /// Создает функцию из строки
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public Func<double,double> CreateFunction(string function)
        {
            this.function = function;
            return Function;
        }

        public double Function(double x)
        {
            return MathParser.Result(function, x);
        }


        /// <summary>
        /// Запуск модели
        /// </summary>
        /// <param name="iter"></param>
        public void StartOptimization(int iter)
        {
            model.StartOptimization(iter);
        }

        /// <summary>
        /// Создание роя
        /// </summary>
        /// <param name="swarmsize"></param>
        /// <param name="distance1"></param>
        /// <param name="distance2"></param>
        /// <param name="function"></param>
        public void CreateSwarm(int swarmsize, double distance1, double distance2, Func<double, double> function)
        {
            Random rnd = new Random();
            model.AttachSwarm(swarmsize, distance1, distance2, function, rnd);
        }

        /// <summary>
        /// Возвращает состояние системы
        /// </summary>
        /// <returns></returns>
        public List<double[]> Position()
        {
            return model.Position();
        }

        /// <summary>
        /// Возвращает лучшее положение системы
        /// </summary>
        /// <returns></returns>
        public double Best()
        {
            return model.Best;
        }

        /// <summary>
        /// Останавливает работу алгоритма
        /// </summary>
        public void Stop()
        {
            model.StopOptimization();
        }

    }
}