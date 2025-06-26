using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorIntServerDemo.Demos;

public class UserContext: INotifyPropertyChanged
{

    private Guid _userId { get; set; }
    private string _name { get; set; }

    public Guid UserId
    {
        get { return _userId; }
        set
        {
            _userId = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public event PropertyChangedEventHandler? PropertyChanging;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
