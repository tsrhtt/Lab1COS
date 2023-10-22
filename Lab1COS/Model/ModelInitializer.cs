using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1COS.Model
{
    public class ModelInitializer
    {
        public static InputModel InitGenerator(Form1 form)
        {
            var model = new InputModel();
            model.A = new double[] { double.Parse(form.tab1Amplitude.Text) };
            model.F = new double[] { double.Parse(form.tab1Frequency.Text) };
            model.Fi = new double[] { double.Parse(form.tab1Phase.Text) };
            model.WorkingCycle = new double[] { form.wellRateTrackBar.Value / 100d };
            model.N = int.Parse(form.nTextBox.Text);
            return model;
        }

        public static InputModel InitPolyGenerator(Form1 form)
        {
            var model = new InputModel();
            model.A = new double[] { double.Parse(form.tab2Amplitude1.Text), double.Parse(form.tab2Amplitude2.Text) };
            model.F = new double[] { double.Parse(form.tab2Frequency1.Text), double.Parse(form.tab2Frequency2.Text) };
            model.Fi = new double[] { double.Parse(form.tab2Phase1.Text), double.Parse(form.tab2Phase2.Text) };
            model.WorkingCycle = new double[] { form.tab2WellRate1.Value / 100d, form.tab2WellRate2.Value / 100d };
            model.N = int.Parse(form.nTextBox.Text);
            return model;
        }

        public static InputModel InitModulizedGenerator(Form1 form)
        {
            var model = new InputModel();
            model.A = new double[] { double.Parse(form.tab3Amplitude1.Text), double.Parse(form.tab3Amplitude2.Text) };
            model.F = new double[] { double.Parse(form.tab3Frequency1.Text), double.Parse(form.tab3Frequency2.Text) };
            model.Fi = new double[] { double.Parse(form.tab3Phase1.Text), double.Parse(form.tab3Phase2.Text) };
            model.WorkingCycle = new double[] { form.tab3WellRate1.Value / 100d, form.tab3WellRate2.Value / 100d };
            model.N = int.Parse(form.nTextBox.Text);
            return model;
        }
    }
}
