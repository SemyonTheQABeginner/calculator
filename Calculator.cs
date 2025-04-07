namespace hueta;

public class Calculator
{
    private enum Stav
    {
        PrvniCislo,
        Operace,
        DruheCislo,
        Vysledek
    }

    private Stav _stav = Stav.PrvniCislo;

    private string _display = "0";
    private string _pamet = "";
    private double _prvni = 0;
    private double _druhe = 0;
    private string _operace = "";
    private double _ulozenaHodnota = 0;

    public string Display => _display;
    public string Pamet => _pamet;

    public void Tlacitko(string vstup)
    {
        switch (vstup)
        {
            case "C":
                _display = "0";
                _stav = Stav.PrvniCislo;
                _prvni = 0;
                _druhe = 0;
                _operace = "";
                break;

            case "CE":
                _display = "0";
                break;

            case "MC":
                _ulozenaHodnota = 0;
                _pamet = "";
                break;

            case "M+":
                if (double.TryParse(_display, out var mplus))
                {
                    _ulozenaHodnota += mplus;
                    _pamet = "M";
                }
                break;

            case "M-":
                if (double.TryParse(_display, out var mminus))
                {
                    _ulozenaHodnota -= mminus;
                    _pamet = "M";
                }
                break;

            case "MR":
                _display = _ulozenaHodnota.ToString();
                break;

            case "MS":
                _ulozenaHodnota = double.TryParse(_display, out var ms) ? ms : 0;
                _pamet = "M";
                break;

            case "<-":
                if (_display.Length > 1)
                    _display = _display.Substring(0, _display.Length - 1);
                else
                    _display = "0";
                break;

            case "+/-":
                if (_display.StartsWith("-"))
                    _display = _display.Substring(1);
                else if (_display != "0")
                    _display = "-" + _display;
                break;

            case ",":
                if (!_display.Contains(","))
                    _display += ",";
                break;

            case "+":
            case "-":
            case "*":
            case "/":
                _prvni = double.Parse(_display);
                _operace = vstup;
                _stav = Stav.DruheCislo;
                break;

            case "=":
                if (_stav == Stav.DruheCislo || _stav == Stav.Vysledek)
                {
                    _druhe = double.Parse(_display);
                    _display = Vypocet(_prvni, _druhe, _operace).ToString();
                    _stav = Stav.Vysledek;
                }
                break;

            default:
                if (char.IsDigit(vstup[0]))
                {
                    if (_display == "0" || _stav == Stav.Operace || _stav == Stav.Vysledek)
                    {
                        _display = vstup;

                        if (_stav == Stav.Operace)
                            _stav = Stav.DruheCislo;
                        else if (_stav == Stav.Vysledek)
                            _stav = Stav.PrvniCislo;
                    }
                    else if (_stav == Stav.DruheCislo && _display == _prvni.ToString())
                    {
                        _display = vstup;
                    }
                    else
                    {
                        _display += vstup;
                    }
                }
                break;
        }
    }

    private double Vypocet(double a, double b, string op)
    {
        return op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => b != 0 ? a / b : 0,
            _ => 0
        };
    }
}
