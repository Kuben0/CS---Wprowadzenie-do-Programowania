using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KolkoIKrzyzyk
{

    public partial class Ukrainski : Window
    {
        #region Private Members

        private MarkType[] mResults;

        private bool mPlayer1Turn;

        private bool mGameEnded;



        #endregion
        #region Constructor

        /// Default constructor
        public Ukrainski()
        {
            InitializeComponent();

            NewGame();
        }

        #endregion

        private void NewGame()
        {
            mResults = new MarkType[9];

            for (var i = 0; i < mResults.Length; i++)
                mResults[i] = MarkType.Free;

            mPlayer1Turn = true;

            Field.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.OldLace;
                button.Foreground = Brushes.DarkMagenta;
                Clear.Background = Brushes.DarkSalmon;
                Clear.FontSize = 70;
                Clear.Content = "Нова гра";
                Clear.Foreground = Brushes.Black;

                Close.Background = Brushes.LightGreen;
                Close.FontSize = 70;
                Close.Content = "Закінчити гру";
                Close.Foreground = Brushes.Black;

            });



            mGameEnded = false;
        }

        private void Butt_Click(object sender, RoutedEventArgs e)
        {
            if (mGameEnded)
            {
                NewGame();
                return;
            }

            var button = (Button)sender;

            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            if (mResults[index] != MarkType.Free)
                return;

            if (mPlayer1Turn)
                mResults[index] = MarkType.Cross;
            else
                mResults[index] = MarkType.Nought;

            if (mPlayer1Turn)
                button.Content = "X";
            else
                button.Content = "O";

            if (!mPlayer1Turn)
                button.Foreground = Brushes.DarkKhaki;

            mPlayer1Turn ^= true;

            Winner();
        }

        private void Winner()
        {
            //0
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                Butt_0.Background = Butt_1.Background = Butt_2.Background = Brushes.Green;
            }
            //1
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                Butt_3.Background = Butt_4.Background = Butt_5.Background = Brushes.Green;
            }
            //2
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                Butt_6.Background = Butt_7.Background = Butt_8.Background = Brushes.Green;
            }

            //-------------------------------------------------------------------------------------------

            //1
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                Butt_0.Background = Butt_3.Background = Butt_6.Background = Brushes.Green;
            }
            //2
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                Butt_1.Background = Butt_4.Background = Butt_7.Background = Brushes.Green;
            }
            //3
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                Butt_2.Background = Butt_5.Background = Butt_8.Background = Brushes.Green;
            }

            //-------------------------------------------------------------------------------------------

            //1
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                Butt_0.Background = Butt_4.Background = Butt_8.Background = Brushes.Green;
            }
            //2
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                Butt_2.Background = Butt_4.Background = Butt_6.Background = Brushes.Green;
            }

            //NoWinner
            if (!mResults.Any(e => e == MarkType.Free))
            {
                mGameEnded = true;

                Field.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.DarkOrange;
                });
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
            return;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}
