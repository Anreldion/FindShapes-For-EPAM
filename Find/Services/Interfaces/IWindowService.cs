namespace Find.Services.Interfaces
{
    public interface IWindowService
    {
        void ShowDialog<TViewModel>() where TViewModel : class;
    }
}
