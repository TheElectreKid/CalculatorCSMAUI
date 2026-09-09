using Microsoft.Extensions.DependencyInjection;


namespace MauiAppCalculator;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState) {
		//====
			var window = new Window(new AppShell());

			#if WINDOWS
			const int width = 800;
			const int height = 600;

			window.Width = width;
			window.Height = height;

			window.HandlerChanged += (sender, e) => {
				var nativeWindow = window.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
				if (nativeWindow != null) {
					var appWindow = nativeWindow.AppWindow;
					var presenter = appWindow.Presenter as Microsoft.UI.Windowing.OverlappedPresenter;
					
					if (presenter != null) {
						presenter.IsResizable = false;
						presenter.IsMaximizable = false;
					}
				}
			};
			#endif
		
		return window;
		//====
	}
}