using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_PIS
{
    public class FormManager
    {
        FormSample currentForm;
        FormSample oldForm;

        public FormManager()
        {
            FormOpen(new Autorization());

            Application.Run();
        }

        public void FormOpen(FormSample form)
        {
            oldForm = currentForm;
            currentForm = form;
            currentForm.formManager = this;
            currentForm.Show();

            if (oldForm != null)
                oldForm.Close();
        }

        public void Exit()
        {
            Application.Exit();
        }
    }
}
