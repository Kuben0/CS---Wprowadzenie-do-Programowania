using System.Windows;

namespace KolkoIKrzyzyk
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private void Butt_Menu_1_Click(object sender, RoutedEventArgs e)
        {
            (new Polski()).Show();

            this.Close();
        }

        private void Butt_Menu_2_Click(object sender, RoutedEventArgs e)
        {
            (new Angielski()).Show();

            this.Close();
        }

        private void Butt_Menu_3_Click(object sender, RoutedEventArgs e)
        {
            (new Ukrainski()).Show();

            this.Close();
        }

        private void Butt_Menu_4_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
