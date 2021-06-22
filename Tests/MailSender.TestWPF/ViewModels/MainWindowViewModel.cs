using MailSender.TestWPF.ViewModels.Base;

namespace MailSender.TestWPF.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        //}

        //protected bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        //{
        //    if (Equals(field, value)) return false;
        //    field = value;
        //    OnPropertyChanged(PropertyName);
        //    return true;
        //}

        private string _Title = "Hello World!";

        public int TitleLenght => _Title.Length;

        public string Title
        {
            get => _Title;
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = value;
            //    OnPropertyChanged();
            //    OnPropertyChanged("TitleLenght");
            //}

            set
            {
                if(Set(ref _Title, value));
                    OnPropertyChanged(nameof(TitleLenght));
            }
        }

        private double _LeftPos;
        public double LeftPos
        {
            get => _LeftPos;
            //set
            //{
            //    if (Equals(_LeftPos, value)) return;
            //    _LeftPos = value;
            //    OnPropertyChanged();
            //}

            set
            {
                Set(ref _LeftPos, value);
            }
        }

        private double _TopftPos;
        public double TopftPos { get => _TopftPos; set => Set(ref _TopftPos, value); }
    }
}
