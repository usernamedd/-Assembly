using System.ComponentModel;
using System.Runtime.CompilerServices;
using 查看程序集依赖.Annotations;

namespace 查看程序集依赖
{
    public class Link:INotifyPropertyChanged
    {
        //public AssemblyInfo From { get; set; }
        //public AssemblyInfo To { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private AssemblyInfo _from;

        /// <summary>
        /// From
        /// </summary>
        public AssemblyInfo From
        {
            get { return _from; }
            set
            {
                _from = value;
                OnPropertyChanged();
            }
        }

        private AssemblyInfo _to;

        /// <summary>
        /// To
        /// </summary>
        public AssemblyInfo To
        {
            get { return _to; }
            set
            {
                _to = value;
                OnPropertyChanged();
            }
        }

        
    }
}