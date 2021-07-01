using System.Threading;

namespace HomeWork_5
{
    internal class CalculationSumTask
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

        public CalculationSumTask(int Number)
        {
            _Number = Number;
            _Thread = new Thread(Calculation);
        }

        public void Start() => _Thread.Start();

        private void Calculation()
        {
            var sum = 0;
            for (var i = 1; i < _Number; i++)
            {
                sum += i;
            }

            _Result = sum;
        }

        public void Join() => _Thread.Join();
    }
}
