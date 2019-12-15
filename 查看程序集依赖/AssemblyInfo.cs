using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using 查看程序集依赖.Annotations;

namespace 查看程序集依赖
{
    public class AssemblyInfo:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _version;

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AssemblyInfo> _dependencyAssemblyInfos;

        /// <summary>
        /// 依赖项
        /// </summary>
        public ObservableCollection<AssemblyInfo> DependencyAssemblyInfos
        {
            get { return _dependencyAssemblyInfos; }
            set
            {
                _dependencyAssemblyInfos = value;
                OnPropertyChanged();
            }
        }

        
    }
}