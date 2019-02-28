using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Capa_Negocio
{
    public class Validar
    {
       
            public bool isEmptyForm(Control form)
            {
                bool status = false;
                foreach (var inputs in form.Controls)
                {
                    if (inputs is TextBox)
                    {
                        TextBox inp = inputs as TextBox;
                        if (isEmptyField(inp.Text))
                        {
                            inp.Text = string.Empty;
                            inp.Focus();
                            status = true;
                            break;
                        }
                    }
                }
                return status;
            }

            public static bool isEmptyField(string str)
            {
                bool status = false;

                if (String.IsNullOrEmpty(str))
                    status = true;
                else if (str.Trim() == "")
                    status = true;
                else
                    status = false;

                return status;
            }
            public  void clearForm(Control form)
            {
                foreach (var input in form.Controls)
                {
                    if (input is TextBox)
                    {
                        TextBox inp = input as TextBox;
                        inp.Text = string.Empty;
                    }
                }
            }
        }
    }

