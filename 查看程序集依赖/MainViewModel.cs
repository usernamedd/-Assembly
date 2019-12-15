using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using 查看程序集依赖.Annotations;

namespace 查看程序集依赖
{
    public class MainViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Link> _links=new ObservableCollection<Link>();

        /// <summary>
        /// 所有链接
        /// </summary>
        public ObservableCollection<Link> Links
        {
            get { return _links; }
            set
            {
                _links = value;
                OnPropertyChanged();
            }
        }

        private Link _current;

        /// <summary>
        /// 当前选中的Link
        /// </summary>
        public Link Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnPropertyChanged();
                //更新From列表
                FromNames.Clear();
                var all = Links.ToList().FindAll(lin => lin.To.Name == value.To.Name);
                var allNames = all.Select(l => l.From.Name);
                foreach (var na in allNames)
                {
                    FromNames.Add(na);
                }
            }
        }

        private ObservableCollection<string> _fromNames=new ObservableCollection<string>();

        /// <summary>
        /// 谁引用了我
        /// </summary>
        public ObservableCollection<string> FromNames
        {
            get { return _fromNames; }
            set
            {
                _fromNames = value;
                OnPropertyChanged();
            }
        }

        
        
    }
}