using DeberS7PugarinSqllite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace DeberS7PugarinSqllite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadoUpdate;
        public Elemento(int Id)
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = Id;
        }

        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id=?", id);
        }
        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre , string usuario, string contrasenia, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET Nombre =?, Usuario=?," + "Contrasenia=? where Id=?", nombre, usuario, contrasenia, id);
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoUpdate = Update(db, Nombre.Text, Usuario.Text, Contrasenia.Text, IdSeleccionado);
                await DisplayAlert("Alerta", "Dato Actualizado", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", "Error"+ex.Message, "ok");
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                await DisplayAlert("Alerta", "Dato Eliminado", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", "Error" + ex.Message, "ok");
            }

        }
    }
}