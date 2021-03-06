using System.Collections.ObjectModel;
using miRobotEditor.Abstract;

namespace miRobotEditor.ViewModel
{
// ReSharper disable once UnusedMember.Global
    public class FTPAccountWindowViewModel : ToolViewModel
    {
        private readonly ObservableCollection<FTPAccount> _accounts = new ObservableCollection<FTPAccount>();
        private readonly ReadOnlyObservableCollection<FTPAccount> _readonlyAccounts = null;

        public FTPAccountWindowViewModel()
            : base("FTP Accounts")
        {
        }

        public ReadOnlyObservableCollection<FTPAccount> Accounts
        {
            get { return _readonlyAccounts ?? new ReadOnlyObservableCollection<FTPAccount>(_accounts); }
        }
    }
}