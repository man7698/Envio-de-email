using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace enviaremail
{
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        SmtpClient smtp = new SmtpClient();//Permite que aplicativos enviem e-mail usando o protocolo Simple Mail Transfer Protocol (SMTP).

        MailMessage mail = new MailMessage();//Representa uma mensagem de email que pode ser enviada usando a classe SmtpClient.
        
        private void button1_Click(object sender, EventArgs e)
        {
            string texto = para.Text;

            bool verificar = texto.Contains('@') && texto.Contains(".com");

            if (verificar == true)
            {
                Attachment anexo = new Attachment(label1.Text);
                mail.Attachments.Add(anexo);

                smtp.Host = "smtp.gmail.com"; // Obtém ou define o nome ou o endereço IP do host usado para transações SMTP.

                smtp.Port = 587; //Obtém ou define a porta usada para transações SMTP.

                smtp.EnableSsl = true;//Especifique se SmtpClient use o protocolo SSL (SSL) para criptografar a conexão.

                smtp.UseDefaultCredentials = false;//Obtém ou define um valor de Boolean que controla se DefaultCredentials será enviado com solicitações.

                smtp.Credentials = new System.Net.NetworkCredential("matheusalmeida7698@gmail.com", "matheus58215147%");//Obtém ou define as credenciais usadas para autenticar o remetente.

                mail.From = new MailAddress("matheusalmeida7698@gmail.com", "Matheus A"); //Obtém ou define o endereço do destinatário desta mensagem de email

                if (!string.IsNullOrWhiteSpace(para.Text))//Indica se a String especificada é uma referência nula ou uma String que consiste apenas de caracteres espaço em branco.
                {
                    mail.To.Add(new MailAddress(para.Text)); //Representa o endereço de um remetente ou destinatário de correio eletrônico.
                }
                else
                {
                    MessageBox.Show("Você deve selecionar para quem vai enviar o e-mail", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (!string.IsNullOrWhiteSpace(cc.Text))
                    mail.CC.Add(new MailAddress(cc.Text)); //CC Obtém a coleção de endereços que contém os destinatários de cópia carbono (CC) para essa mensagem de email.

                if (!string.IsNullOrWhiteSpace(cco.Text))
                    mail.CC.Add(new MailAddress(cco.Text)); //Obtém a coleção de endereços que contém os destinatários de cópia carbono (CC) para essa mensagem de email.

                mail.Subject = assunto.Text; //Obtém ou define a linha de assunto para esta mensagem de email.
                mail.IsBodyHtml = true; // Obtém ou define um valor que indica se o corpo da mensagem de email está em Html.
                mail.Priority = MailPriority.Normal;
                mail.Body = mensagem.Text; // Obtém ou define o corpo da mensagem.

                smtp.Send(mail);//Envia a mensagem especificada a um servidor SMTP para entrega.
                MessageBox.Show("Email Enviado com Sucesso!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Digite um Email Valido !!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Multiselect = true;//Obtém ou define um valor que indica se a caixa de diálogo permite vários arquivos a serem selecionados.


            if (dialog.ShowDialog() == DialogResult.OK)
            {

                label1.Text = dialog.FileName;


                //foreach (var file in dialog.FileName)
                //{
                //    anexos.Items.Add(file);
                //}
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
