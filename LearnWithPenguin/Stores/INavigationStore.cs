using LearnWithPenguin.ViewModel;

namespace LearnWithPenguin.Stores
{
    public interface INavigationStore
    {
        BaseViewModel CurrentViewModel { set; }
    }
}