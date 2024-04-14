namespace Calculator;

/// <summary>
/// Form for the Calculator application
/// </summary>
public partial class CalculatorForm : Form
{
    private readonly Calculator _calculator = new();

    /// <summary>
    /// Initializing components in the form.
    /// </summary>
    public CalculatorForm()
    {
        InitializeComponent();

        display.DataBindings.Add("Text", _calculator, "Display", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void OnNumberButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;

        _calculator.AddNumberInCalculator(button.Text.First());
    }

    private void OnOperationButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;

        _calculator.AddOperationInCalculator(button.Text.First());
    }

    private void OnEqualButtonClick(object sender, EventArgs e)
    {
        _calculator.Calculate();
    }

    private void OnClearButtonClick(object sender, EventArgs e)
    {
        _calculator.ClearCalculator();
    }

    private void OnChangeSignButtonClick(object sender, EventArgs e)
    {
        _calculator.ChangeSign();
    }
}