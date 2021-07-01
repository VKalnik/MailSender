using System.Threading;

namespace HomeWork_5
{
    internal class CalculationFactorialTask
    {
        private readonly Thread _Thread;
        private readonly int _Number;
        private int _Result;

        public int Result
        {
            get
            {
                Join();
                return _Result;
            }
            private set => _Result = value;
        }

        public CalculationFactorialTask(int Number)
        {
            _Number = Number;
            _Thread = new Thread(Calculation);
        }

        public void Start() => _Thread.Start();

        private void Calculation()
        {
            int factorial = 1;
            for (int i = 2; i <= _Number; i++)
            {
                factorial = factorial * i;
            }
            _Result = factorial;
        }

        public void Join() => _Thread.Join();
    }
}
