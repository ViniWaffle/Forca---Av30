using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jogo_da_forca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string palavraInformada = "";
        string acertosDaPalavra = "";
        int totalErros = 0;
        string letraserradas1 = "";
        string letraserradas2 = "";
        string letraserradas3 = "";
        string letraserradas4 = "";
        string letraserradas5 = "";
        string letraserradas6 = "";
       


        public MainWindow()
        {
            InitializeComponent();
            EstadosIniciasJogo();
            
        }



       
        private void IniciarJogo(object sender, RoutedEventArgs e)
        {
            txtBracoDireito.Visibility = Visibility.Hidden;
            txtBracoEsquerdo.Visibility = Visibility.Hidden;
            txtPernaDireita.Visibility = Visibility.Hidden;
            txtPernaEsquerda.Visibility = Visibility.Hidden;
            txtCabeca.Visibility = Visibility.Hidden;
            txtCorpo.Visibility = Visibility.Hidden;
            if (txtPalavra.Text.ToString() != "")
            {

                palavraInformada = txtPalavra.Text.ToString();
                foreach (char letra in palavraInformada)
                {
                    acertosDaPalavra += "_";
                    txtFrase.Text += " _ ";
                }
             
                btnJogar.Visibility = Visibility.Hidden;
                btnInserirLetra.Visibility = Visibility.Visible;
                txtPalavra.Text = "";
            }
            txtPalavra.MaxLength = 1;

        }

        
        
        private void InserirLetra(object sender, RoutedEventArgs e)
        {
            if (txtPalavra.Text.ToString() != "" && txtPalavra.Text.ToString() != " ")
            {
               
                txtFrase.Text = "";
                
                bool achouLetra = false;
                string acertoTemporario = "";
                for (int i = 0; i < palavraInformada.Length; i++)
                {
                    if (txtPalavra.Text == palavraInformada[i].ToString())
                    {
                        txtFrase.Text += $" {txtPalavra.Text} ";
                        acertoTemporario += txtPalavra.Text;
                        achouLetra = true;
                    }
                    else
                    {
                        txtFrase.Text += $"{acertosDaPalavra[i]} ";
                        acertoTemporario += acertosDaPalavra[i];
                    }
                }
                acertosDaPalavra = acertoTemporario;
                if (achouLetra == false)
                {
                    totalErros++;
                    CalculaErros();
                }

                txtPalavra.Text = "";
                VerificaVitoria();

            }

        }
      

      
        private void SairDaAplicacao(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void CalculaErros()
        {
            if (totalErros == 1)
            {
                txtCabeca.Visibility = Visibility.Visible;
                letraserradas1 = txtPalavra.Text;
                txtLetrasErradas.Text += txtPalavra.Text + ". ";
                totalErros = 1;
            }

            if (totalErros == 2)
            {
                if (txtPalavra.Text != letraserradas1)
                {
                    txtCorpo.Visibility = Visibility.Visible;
                    letraserradas2 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ". ";
                    totalErros = 2;
                }
                else {
                    totalErros = 1;
                }
             
            }
            if (totalErros == 3)
            {
                    if(txtPalavra.Text != letraserradas1 && txtPalavra.Text != letraserradas2)
                    {
                        txtBracoEsquerdo.Visibility = Visibility.Visible;
                        letraserradas3 = txtPalavra.Text;
                        txtLetrasErradas.Text += txtPalavra.Text + ". ";
                    totalErros = 3;
                    }
                else
                {
                    totalErros = 2;
                }

            }
            if (totalErros == 4)
            {
                if (txtPalavra.Text != letraserradas1 && txtPalavra.Text != letraserradas2 && txtPalavra.Text != letraserradas3)
                {
                    txtBracoDireito.Visibility = Visibility.Visible;
                    letraserradas4 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ". ";
                    totalErros = 4;
                }
                else
                {
                    totalErros = 3;
                }

            }
            if (totalErros == 5)
            {
                if (txtPalavra.Text != letraserradas1 && txtPalavra.Text != letraserradas2 && txtPalavra.Text != letraserradas3 && txtPalavra.Text != letraserradas4)
                {
                    txtPernaEsquerda.Visibility = Visibility.Visible;
                    letraserradas5 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ". ";
                    totalErros = 5;
                }
                else
                {
                    totalErros = 4;
                }

            }
            if (totalErros == 6)
            {
                if (txtPalavra.Text != letraserradas1 && txtPalavra.Text != letraserradas2 && txtPalavra.Text != letraserradas3 && txtPalavra.Text != letraserradas4 && txtPalavra.Text != letraserradas5)
                {
                    txtPernaDireita.Visibility = Visibility.Visible;
                    letraserradas6 = txtPalavra.Text;
                    txtLetrasErradas.Text += txtPalavra.Text + ". ";
                    totalErros = 6;
                }
                else
                {
                    totalErros = 5;
                }

            }
            if (totalErros == 7)
            {
                if (txtPalavra.Text != letraserradas1 && txtPalavra.Text != letraserradas2 && txtPalavra.Text != letraserradas3 && txtPalavra.Text != letraserradas4 && txtPalavra.Text != letraserradas5)
                {
                    totalErros = 7;
                    MessageBoxResult dialogo = MessageBox.Show($"Você ERROU a palavra: {palavraInformada}", "Game Over!", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPalavra.Focusable = false;
                    EstadosIniciasJogo();
                }
                else
                {
                    totalErros = 6;
                }

            }

        }

        private void VerificaVitoria()
        {
            if(acertosDaPalavra == palavraInformada && palavraInformada != "")
            {
                MessageBoxResult dialogo = MessageBox.Show($"Você acertou a palavra: {palavraInformada}", "Parabéns!", MessageBoxButton.OK, MessageBoxImage.Information);
                txtPalavra.Focusable = false;
                EstadosIniciasJogo();
               
            }          
        }




        private void EstadosIniciasJogo()
        {
            btnJogar.Visibility = Visibility.Visible;
            btnInserirLetra.Visibility = Visibility.Hidden;
            txtBracoDireito.Visibility = Visibility.Visible;
            txtBracoEsquerdo.Visibility = Visibility.Visible;
            txtPernaDireita.Visibility = Visibility.Visible;
            txtPernaEsquerda.Visibility = Visibility.Visible;
            txtCabeca.Visibility = Visibility.Visible;
            txtCorpo.Visibility = Visibility.Visible;
            txtLetrasErradas.Text = "";
            txtFrase.Text = "";
            palavraInformada = "";
            acertosDaPalavra = "";
            totalErros = 0;
            txtPalavra.MaxLength = 1000;
            txtPalavra.Focusable = true;


        }
    }
}
