using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFirmaSQLite
{
    public partial class MainPage : ContentPage
    {
        public byte[] firma;
        public MainPage()
        {
            InitializeComponent();
        }

        private async Task<bool> ValidationSignature()
        {
            if (String.IsNullOrWhiteSpace(ttname.Text))
            {
                await this.DisplayAlert("Alert", "Ingrese un nombre", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(ttdecrip.Text))
            {
                await this.DisplayAlert("Alert", "Ingrese una descripcion", "OK");
                return false;
            }

            if (viewfirma.IsBlank)
            {
                await this.DisplayAlert("Alert", "Realice la firma", "OK");
                return false;
            }

            return true;
        }

        private async void btn_lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage());
        }

        [Obsolete]
        private async void btn_salvar_Clicked(object sender, EventArgs e)
        {

            //Boton de Guardar
            if (await ValidationSignature())
            {


                try
                {
                    //var personas = (Models.Personas)BindingContext;

                    var Firma = new Models.Firma
                    {
                        nombre = this.ttname.Text,
                        descripcion = this.ttdecrip.Text,
                        firma = firma,

                    };

                    ClearScreen();

                    var resultado = await App.DataBaseSQLite.GrabarFrimas(Firma);

                    if (resultado == 1)
                    {
                        await DisplayAlert("Agregado", "Ingresado Exitosamente", "OK");

                     
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo agregar", "OK");
                    }

                }

                catch (Exception)
                {
                    await DisplayAlert("Exito", "Guardado Correctamente", "OK");
                    await Navigation.PushAsync(new MainPage());
                    viewfirma.Clear();
                }
            }
        }


        private void ClearScreen()
        {
            this.ttname.Text = String.Empty;
            this.ttdecrip.Text = String.Empty;

        }


    }
}
