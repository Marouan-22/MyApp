using Xamarin.Forms;

namespace MyApp.Views
{
    public partial class InfoPage : ContentPage
    {
        public string myProperty { get; } = @"Welkom op mijn Info Pagina!

Todo Lijst:
Je hebt een Todo Lijst waar je je eigen schema van kunt maken, je kunt oefeningen toevoegen en verwijderen als je gedaan hebt.

Workout:
Hier kun je workout oefeningen vinden waarvan de instructies onder de afbeelding staan.

Kalender:
Voeg hier jouw planing toe voor de week!

Timer:
Gebruik dit als je wilt timen hoelang je aan een oefening bezig bent!


Veel Oefen Plezier!";
        public InfoPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
