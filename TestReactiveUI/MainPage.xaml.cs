using System.ComponentModel;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;

namespace TestReactiveUI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ReactiveContentPage<MainPageViewModel>
    {
        public MainPage()
        {
            InitializeComponent();

            ViewModel = new MainPageViewModel();
            this.WhenActivated(
               disposable =>
               {
                   this
                       .Bind(ViewModel, vm => vm.FirstValue, v => v.FirstEntry.Text)
                       .DisposeWith(disposable);
                   this
                      .Bind(ViewModel, vm => vm.SecondValue, v => v.SecondEntry.Text)
                      .DisposeWith(disposable);
                   this
                      .OneWayBind(ViewModel, vm => vm.Result, v => v.ResultEntry.Text)
                      .DisposeWith(disposable);
               });
        }
    }
}
