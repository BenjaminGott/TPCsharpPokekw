using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpCsharpPoKEKW.MVVM.ViewModel
{
    //la main windows inclue tout les vue -- c'est la bordurde de l'ap (balise HTML en html
    internal class MainWindowVM : BaseVM
    {
        static public Action<BaseVM> OnRequestVMChange;

        #region Commands
        #endregion
        #region Variables

        private BaseVM _currentVM;
        public BaseVM CurrentVM
        {
            get => _currentVM;
            set
            {
                SetProperty(ref _currentVM, value);
                OnPropertyChanged(nameof(CurrentVM));
            }
        }

        #endregion

        public MainWindowVM()
        {
            MainWindowVM.OnRequestVMChange += HandleRequestViewChange;
            MainWindowVM.OnRequestVMChange?.Invoke(new MainViewVM());

        }

        public void HandleRequestViewChange(BaseVM a_VMToChange)
        { 
            CurrentVM = a_VMToChange;
            
        }
    }
}
