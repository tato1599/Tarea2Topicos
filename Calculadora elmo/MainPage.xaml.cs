namespace Calculadora_elmo;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        
	}

    

    public static int suma = 0;

    public void jugar()
    {
        Random rand = new Random();

        int num1 = rand.Next(0, 10);
        int num2 = rand.Next(0, 10);

        suma = num1 + num2;

        lbdorn_numero1.Text = num1.ToString();
        lbdorn_numero2.Text = num2.ToString();
        
        
    }

    void btndorn_generarNumero_Pressed(System.Object sender, System.EventArgs e)
    {
        Random rand = new Random();

        int num1 = rand.Next(0, 10);
        int num2 = rand.Next(0, 10);

        suma = num1 + num2;

        lbdorn_numero1.Text = num1.ToString();
        lbdorn_numero2.Text = num2.ToString();

        btndorn_generarNumero.IsEnabled = false;

        txbdorn_suma.Focus();
    }

    int aciertos = 0, errores = 0;

    void btndorn_enviar_Pressed(System.Object sender, System.EventArgs e)
    {
        int n;
        bool isNumeric = int.TryParse(txbdorn_suma.Text, out n);

        if (isNumeric)
        {

            if (txbdorn_suma.Text == suma.ToString())
            {
                lbdorn_resultado.Text = "Bien";
                aciertos++;
            }
            else
            {
                errores++;
                lbdorn_resultado.Text = "Incorrecto:( el resultado era: " + suma.ToString();
            }

            lbdorn_aciertos.Text = aciertos.ToString();
            lbdorn_errores.Text = errores.ToString();
            txbdorn_suma.Text = "";
            jugar();
        }
        else
        {
            DisplayAlert("Error", "Ingrese solo numeros", "ok");

        }

    }

    void txbdorn_suma_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
        txbdorn_suma.Focus();
    }

    async void btndorn_terminar_Pressed(System.Object sender, System.EventArgs e)
    {
        bool respuesta = await DisplayAlert("Reiniciar", "Seguro que desea reiniciar?", "Aceptar", "cancelar");

        if (respuesta == true)
        {
            lbdorn_errores.Text = "0";
            lbdorn_aciertos.Text = "0";
            aciertos = 0;
            errores = 0;
        }

    }
}


